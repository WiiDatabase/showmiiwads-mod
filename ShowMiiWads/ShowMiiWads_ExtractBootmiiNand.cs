using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace ShowMiiWads
{
    public partial class ShowMiiWads_ExtractBootmiiNand : Form
    {
        private Thread nandExtractThread = null;
        private Wii.NandExtract nandExtract = null;

        private delegate void objectInvoker(object obj);

        public ShowMiiWads_ExtractBootmiiNand()
        {
            InitializeComponent();

            this.pbExtract.Value = 0;
            this.lbExtractedFile.Text = "";
        }

        private void btNandFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialogNandExtract = new OpenFileDialog();

            openFileDialogNandExtract.InitialDirectory = Application.StartupPath;
            openFileDialogNandExtract.Filter = "Bootmii NAND Dumps (*.bin)|*.bin";
            openFileDialogNandExtract.FilterIndex = 1;
            openFileDialogNandExtract.RestoreDirectory = true;
            openFileDialogNandExtract.CheckFileExists = true;

            if (openFileDialogNandExtract.ShowDialog() == DialogResult.OK)
            {
                this.tbNandFile.Text = openFileDialogNandExtract.FileName;
            }
        }

        private void btExtractToPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialogNandExtract = new FolderBrowserDialog();

            if (this.tbNandFile.Text.Length > 0)
            {
                folderBrowserDialogNandExtract.SelectedPath = Path.GetDirectoryName(this.tbNandFile.Text);
            }

            if (folderBrowserDialogNandExtract.ShowDialog() == DialogResult.OK)
            {
                this.tbExtractToPath.Text = folderBrowserDialogNandExtract.SelectedPath;
            }
        }

        private void btStartExtract_Click(object sender, EventArgs e)
        {
            if (this.tbNandFile.Text.Length > 0 && this.tbExtractToPath.Text.Length > 0)
            {
                this.btStartExtract.Enabled = false;

                nandExtract = new Wii.NandExtract(this.tbNandFile.Text, this.tbExtractToPath.Text);

                nandExtract.Debug += new EventHandler<Wii.MessageEventArgs>(nandExtract_Debug);
                nandExtract.Error += new EventHandler<Wii.MessageEventArgs>(nandExtract_Error);
                nandExtract.Progress += new EventHandler<Wii.ProgressChangedEventArgs>(nandExtract_Progress);
                nandExtract.ThreadFinish += new EventHandler<Wii.ThreadFinishEventArgs>(nandExtract_ThreadFinish);

                // Create and start new thread
                this.nandExtractThread = new Thread(new ThreadStart(nandExtract.extractNAND));
                this.nandExtractThread.Start();
            }
            else
            {
                this.ErrorMessageBox("Please select nand path and destination folder");
            }
        }

        private void nandExtract_ThreadFinish(object sender, Wii.ThreadFinishEventArgs e)
        {
            if (this.InvokeRequired)
            {
                objectInvoker v = new objectInvoker(this.EndThread);
                this.Invoke(v, e.IsThreadInterrupted);
            }
            else
            {
                this.EndThread(e.IsThreadInterrupted);
            }
        }

        private void EndThread(object isInterrupted)
        {
            if (!(bool)isInterrupted)
            {
                MessageBox.Show("NAND extracted successfully !!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.nandExtractThread = null;
                this.Close();
            }
            else
            {
                MessageBox.Show("Extraction interrupted !!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                nandExtract.Debug -= new EventHandler<Wii.MessageEventArgs>(nandExtract_Debug);
                nandExtract.Error -= new EventHandler<Wii.MessageEventArgs>(nandExtract_Error);
                nandExtract.Progress -= new EventHandler<Wii.ProgressChangedEventArgs>(nandExtract_Progress);
                nandExtract.ThreadFinish -= new EventHandler<Wii.ThreadFinishEventArgs>(nandExtract_ThreadFinish);

                this.btStartExtract.Enabled = true;
                this.pbExtract.Value = 0;
                this.lbExtractedFile.Text = "";
                this.nandExtractThread = null;
            }
        }

        private void nandExtract_Progress(object sender, Wii.ProgressChangedEventArgs e)
        {
            objectInvoker v = new objectInvoker(this.UpdateProgress);
            this.Invoke(v, e.PercentProgress);
        }

        private void UpdateProgress(object value)
        {
            this.pbExtract.Value = (int)value;
        }

        private void nandExtract_Error(object sender, Wii.MessageEventArgs e)
        {
            objectInvoker v = new objectInvoker(this.ErrorMessageBox);
            this.Invoke(v, e.Message);
        }

        private void ErrorMessageBox(object message)
        {
            MessageBox.Show((string)message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        void nandExtract_Debug(object sender, Wii.MessageEventArgs e)
        {
            objectInvoker v = new objectInvoker(this.UpdateLabel);
            this.Invoke(v, e.Message);
        }

        private void UpdateLabel(object message)
        {
            this.lbExtractedFile.Text = (string)message;
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            if (this.nandExtractThread != null && this.nandExtractThread.IsAlive)
            {
                this.nandExtractThread.Abort();
            }
            else
            {
                this.Close();
            }
        }
    }
}
