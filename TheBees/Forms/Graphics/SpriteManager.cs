using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

using TheBees.Sprites;
using TheBees.User;
using TheBees.Records;

namespace TheBees.Forms
{
    public partial class SpriteManager : Form
    {
        //private List<LookupTag> lookupTags = LookupTagGuide.LookupTags;
        //private List<SpriteRegion> regions = SpriteRegionGuide.SpriteRegions;
        //private List<SpriteCreateRef> sessionRefs = SpriteCreationGuide.CreationReferences;

        private SpriteSessionRef sessionRef;
        private SpriteSessionRef todaysRef;
        private int todaysRefIndex;
        private LookupTag lookupTag;
        private SpriteRegion region;

        private int lookupIndex = 0;
        private int regionIndex = 0;
        private int createRefIndex = 0;
        private int newIndexesIndex;

        private string pathSrcPallet = "";
        private string [] srcFiles;
        private string pathSrcDir = "";

        private int sessionIndexOnCreate = -1;
        public int SessionIndex { get { return sessionIndexOnCreate; } }
        public int SelectedNewIndex { get { return newIndexesIndex; } }

        private Color[] pallet;

        public const string MessageCaption = "Sprite Manager";
        // for debugging purposes
        SpriteViewer viewer;

        public SpriteManager()
        {
            InitializeComponent();

            viewer = new SpriteViewer();

            PopulateLookupTags();
            PopulateRegions();
            PopulateSessionReferences();
            SetupTempSessionRef();

            cbLookupTag.SelectedIndex = lookupIndex;
            cbTargetRegion.SelectedIndex = regionIndex;
            cbSessionRef.SelectedIndex = createRefIndex;

            UpdateLookupTagSelect();
            UpdateSpriteRegionSelect();
            UpdateSessionRefSelect();

        }

        private void PopulateLookupTags()
        {        
            cbLookupTag.Items.Clear();

            foreach (LookupTag tag in LookupTagGuide.LookupTags)
            {
                cbLookupTag.Items.Add(tag.Tag);
            }
        }

        private void PopulateRegions()
        {
            cbTargetRegion.Items.Clear();

            foreach (SpriteRegion region in SpriteRegionGuide.SpriteRegions)
            {
                cbTargetRegion.Items.Add(region.Tag);
            }
        }

        private void PopulateSessionReferences()
        {
            cbSessionRef.Items.Clear();

            foreach (SpriteSessionRef reference in SpriteSessionGuide.CreationReferences)
            {
                cbSessionRef.Items.Add(reference.Name);
            }
        }

        private void SetupTempSessionRef()
        {
            DateTime dateTime = DateTime.Now;
            todaysRef = SpriteSessionGuide.MakeCreationReference(DateTime.Now.ToString("yyyy-MM-dd, HH:mm"));
            todaysRefIndex = SpriteSessionGuide.CreationReferences.Count - 1;

            sessionRef = todaysRef;
            cbSessionRef.Items.Add(sessionRef.Name);
            
            createRefIndex = cbSessionRef.Items.Count - 1;
        }

        ////////////////////////////////////////
        // selection
        ////////////////////////////////////////

        private void UpdateSessionRefSelect()
        {
            sessionRef = SpriteSessionGuide.CreationReferences[createRefIndex];

            UpdateSpriteIndexes();
        }

        private void UpdateLookupTagSelect()
        {
            lookupTag = LookupTagGuide.LookupTags[lookupIndex];
        }

        private void UpdateSpriteRegionSelect()
        {
            region = SpriteRegionGuide.SpriteRegions[regionIndex];
        }

        private bool UpdateEnableSpriteIndexes()
        {
            bool enable = sessionRef.Indexes.Length != 0 && pallet != null;
            
            cbNewIndexes.Enabled = enable;
            btnRemoveIndex.Enabled = enable;

            return enable;
        }

