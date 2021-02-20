using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using TheBees.UnitData;
using TheBees.Controls;
using TheBees.Forms.Verification;

namespace TheBees.Forms
{
    public class UnitSelector
    {
        private bool loaded = false;
        public delegate void OnSelectCompleteDelegate();

        private delegate void ListAddDelegate(ListControl control, object o);
        private delegate void ListAddRangeDelegate(ListControl control, object[] objects);
        private delegate void ListClearDelegate(ListControl control);
        private delegate int ListGetCountDelegate(ListControl control);
        private delegate void ListClearSelectionDelegate(ListControl control);
        private delegate void ListAddOnChangeDelegate(ListControl control, EventHandler e);

        private Dictionary<Type, ListAddDelegate> delegatesListAdd = new Dictionary<Type, ListAddDelegate>();
        private Dictionary<Type, ListAddRangeDelegate> delegatesListAddRange = new Dictionary<Type, ListAddRangeDelegate>();
        private Dictionary<Type, ListClearDelegate> delegatesListClear = new Dictionary<Type, ListClearDelegate>();
        private Dictionary<Type, ListClearSelectionDelegate> delegatesListClearSelection = new Dictionary<Type, ListClearSelectionDelegate>();
        private Dictionary<Type, ListGetCountDelegate> delegatesListCount = new Dictionary<Type, ListGetCountDelegate>();
        private Dictionary<Type, ListAddOnChangeDelegate> delegatesAddOnChange = new Dictionary<Type, ListAddOnChangeDelegate>();
        private Dictionary<Type, Action<ListControl, int[], string>> delegatesUpdateListText = new Dictionary<Type, Action<ListControl, int[], string>>();

        private ListControl cbUnit;
        private ListControl cbGroup;
        private ListControl cbAction;
        private ListControl cbData;

        public ActiveDataElement ActiveData { get; set; }

        private int unitNum = 0;
        private int groupNum = 0;
        private int actionNum = 0;
        private int dataNum = 0;

        private int unitSelPrev = -1;
        private int groupSelPrev = -1;
        private int actionSelPrev = -1;
        private int dataSelPrev = -1;

        private int initUnitNum = 0;
        private int initGroupNum = 0;
        private int initActionNum = 0;
        private int initDataNum = 0;

        public bool VerifyUnitChange { get; set; }
        public bool VerifyGroupChange { get; set; }
        public bool VerifyActionChange { get; set; }
        public bool VerifyDataChange { get; set; }

        private bool preventUpdateUnit = false;
        private bool preventUpdateGroup = false;
        private bool preventUpdateAction = false;
        private bool preventUpdateData = false; 
        
        public bool PreventUpdateUnit { get {return preventUpdateUnit; } set { preventUpdateUnit = value; }}
        public bool PreventUpdateGroup { get { return preventUpdateGroup; } set { preventUpdateGroup = value; } }
        public bool PreventUpdateAction { get { return preventUpdateAction; } set { preventUpdateAction = value; } }
        public bool PreventUpdateData { get { return preventUpdateData; } set { preventUpdateData = value; } }


        public int UnitNum { get { return unitNum; } }
        public int GroupNum { get { return groupNum; } }
        public int ActionNum { get { return actionNum; } }
        public int DataNum { get { return dataNum; } }
        public int MotionIndex { get { return ActiveData.Action.MotionIndexes[dataNum]; } }

        public int GameGroupNum { get { return UnitSpec.GroupIndexesFromGameRef[groupNum]; } }
        public GameRom.DataNode GameGroupData { get { return ActiveData.Group.GetAction(GameGroupNum).GetNode(dataNum); } }

        private bool motionIndexesOnly = false;
        public bool MotionIndexesOnly { set { motionIndexesOnly = value; } }

        private Dictionary<ActionType, bool> actionTypesAvail = new Dictionary<ActionType, bool>();
        private List<ActionType> actionTypeMap = new List<ActionType>();

        private ActionReference[] nodeIndexes = null;
        public ActionReference[] NodeIndexes { get { return nodeIndexes; } }

