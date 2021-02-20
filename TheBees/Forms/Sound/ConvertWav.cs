using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

using TheBees.Sound;


namespace TheBees.Forms
{
    public partial class ConvertWav : Form
    {
        public byte [] NewSampleBytes;
        private string srcFile = "";
        private const string tempFilename = "TheBees_sample.raw";

        public ConvertWav()
        {
            InitializeComponent();

            btnConvert.Enabled = false;
            btnOK.Enabled = false;
        }

        private void OnClickSelectFile(object sender, EventArgs e)
        {
            NewSampleBytes = null;

            OpenFileDialog ofd = new OpenFileDialog();

            ofd.Filter = "WAV Files (*.wav)|*.wav";
            ofd.FilterIndex = 1;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                srcFile = ofd.FileName;

                btnConvert.Enabled = true;
                btnOK.Enabled = false;
            }
        }

        

        private void OnClickOK(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void OnClickCancel(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void OnConvert(object sender, EventArgs e)
        {
            string tempPath = Path.GetTempPath();

            if (File.Exists(tempPath + tempFilename))
            {
                File.Delete(tempPath + tempFilename);
            }
            // use shell to convert the file
            Process p = new Process();

            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            //p.StartInfo.CreateNoWindow = true;
            p.StartInfo.FileName = "sox";
            p.StartInfo.Arguments = "\"" + srcFile + "\" -r 12000 -e signed -b 8 -c 1 \"" + tempPath + tempFilename + "\"";

            try
            {
                p.Start();

                //p.StandardOutput.ReadToEnd();
                p.WaitForExit();

            }
            catch (Win32Exception)
            {
                MessageBox.Show("Error Converting File");
            }

            // complete
            // get raw file

            byte [] rawBytes = File.ReadAllBytes(tempPath+tempFilename);

            // for debugging purposes
            File.WriteAllBytes(@"C:\testRawFile", rawBytes);
            File.Delete(tempPath + tempFilename);

            NewSampleBytes = rawBytes;

            btnOK.Enabled = true;
            btnConvert.Enabled = false;
        }
    }
}