        private void UpdateSpriteIndexes()
        {
            cbNewIndexes.Items.Clear();

            if (UpdateEnableSpriteIndexes())
            {
                foreach (int index in sessionRef.Indexes)
                {
                    cbNewIndexes.Items.Add("0x" + index.ToString("X4"));
                }

                newIndexesIndex = 0;
                UpdateSpriteIndexSelect();
            }
        }

        private void UpdateSpriteIndexSelect()
        {
            if (newIndexesIndex != -1)
            {
                viewer.ShowNormalSprite(sessionRef.Indexes[newIndexesIndex], pallet);
            }
            else
            {
                // clear sprites through viewer
                viewer.Clear();
            }
        }
        ////////////////////////////////////////
        // validation
        ////////////////////////////////////////

        private bool AttemptLoad()
        {
            // make sure pallet is loaded
            if (pallet == null)
            {
                MessageBox.Show("No pallet loaded", MessageCaption);
                return false ;
            }

            // validate region amount
            if (region.GetAvailIndexCount() == 0)
            {
                MessageBox.Show("No available indexes in region", MessageCaption);
                return false;
                
            }

            // validate source directory or file(s)
            if (srcFiles != null)
            {
                List<int> validFileIndexes = new List<int>();
                for (int i = 0; i < srcFiles.Length; i++)
                {
                    string currFile = srcFiles[i];

                    if (File.Exists(currFile))
                    {
                        validFileIndexes.Add(i);
                    }
                }

                if (validFileIndexes.Count == 0)
                {
                    MessageBox.Show("Error loading from files", MessageCaption);
                    return false;
                }
                
                int convertCount = VerifyConvertCount(srcFiles.Length);

                if (convertCount == -1)
                {
                    return false;
                }

                return LoadFromFiles(srcFiles, validFileIndexes.ToArray(), convertCount);
                
            }

            else if (pathSrcDir != "")
            {
                if (!Directory.Exists(pathSrcDir))
                {
                    MessageBox.Show("Error loading from directory", MessageCaption);
                    return false;
                }
                

                int convertCount = VerifyConvertCount(SpriteHandler.GetNumImages(pathSrcDir));

                if (convertCount == -1)
                {
                    return false;
                }

                return LoadFromDirectory(pathSrcDir, convertCount);

            }
            else
            {
                MessageBox.Show("No possible source to load from", MessageCaption);
                return false;

            }
        }

        private int VerifyConvertCount(int srcCount)
        {
            int availCount = region.GetAvailIndexCount();
            if (availCount < srcCount)
            {
                string msg = "Only " + availCount.ToString() + " slots available under this region.";
                msg += " " + srcCount.ToString() + " required. Continue?";
                DialogResult res = MessageBox.Show(msg, MessageCaption, MessageBoxButtons.YesNo);

                if(res == DialogResult.Yes)
                    return availCount;

                return -1;
            }

            return srcCount;
        }
        ////////////////////////////////////////
        // file loading/unloading
        ////////////////////////////////////////

        private void LoadPallet()
        {
            pallet = SpriteCreator.PalletFile.Get(pathSrcPallet);

            if (pallet == null)
            {
                MessageBox.Show("Error loading pallet", MessageCaption);
                return;
            }
            tbSourcePallet.Enabled = false;
            btnLoadUnloadPallet.Text = "Unload";
            UpdateSpriteIndexes();
        }

        private void UnloadPallet()
        {
            tbSourcePallet.Enabled = true;
            pallet = null;
            btnLoadUnloadPallet.Text = "Load";

            cbNewIndexes.Items.Clear();
            cbNewIndexes.Enabled = false;
        }

        private bool LoadFromDirectory(string path, int amount)
        {
            //MessageBox.Show("Loading from directory \"" + path + "\"", MessageCaption);
            return LoadFromFiles(Directory.GetFiles(path, "*.bmp"), null, amount);
        }