        public OnSelectCompleteDelegate SelectComplete { get; set; }
        public OnSelectCompleteDelegate SelectUnit { get; set; }
        public OnSelectCompleteDelegate SelectGroup { get; set; }
        public OnSelectCompleteDelegate SelectAction { get; set; }
        public OnSelectCompleteDelegate SelectData { get; set; }

        private GroupListMode listMode = GroupListMode.ByAction;
        public GroupListMode ListMode { set { listMode = value; } }

        private bool enabled = true;
        public bool Enabled { get { return enabled; } }

        private Dictionary<UnitCombo, ListControl> indexedCombos = new Dictionary<UnitCombo, ListControl>();
        private Dictionary<UnitCombo, bool> lockedCombos = new Dictionary<UnitCombo, bool>();

        private UnitCombo fromSelect = UnitCombo.None;
        public UnitCombo FromSelect { get { return fromSelect; } }

        private VerifyHandler verifyHandler = null;
        public VerifyHandler Verification 
        { 
            get 
            { 
                return verifyHandler; 
            } 
            set 
            { 
                verifyHandler = value;
            } 
        }

        public string VerifyCaption;
        public string VerifyMessage;

        public void ListAdd(ListControl control, object o)
        {
            delegatesListAdd[control.GetType()](control, o);
        }

        public void ListAddRange(ListControl control, object[] objects)
        {
            delegatesListAddRange[control.GetType()](control, objects);
        }

        public int ListCount(ListControl control)
        {
            return delegatesListCount[control.GetType()](control);
        }

        public void ListClear(ListControl control)
        {
            delegatesListClear[control.GetType()](control);
        }


        public void ListClearSelect(ListControl control)
        {
            if (delegatesListClearSelection[control.GetType()] != null)
            {
                delegatesListClearSelection[control.GetType()](control);
            }
        }

        public void ListAddOnChange(ListControl control, EventHandler e)
        {
            delegatesAddOnChange[control.GetType()](control, e);
        }
        public UnitSelector(ListControl unitCombo, ListControl groupCombo, ListControl actionCombo, ListControl dataCombo)
        {
            ActiveData = new ActiveDataElement(); 
 
            cbUnit = unitCombo;
            cbGroup = groupCombo;
            cbAction = actionCombo;
            cbData = dataCombo;

            indexedCombos[UnitCombo.Unit] = cbUnit;
            indexedCombos[UnitCombo.Category] = cbGroup;
            indexedCombos[UnitCombo.Action] = cbAction;
            indexedCombos[UnitCombo.Data] = cbData;

            lockedCombos[UnitCombo.Unit] = false;
            lockedCombos[UnitCombo.Category] = false;
            lockedCombos[UnitCombo.Action] = false;
            lockedCombos[UnitCombo.Data] = false;
            
            delegatesListAdd[typeof(ComboBox)] = (c, o) => { ((ComboBox)c).Items.Add(o); };
            delegatesListAdd[typeof(ActionDataListBox)] = (c, o) => { ((ActionDataListBox)c).Items.Add(o); };
            delegatesListAddRange[typeof(ComboBox)] = (c, o) => { ((ComboBox)c).Items.AddRange(o); };
            delegatesListAddRange[typeof(ActionDataListBox)] = (c, o) => { ((ActionDataListBox)c).Items.AddRange(o); };
            delegatesListClear[typeof(ComboBox)] = (c) => { ((ComboBox)c).Items.Clear(); };
            delegatesListClear[typeof(ActionDataListBox)] = (c) => { ((ActionDataListBox)c).Items.Clear(); };
            delegatesListCount[typeof(ComboBox)] = (c) => { return ((ComboBox)c).Items.Count; };
            delegatesListCount[typeof(ActionDataListBox)] = (c) => { return ((ActionDataListBox)c).Items.Count; };
            delegatesAddOnChange[typeof(ComboBox)] = (c, e) => { ((ComboBox)c).SelectedIndexChanged += e; };
            delegatesAddOnChange[typeof(ActionDataListBox)] = (c, e) => { ((ActionDataListBox)c).SelectedIndexChanged += e; };
            delegatesListClearSelection[typeof(ComboBox)] = null;
            delegatesListClearSelection[typeof(ActionDataListBox)] = (c) => { ((ActionDataListBox)c).ClearSelected(); };
            delegatesUpdateListText[typeof(ComboBox)] = UpdateTextCombo;
            delegatesUpdateListText[typeof(ActionDataListBox)] = UpdateTextList;

            if (unitCombo != null) { ListAddOnChange(cbUnit, OnUnitSelect); }
            if (groupCombo != null){ListAddOnChange(cbGroup, OnGroupSelect);}
            if (actionCombo != null) { ListAddOnChange(cbAction, OnActionSelect);}
            if (dataCombo != null){ListAddOnChange(cbData, OnDataSelect);;}

            
            VerifyUnitChange = true;
            VerifyGroupChange = true;
            VerifyActionChange = true;
            VerifyDataChange = true;

            EnableAllGroups();
        }

