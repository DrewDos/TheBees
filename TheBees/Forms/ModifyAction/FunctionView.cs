using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

using TheBees.UnitData;

namespace TheBees.Forms
{
    public partial class FunctionView : Form
    {
        private DirectionalKeyAction keyAction;
        private Thread loadingThread;
        private LoadingForm loadingForm;
        private int max = 0;
        private List<int> functionIndexes;
        private int functionIndex = 0;
        private UnitSelector selector;
        private int currRefIndex = 0;
        private int currRefCount = 0;
        private bool handleCreated = false;

        public FunctionView(UnitSelector srcSelector)
        {
            InitializeComponent();

            keyAction = new DirectionalKeyAction();
            keyAction.LeftEvent += () => OnClickPrevious(null, EventArgs.Empty);
            keyAction.RightEvent += () => OnClickNext(null, EventArgs.Empty);
            keyAction.UpEvent += PreviousFunction;
            keyAction.DownEvent += NextFunction;

            selector = srcSelector;

            ActionDebug.NextActionEvent += (x) => { UpdateLoadingForm("Checking Action #" + x.ToString(), x); };
            ActionDebug.GetActionCountEvent += (x) => { max = x; loadingForm.SetProgressMax(x); };
            ActionDebug.CompleteEvent += OnCompleteLoading;

            loadingForm = new LoadingForm();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyAction.Process(ModifierKeys, keyData))
                return true;

            if ((keyData & Keys.Enter) == Keys.Enter)
            {
                UpdateReferenceMessage(ActionDebug.ToggleIsReference(functionIndexes[functionIndex]));
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void UpdateReferenceMessage(bool set)
        {
            if (set)
            {
                lblReferenceSet.Text = "Reference Set";
            }
            else
            {
                lblReferenceSet.Text = "";
            }
                
        }

        private void UpdateIndexView(int current, int max)
        {
            lblIndex.Text = ("Action " + current + " of " + max);
        }
        private bool Start()
        {
            loadingForm.SetMessage("Loading...");
            loadingForm.SetProgress(0); 
            
            loadingThread = new Thread(
                 new ThreadStart(() =>
                 {
                     ActionDebug.GetAllFunctionReferences();
                 }

             ));

            loadingForm.HandleCreated += OnFormHandleCreated;
            loadingForm.ShowDialog();
            return true;
        }

        private void CloseLoadingForm()
        {
            loadingForm.BeginInvoke(
                new Action(() =>
                {
                    loadingForm.Close();
                }
            ));
        }

        private void UpdateLoadingForm(string message, int progress)
        {
            if (handleCreated)
            {
                loadingForm.BeginInvoke(
                    new Action(() =>
                    {
                        loadingForm.SetMessage(message);
                        loadingForm.SetProgress(progress);
                    }
                ));
            }
        }
        private void OnFormHandleCreated(object o, EventArgs e)
        {
            handleCreated = true;
            loadingThread.Start();
        }

        public void OnCompleteLoading()
        {
            loadingForm.DialogResult = DialogResult.OK;
            handleCreated = false;
        }

        public void LoadForm()
        {
            functionIndexes = new List<int>();
            cbFunction.Items.Clear();
            foreach (int key in ActionDebug.FunctionReferences.Keys)
            {
                functionIndexes.Add(key);
            }

            functionIndexes.Sort();
            functionIndexes.ForEach((x) => cbFunction.Items.Add("0x" + x.ToString("X2")));

            functionIndex = 0;
            cbFunction.SelectedIndex = functionIndex;
            UpdateFunctionSelect();
        }

        private void UpdateFunctionSelect()
        {
            currRefCount = ActionDebug.FunctionReferences[functionIndexes[functionIndex]].Count;

            UpdateReferenceMessage(ActionDebug.HasIsReference(functionIndexes[functionIndex]));
            UpdateReferenceSelect(0);
            lblIndex.Text = "0 of " + currRefCount.ToString();

        }

        private void UpdateReferenceSelect(int newRefIndex)
        {
            currRefIndex = newRefIndex;
            ActionReference srcRef = ActionDebug.FunctionReferences[functionIndexes[functionIndex]][newRefIndex];
            lblIndex.Text = newRefIndex.ToString() + " of " + currRefCount.ToString();
            selector.MakeSelection(srcRef.UnitNum, srcRef.GroupNum, srcRef.ActionNum, srcRef.DataNum);
        }

        private void OnClickPrevious(object sender, EventArgs e)
        {
            if (currRefIndex - 1 < 0)
                return;

            UpdateReferenceSelect(currRefIndex + -1);
        }

        private void OnClickNext(object sender, EventArgs e)
        {
            if (currRefIndex + 1 >= currRefCount)
                return;

            UpdateReferenceSelect(currRefIndex + 1);
        }

        private void PreviousFunction()
        {
            if (functionIndex - 1 < 0)
                return;

            cbFunction.SelectedIndex = functionIndex - 1;
            UpdateFunctionSelect();
        }

        private void NextFunction()
        {
            if (functionIndex + 1 >= functionIndexes.Count)
                return;

            cbFunction.SelectedIndex = functionIndex + 1;
            UpdateFunctionSelect();
        }


        private void OnShown(object sender, EventArgs e)
        {
            if (Start())
            {
                LoadForm();
            }
        }

        private void OnChangeFunction(object sender, EventArgs e)
        {
            functionIndex = cbFunction.SelectedIndex;
            UpdateFunctionSelect();
        }

        private void OnWriteText(object sender, EventArgs e)
        {
            ActionDebug.WriteReferenceArray();
        }
    }
}
