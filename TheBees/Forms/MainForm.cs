using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

using TheBees.Sound;

namespace TheBees.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            //OnClickModifyCommands(null, null);

            EnableForm(Globals.RomLoaded);

            if (Settings.AutoLoad)
            {
                //LoadDirectory(Settings.RomSource);
            }

        }

        private void EnableForm(bool enable = true)
        {
            btnEditSAEffect.Enabled = enable;
            btnModifyCharacter.Enabled = enable;
            btnModifyCommands.Enabled = enable;
            btnModifyPallets.Enabled = enable;
            btnModifyProjectileDef.Enabled = enable;
            btnSave.Enabled = enable;
        }

        private void OnClickModifyChar(object sender, EventArgs e)
        {            
            LoadForm(new ModifyAction());
        }

        private void OnClickModifyMissile(object sender, EventArgs e)
        {
            //ModifyMissileAction modifyAction = new ModifyMissileAction();
            //modifyAction.Show();
        }

        private void OnClickModifyMissileConfig(object sender, EventArgs e)
        {
            LoadForm(new ModifyMissile());
        }

        private void OnClickSaveChanges(object sender, EventArgs e)
        {
            SaveHandler.SaveRom(Settings.RomTarget, RomType.COMBINED);
        }

        private void OnClickModifyCommands(object sender, EventArgs e)
        {
            LoadForm(new ModifyCommand());
        }

        private void OnClickEditSuperArt(object sender, EventArgs e)
        {
            LoadForm(new ModifySAEffect());
        }

        private void OnModifyPalletsSprites(object sender, EventArgs e)
        {
            LoadForm(new ModifyCharacterPallet());
        }

        private void LoadForm(Form formLoad)
        {
            this.Hide();
            //RecordSummary summary = new RecordSummary();
            //summary.Show(formLoad);
            formLoad.ShowDialog(this);
            this.Show();
            //formLoad.FormClosed += (o, e) => { this.Show(); };
        }

        private void OpenFile()
        {
        }

        private void OnLoad()
        {
            EnableForm();
        }

        private void OnCloseRom()
        {
            if (BaseDataHandler.Close())
            {
                EnableForm(false);
            }
            else
            {
                MessageBox.Show("Error closing rom", "Close Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

           
        }
        private void LoadDirectory(string path)
        {

            if (LoadHandler.CheckDirValid(path, RomType.COMBINED))
            {
                LoadHandler.LoadData(path, RomType.COMBINED);
                OnLoad();
            }
            else if (LoadHandler.CheckDirValid(path, RomType.SEPARATED))
            {
                LoadHandler.LoadData(path, RomType.SEPARATED);
                OnLoad();
            }
            else
            {
                MessageBox.Show("No valid rom set found", "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OpenDirectory()
        {
            try
            {
                FolderBrowserDialog fbd = new FolderBrowserDialog();
                fbd.SelectedPath = Settings.RomSource;
                DialogResult result = fbd.ShowDialog();

                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    LoadDirectory(fbd.SelectedPath + @"\");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void OnMenuSave(object sender, EventArgs e)
        {
            SaveHandler.SaveRom(Settings.RomTarget, Globals.LoadedType);
        }

        private void OnMenuExit(object sender, EventArgs e)
        {
            Close();
        }

        private void OnMenuOpenFile(object sender, EventArgs e)
        {
            OpenFile();
        }

        private void OnMenuOpenDirectory(object sender, EventArgs e)
        {
            OpenDirectory();
        }

        private void OnMenuClose(object sender, EventArgs e)
        {
            OnCloseRom();
        }

        private void OnMenuFileOpening(object sender, EventArgs e)
        {
            menuItemClose.Enabled = Globals.RomLoaded;
            menuItemSave.Enabled = Globals.RomLoaded;
        }

        private void OnShown(object sender, EventArgs e)
        {
            //LoadForm(new ModifyAction());
        }

        private void OnClickEditThrownOpponent(object sender, EventArgs e)
        {
            LoadForm(new ThrownOpponent());
        }

        private void OnClickEditSupportGfx(object sender, EventArgs e)
        {

            LoadForm(new SupportGraphics());
        }

        private void OnGenerateStaticDescriptor(object sender, EventArgs e)
        {
        }

        private void OnModifyOrbital(object sender, EventArgs e)
        {
            LoadForm(new ModifyOrbitalBasis());
        }

        private void OnModifyEnemyCtrl(object sender, EventArgs e)
        {
            LoadForm(new ModifyEnemyCtrl());
        }

        ////////////////////////////////////////
        // debugging
        ////////////////////////////////////////

        private void OnBtnReloadAll(object sender, EventArgs e)
        {
            BaseDataHandler.Close();
            LoadDirectory(Settings.RomSource);

        }

        private void OnBtnRestoreBaseRom(object sender, EventArgs e)
        {
            RomUtilities.RestoreBase();            
        }



        private void OnClickDebug(object sender, EventArgs e)
        {
        }

        private void OnDebugToo(object sender, EventArgs e)
        {
            Debugging.DoSomethingElse();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            /*
            TheBees.Records.SpriteRecord.LoadAllSpriteDefs();
            TheBees.Records.SpriteRecord.ClearAllSpriteDefs();
            int nonZeroCount = TheBees.Records.SpriteRecord.CheckZeroData();
            MessageBox.Show("Non Zero Count: " + nonZeroCount.ToString(), "Non Zero");
            */

            Debugging.GetRanges();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Debugging.GetLookupValues();
        }

        private void OnClickModifySounds(object sender, EventArgs e)
        {
            LoadForm(new SoundEffectManager());
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var aboutForm = new AboutForm();
            aboutForm.ShowDialog();
        }
    }
}