        public void EnableAllGroups(bool enable = true)
        {
            int start = Enum.GetValues(typeof(ActionType)).Cast<int>().Min();
            int limit = (int)ActionType.None;

            for (int i = 0; i < limit; i++)
            {
                actionTypesAvail[(ActionType)i] = enable;
            }
        }

        public void Lock(UnitCombo sourceCombo)
        {
            if (!lockedCombos[sourceCombo])
            {
                lockedCombos[sourceCombo] = true;
                indexedCombos[sourceCombo].Enabled = false;
            }
        }

        public void Unlock(UnitCombo sourceCombo)
        {
            lockedCombos[sourceCombo] = false;
        }

        public void EnableGroup(ActionType type, bool enable = true)
        {
            actionTypesAvail[type] = enable;
        }

        public void LoadWithSelection(ActionReference srcReference)
        {
            if (!loaded)
                throw new Exception("Loading not complete");

            MakeSelection(srcReference);
        }

        public void MakeSelection(ActionReference srcReference)
        {
            MakeSelection(srcReference.UnitNum, srcReference.GroupNum, srcReference.ActionNum, srcReference.DataNum);
        }

        public void LoadFromUnit(int srcUnitNum = -1)
        {
            if (!loaded)
                throw new Exception("Loading not complete");
            
            if (srcUnitNum == -1)
                UpdateUnitSelect(0);
            else
            {
                unitNum = srcUnitNum;
                UpdateUnitSelect(srcUnitNum);
            }
        }

        public void CompleteSettings()
        {

            UpdateCategoryList();

            if (cbUnit != null)
            {
                ListAddRange(cbUnit, Description.DescSpec.UnitNamesFromRomIndex);
                ListAdd(cbUnit, Description.DescSpec.MissileName);
                ListAdd(cbUnit, Description.DescSpec.BonusStageUnitName);


                preventUpdateUnit = true;
                cbUnit.SelectedIndex = 0;
                preventUpdateUnit = false;


            }

            loaded = true;
        }

        public void MakeSelection(int unitSel, int groupSel, int actionSel, int dataSel, bool force = false)
        {
            initGroupNum = groupSel < 0 ? groupNum : groupSel;
            initActionNum = actionSel < 0 ? actionSel : actionSel;
            initDataNum = dataSel < 0 ? dataSel : dataSel;

            unitSelPrev = unitSel != -1 && force ? -1 : unitSelPrev;
            groupSelPrev = groupSel != -1 && force ? -1 : groupSelPrev;
            actionSelPrev = actionSel != -1 && force ? -1 : actionSelPrev;
            dataSelPrev = dataSel != -1 && force ? -1 : dataSelPrev;
            
            fromSelect = UnitCombo.None;

            if (unitSel != -1 && unitSelPrev != unitSel || cbUnit != null && force)
            {
                if(unitSel < ListCount(cbUnit))
                {
                    preventUpdateUnit = true;
                    cbUnit.SelectedIndex = unitSel;
                    preventUpdateUnit = false;

                    UpdateUnitSelect(unitSel);
                }
            }
            else if (cbGroup != null && groupSelPrev != groupSel && groupSel != -1 || cbGroup != null && force)
            {
                if(groupSel < ListCount(cbGroup))
                {
                    preventUpdateGroup = true;
                    cbGroup.SelectedIndex = groupSel;
                    preventUpdateGroup = false;

                    UpdateGroupSelect(groupSel);
                }
            }
            else if (cbAction != null && actionSelPrev != actionSel && actionSel != -1 || cbAction != null && force)
            {
                if ( actionSel < ListCount(cbAction))
                {
                    preventUpdateAction = true;
                    cbAction.SelectedIndex = actionSel;
                    preventUpdateAction = false;

                    UpdateActionSelect(actionSel);
                }
            }
            else if (cbData != null && dataSelPrev != dataSel && dataSel != -1 || cbData != null && force)
            {
                if (dataSel< ListCount(cbData))
                {
                    preventUpdateData = true;
                    cbData.SelectedIndex = dataSel;
                    preventUpdateData = false;

                    UpdateDataSelect(dataSel);
                }
            }
        }