        private bool LoadFromFiles(string[] files, int[] validFiles, int amount)
        {
            Color [] pallet = SpriteCreator.PalletFile.Get(pathSrcPallet);
            string[] filesToLoad;
            if (files.Length != amount)
            {
                filesToLoad = new string[amount];
                Array.Copy(files, filesToLoad, amount);
            }
            else
            {
                filesToLoad = files;
            }
            int[] indexes = SpriteHandler.ConvertImagesFromFiles(
                filesToLoad, 
                pallet, 
                region, 
                lookupTag
                );

            if (indexes.Length > 0)
            {
                sessionIndexOnCreate = createRefIndex;
                sessionRef.AddRange(indexes);
                UpdateSpriteIndexes();
            }

            return true;
        }


        ////////////////////////////////////////
        // helpers
        ////////////////////////////////////////


        private void UpdateSrcDirText(string newText)
        {
            tbSourceDirectory.TextChanged -= OnSrcDirTextChanged;
            tbSourceDirectory.Text = newText;
            tbSourceDirectory.TextChanged += OnSrcDirTextChanged;
        }

        private void UpdateSrcFileText(string newText)
        {

            tbSourceFile.TextChanged -= OnSrcFileTextChanged;
            tbSourceFile.Text = newText;
            tbSourceFile.TextChanged += OnSrcFileTextChanged;
        }

        ////////////////////////////////////////
        // control events
        ////////////////////////////////////////

        private void OnAddLookup(object sender, EventArgs e)
        {
            CreateLookup cl = new CreateLookup();

            if (cl.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                cbLookupTag.Items.Add(cl.NewTag.Tag);

                lookupIndex = LookupTagGuide.LookupTags.Count - 1;
                cbLookupTag.SelectedIndex = lookupIndex;

            }
        }

        private void OnAddRegion(object sender, EventArgs e)
        {
            CreateRegion cr = new CreateRegion();

            if(cr.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                cbTargetRegion.Items.Add(cr.NewRegion.Tag);

                regionIndex = SpriteRegionGuide.SpriteRegions.Count;
                cbTargetRegion.SelectedIndex = regionIndex;
            }
        }

        private void OnAddRefClick(object sender, EventArgs e)
        {
            CreateSessionRef csr = new CreateSessionRef();

            if (csr.ShowDialog() == DialogResult.OK)
            {
                cbSessionRef.Items.Add(csr.SessionReference.Name);
                cbSessionRef.SelectedIndex = cbSessionRef.Items.Count-1;
                createRefIndex = cbSessionRef.SelectedIndex;
            }
        }

        private void OnChangeSessionRef(object sender, EventArgs e)
        {
            createRefIndex = cbSessionRef.SelectedIndex;
            UpdateSessionRefSelect();
        }

        private void OnTargetRegionChanged(object sender, EventArgs e)
        {
            regionIndex = cbTargetRegion.SelectedIndex;
            UpdateSpriteRegionSelect();
        }

        private void OnLookupTagChanged(object sender, EventArgs e)
        {
            lookupIndex = cbLookupTag.SelectedIndex;
            UpdateLookupTagSelect();
        }

        private void OnSelectSourcePallet(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {

                ofd.Filter = "ACT Files (*.act)|*.act";
                ofd.FilterIndex = 1;

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    tbSourcePallet.Text = ofd.FileName;
                    pathSrcPallet = tbSourcePallet.Text;

                    LoadPallet();
                }
            }
        }