        private void UpdateCategoryList()
        {
            actionTypeMap.Clear();
            foreach (KeyValuePair<ActionType, bool> typeAvail in actionTypesAvail)
            {
                if (typeAvail.Value == true)
                {
                    actionTypeMap.Add(typeAvail.Key);
                    ListAdd(cbGroup, Description.DescSpec.CategoryNames[(int)typeAvail.Key]);
                }
            }
        }

        private void UpdateActionList()
        {

            string[] items;
            items = UnitDescription.GetActionGroupNames(ActiveData.Unit.ActionGroups[actionTypeMap[groupNum]]);

            ListClear(cbAction);
            ListAddRange(cbAction, items);
        }

        private void UpdateDataList()
        {
            ListClear(cbData);
            if (listMode == GroupListMode.ByAllIndexes)
            {
                //ListAddRange(cbData, Description.DescSpec.GetNodeGroupDescriptions(ActiveData.Action));
                ListAddRange(cbData, Description.DescSpec.GetIndexedList(nodeIndexes.Length));
            }
            else if (listMode == GroupListMode.ByAction)
            {
                if (motionIndexesOnly)
                {
                    ListAddRange( cbData, Description.DescSpec.GetNumberedList(ActiveData.Action.MotionIndexes));
                }
                else
                {
                    ListAddRange(cbData, Description.DescSpec.GetNodeGroupDescriptions(ActiveData.Action.GetNodesFromIndexes()));
                    //ListAddRange( cbData, Description.DescSpec.GetIndexedList(ActiveData.Action.Count));
                }
            }
            
        }

        private void UpdateTextCombo(ListControl control, int[] indexes, string newText)
        {
            ComboBox cb = (ComboBox)control;

            foreach (int index in indexes)
            {
                cb.Items[index] = newText;
            }
        }

        private void UpdateTextList(ListControl control, int[] indexes, string newText)
        {
            ActionDataListBox cb = (ActionDataListBox)control;

            foreach (int index in indexes)
            {
                cb.Items[index] = newText;
            }
        }

        public void UpdateActionListText(int[] indexes, string newText)
        {
            delegatesUpdateListText[indexedCombos[UnitCombo.Action].GetType()](cbAction, indexes, newText);
        }

        public void SwapListText(UnitCombo combo, int source, int destination)
        {
            if (indexedCombos[combo] is ActionDataListBox)
            {
                ActionDataListBox ActionDataListBox = (ActionDataListBox)indexedCombos[combo];
                string swap = ActionDataListBox.Items[source].ToString();
                ActionDataListBox.Items[source] = ActionDataListBox.Items[destination].ToString();
                ActionDataListBox.Items[destination] = swap;
                ActionDataListBox.ClearSelected();
            }
            else
            {
                throw new Exception("Can only swap list text on ActionDataListBoxes");
            }
            
        }
        public void Enable(bool enable = true)
        {
            if (cbUnit != null && !lockedCombos[UnitCombo.Unit])
                cbUnit.Enabled = enable;
            if (cbGroup != null && !lockedCombos[UnitCombo.Category])
                cbGroup.Enabled = enable;
            if (cbAction != null && !lockedCombos[UnitCombo.Action])
                cbAction.Enabled = enable;
            if (cbData != null && !lockedCombos[UnitCombo.Data])
                cbData.Enabled = enable;

            enabled = enable;
        }

        public void Disable()
        {
            Enable(false);
        }
        private void UpdateUnitSelect(int unitSel)
        {
            unitSelPrev = unitSel;
            unitNum = unitSel;
            ActiveData.SetUnit(UnitHandler.GetUnit(unitNum));
            OnSelectUnit();
            ActionGroup newGroup = ActiveData.Unit.GetActionGroup(actionTypeMap[groupNum]);
            int groupCount = 0;

            if (newGroup != null)
            {
                if (cbGroup != null)
                {
                    groupCount = ActiveData.Unit.GetActionGroup(actionTypeMap[groupNum]).Count;
                }

                if (cbGroup != null && groupCount != 0)
                {
                    if (initGroupNum >= groupCount)
                    {
                        initGroupNum = 0;
                    }

                    preventUpdateGroup = true;
                    cbGroup.SelectedIndex = initGroupNum;
                    preventUpdateGroup = false;

                    groupNum = initGroupNum;
                    UpdateGroupSelect(initGroupNum);
                }
                else
                {
                    ActiveData.SetGroup(null);
                    ActiveData.SetAction(null);
                    ActiveData.SetDataNode(null);
                    OnSelectComplete();
                }
            }
            else
            {
                groupNum = -1;
                ActiveData.SetGroup(null);
                ActiveData.SetAction(null);
                ActiveData.SetDataNode(null);
                OnSelectComplete();
            }

            
        }

        private void UpdateGroupSelect(int groupSel)
        {
            groupNum = groupSel;
            groupSelPrev = groupSel;

            ActiveData.SetGroup(ActiveData.Unit.GetActionGroup(actionTypeMap[groupNum]));
            if (listMode == GroupListMode.ByAllIndexes) nodeIndexes = ActiveData.Group.GetAllIndexes();

            OnSelectGroup();
            
            if (ActiveData.Group.Count > 0)
            {
                if (listMode == GroupListMode.ByAction)
                {
                    UpdateActionList();

                    if (initActionNum >= ActiveData.Group.Count)
                    {
                        initActionNum = 0;
                    }

                    preventUpdateAction = true;
                    cbAction.SelectedIndex = initActionNum;
                    preventUpdateAction = false;

                    actionNum = initActionNum;
                    UpdateActionSelect(initActionNum);
                }
                else if(listMode == GroupListMode.ByAllIndexes)
                {
                    UpdateDataList();
                    if (cbData != null && nodeIndexes.Length > 0)
                    {

                        if (initDataNum >= nodeIndexes.Length)
                        {
                            initDataNum = 0;
                        }

                        preventUpdateData = true;
                        cbData.SelectedIndex = initDataNum;
                        preventUpdateData = false;

                        dataNum = initDataNum;
                        UpdateDataSelect(initDataNum);
                    }
                }

            }
            else
            {
                ActiveData.SetAction(null);
                ActiveData.SetDataNode(null);
                OnSelectComplete();
            }
            
        }

        private void UpdateActionSelect(int actionSel)
        {
            actionNum = actionSel;
            actionSelPrev = actionSel;
            ActiveData.SetAction(ActiveData.Group.GetAction(actionNum));
            OnSelectAction();

            if (cbData != null && ActiveData.Action.Count > 0)
            {
                UpdateDataList();

                if (initDataNum >= ActiveData.Action.Count)
                {
                    initDataNum = 0;
                }

                preventUpdateData = true;
                cbData.SelectedIndex = initDataNum;
                preventUpdateData = false;

                dataNum = initDataNum;
                UpdateDataSelect(initDataNum);
            }
            else
            {
                ActiveData.SetDataNode(null);
                OnSelectComplete();
            }
        }

        private void UpdateDataSelect(int dataSel)
        {
            dataNum = dataSel;
            dataSelPrev = dataSel;
            if (listMode == GroupListMode.ByAction)
            {
                if (motionIndexesOnly)
                {
                    ActiveData.SetDataNode(ActiveData.Action.GetMotion(dataNum));
                }
                else
                {
                    ActiveData.SetDataNode(ActiveData.Action.GetNode(dataNum));
                }
            }
            else if (listMode == GroupListMode.ByAllIndexes)
            {
                ActiveData.SetDataNode(ActiveData.Group.GetAction(nodeIndexes[dataNum].ActionNum).GetNode(nodeIndexes[dataNum].DataNum));
            }

            OnSelectComplete();
        }

        ////////////////////////////////////////
        // shortcuts
        ////////////////////////////////////////