        private void OnSelectSourceFile(object sender, EventArgs e)
        {

            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Multiselect = true;
                ofd.Filter = "All Files (*.*) |*.*";
                ofd.FilterIndex = 1;

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    srcFiles = ofd.FileNames;
                    if (srcFiles.Length > 1)
                    {
                        UpdateSrcFileText("Multiple Files Selected");
                    }
                    else
                    {

                        UpdateSrcFileText(srcFiles[0]);
                    }

                    pathSrcDir = "";
                    UpdateSrcDirText("");
                }
            }
        }

        private void OnSelectSourceDir(object sender, EventArgs e)
        {
            using (FolderBrowserDialog dialog = new FolderBrowserDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    pathSrcDir = dialog.SelectedPath;
                    UpdateSrcDirText(pathSrcDir);

                    srcFiles = null;
                    UpdateSrcFileText("");
                }
            }
        }

        private void OnSrcPalletTextChanged(object sender, EventArgs e)
        {
            pathSrcPallet = tbSourcePallet.Text.Trim();
        }

        private void OnSrcFileTextChanged(object sender, EventArgs e)
        {
            string newText = tbSourceFile.Text.Trim();

            if (newText == "")
            {
                srcFiles = null;
                return;
            }

            if (srcFiles == null || srcFiles.Length > 1)
            {
                srcFiles = new string[] { newText };
            }
            else
            {
                srcFiles[0] = newText;
            }

            UpdateSrcDirText("");
        }

        private void OnSrcDirTextChanged(object sender, EventArgs e)
        {
            pathSrcDir = tbSourceDirectory.Text.Trim();

            if (pathSrcDir != "")
            {
                UpdateSrcFileText("");
            }
        }
        private void OnClickLoadSprites(object sender, EventArgs e)
        {
            int currIndex = cbNewIndexes.Items.Count;

            if (AttemptLoad())
            {
                newIndexesIndex = currIndex;
                cbNewIndexes.SelectedIndex = currIndex;
                UpdateSpriteIndexSelect();
               
            }
        }

        private void OnSelectNewIndex(object sender, EventArgs e)
        {
            newIndexesIndex = cbNewIndexes.SelectedIndex;
            UpdateSpriteIndexSelect();
        }

        private void OnRemoveNewIndex(object sender, EventArgs e)
        {
            bool deleted = SpriteHandler.RemoveSprite(sessionRef.Indexes[newIndexesIndex]) == 1;

            if (!deleted)
            {
                MessageBox.Show("No sprites removed", MessageCaption);
                return;
            }

            sessionRef.RemoveAtPosition(newIndexesIndex);
            cbNewIndexes.Items.RemoveAt(newIndexesIndex);

            if (UpdateEnableSpriteIndexes())
            {
                if (newIndexesIndex >= cbNewIndexes.Items.Count)
                {
                    newIndexesIndex = cbNewIndexes.Items.Count - 1;
                }

                cbNewIndexes.SelectedIndex = newIndexesIndex;
            }
            else
            {
                newIndexesIndex = -1;
                sessionIndexOnCreate = -1;
            }

            UpdateSpriteIndexSelect();
        }

        private void OnShown(object sender, EventArgs e)
        {
            viewer.Show();
        }



        ////////////////////////////////////////
        // debugging
        ////////////////////////////////////////

        private void button2_Click(object sender, EventArgs e)
        {
        }

        private void OnClickLoadUnload(object sender, EventArgs e)
        {
            if (pallet == null)
            {
                // validate source pallet
                if (pathSrcPallet == "")
                {
                    MessageBox.Show("Please enter a source pallet", MessageCaption);
                    return;
                }


                if (!File.Exists(pathSrcPallet))
                {
                    MessageBox.Show("File does not exist for source pallet", MessageCaption);
                    return;
                }

               LoadPallet();
            }
            else
            {
                UnloadPallet();
            }
        }

        private void OnFormClosing(object sender, FormClosingEventArgs e)
        {
            if (todaysRef.Name == sessionRef.Name && sessionRef.Indexes.Length == 0 || todaysRef.Indexes.Length == 0)
            {
                SpriteSessionGuide.RemoveSessionRef(todaysRefIndex);
                if (newIndexesIndex > todaysRefIndex)
                    newIndexesIndex -= 1;
            }

            if (viewer.Visible)
                viewer.Close();
        }




    }
}