        public void NextAction()
        {
            if (actionNum + 1 >= ActiveData.Group.Count)
                return;

            actionNum += 1;
            cbAction.SelectedIndex = actionNum;
            OnActionSelect(null, EventArgs.Empty);
            
        }

        public void PreviousAction()
        {
            if (actionNum - 1 < 0)
                return;

            actionNum -= 1;
            cbAction.SelectedIndex = actionNum;
            OnActionSelect(null, EventArgs.Empty);
        }

        public void NextData()
        {
            if (dataNum + 1 >= ActiveData.Action.Count)
                return;

            dataNum += 1;
            ListClearSelect(cbData);
            cbData.SelectedIndex = dataNum;
            OnDataSelect(null, EventArgs.Empty);
        }

        public void PreviousData()
        {
            if (dataNum -1 < 0 )
                return;

            dataNum -= 1;
            ListClearSelect(cbData);
            cbData.SelectedIndex = dataNum;
            OnDataSelect(null, EventArgs.Empty);
        }

        private void OnSelectUnit()
        {
            if (SelectUnit != null)
            {
                SelectUnit();
            }
        }

        private void OnSelectGroup()
        {
            if (SelectGroup != null)
            {
                SelectGroup();
            }
        }

        private void OnSelectAction()
        {
            if (SelectAction != null)
            {
                SelectAction();
            }
        }

        private void OnSelectComplete()
        {
            if (SelectComplete != null)
            {
                SelectComplete();
            }
        }

        private void OnUnitSelect(object sender, EventArgs e)
        {
            if (!preventUpdateUnit)
            {
                if (!VerifyUnitChange || VerifyChanges())
                {
                    initGroupNum = 0;
                    initActionNum = 0;
                    initDataNum = 0;
                    fromSelect = UnitCombo.Unit;
                    UpdateUnitSelect(cbUnit.SelectedIndex);
                }
                else
                {
                    preventUpdateUnit = true;
                    ListClearSelect(cbUnit);
                    cbUnit.SelectedIndex = unitNum;
                    preventUpdateUnit = false;
                }
            }
        }
        private void OnGroupSelect(object sender, EventArgs e)
        {
            if (!preventUpdateGroup)
            {
                if (!VerifyGroupChange || VerifyChanges())
                {
                    initActionNum = 0;
                    initDataNum = 0;
                    fromSelect = UnitCombo.Category;
                    UpdateGroupSelect(cbGroup.SelectedIndex);
                }
                else
                {
                    preventUpdateGroup = true;
                    ListClearSelect(cbGroup);
                    cbGroup.SelectedIndex = unitNum;
                    preventUpdateGroup = false;
                }
            }
        }
        private void OnActionSelect(object sender, EventArgs e)
        {
            if (!preventUpdateAction)
            {
                if (!VerifyActionChange || VerifyChanges())
                {
                    initDataNum = 0;
                    fromSelect = UnitCombo.Action;
                    UpdateActionSelect(cbAction.SelectedIndex);
                }
                else
                {
                    preventUpdateAction = true;
                    ListClearSelect(cbAction);
                    cbAction.SelectedIndex = unitNum;
                    preventUpdateAction = false;
                }
            }
        }
        private void OnDataSelect(object sender, EventArgs e)
        {
            if (!preventUpdateData && cbData.SelectedIndex != -1)
            {
                if (!VerifyDataChange || VerifyChanges())
                {
                    fromSelect = UnitCombo.Data;
                    UpdateDataSelect(cbData.SelectedIndex);
                }
                else
                {
                    preventUpdateData = true;
                    ListClearSelect(cbData);
                    cbData.SelectedIndex = dataNum;
                    preventUpdateData = false;
                }
            }
        }

        private bool VerifyChanges()
        {
            if (verifyHandler == null)
                return true;

            return verifyHandler.Confirm(VerifyCaption, VerifyMessage);
        }
    }

    public enum UnitListMode
    {
        Basic,
        RomIndexed,
    }

    public enum GroupListMode
    {
        ByAction,
        ByAllIndexes
    }

    public enum UnitCombo
    {
        Unit,
        Category,
        Action,
        Data,
        None
    }

    public enum DataListType
    {
        List,
        Combo
    }
}
