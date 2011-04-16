/* This file is part of ShowMiiWads mod by orwel
 * Copyright (C) 2011 orwel
 * 
 * ShowMiiWads is free software: you can redistribute it and/or
 * modify it under the terms of the GNU General Public License as published
 * by the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * ShowMiiWads is distributed in the hope that it will be
 * useful, but WITHOUT ANY WARRANTY; without even the implied warranty
 * of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this program.  If not, see <http://www.gnu.org/licenses/>.
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using libWiiSharp;
using System.Threading;
using System.IO;
using InputBoxes;

namespace ShowMiiWads
{
    public partial class ShowMiiWads_BuildNandFromScratch : Form
    {
        private bool isLocked;
        private NusClient nusClient;
        private Thread nusWorkerThread;
        private delegate void objectInvoker(object obj);
        private delegate void resetFormInvoker();
        private bool isStopRequired;

        private string sysMenu;
        private string wiiSerialNumber;
        private string nandPath;
        private bool fullNand;

        public ShowMiiWads_BuildNandFromScratch()
        {
            isLocked = false;
            nusClient = new NusClient();
            nusWorkerThread = null;
            isStopRequired = false;

            InitializeComponent();

            this.cbSysMenu.Items.AddRange(new object[] { "4.3E", "4.3J", "4.3U", "4.2E", "4.2J", "4.2U" });
            this.tsslInfoDl.Text = "";
            this.pbProgressBuildNand.Value = 0;
            this.pbGlobal.Value = 0;
            this.rtbOutput.Hide();

            nusClient.Debug += new EventHandler<MessageEventArgs>(nusClient_Debug);
            nusClient.Progress += new EventHandler<ProgressChangedEventArgs>(nusClient_Progress);
            Wii.Tools.ProgressChanged += new EventHandler<Wii.ProgressChangedEventArgs>(wadExtract_Progress);
        }

        private void ShowMiiWads_BuildNandFromScratch_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.nusWorkerThread != null && this.nusWorkerThread.IsAlive)
            {
                nusClient.Debug -= new EventHandler<MessageEventArgs>(nusClient_Debug);
                nusClient.Progress -= new EventHandler<ProgressChangedEventArgs>(nusClient_Progress);
                Wii.Tools.ProgressChanged -= new EventHandler<Wii.ProgressChangedEventArgs>(wadExtract_Progress);

                // Hopefully close the thread....
                this.nusWorkerThread.Abort();
            }
        }

        #region User Events
        private void btnStart_Click(object sender, EventArgs e)
        {
            // Checking pre-condition
            if (this.cbSysMenu.SelectedIndex == -1 || String.IsNullOrEmpty(this.tbSaveAs.Text))
            {
                MessageBox.Show("Please, select a System Menu and path to extract !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Checking serial number
            if (!String.IsNullOrEmpty(this.tbSerialNumber.Text) && !SettingTxt.isValidSerialNumber(this.tbSerialNumber.Text.Replace(" ", "")))
            {
                MessageBox.Show("Invalid Wii Serial Number !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

                // Init and start thread
                this.LockUnlockForm();
                this.rtbOutput.Clear();
                this.ssBuildNand.Text = "";
                this.pbProgressBuildNand.Value = 0;
                this.pbGlobal.Value = 0;
                sysMenu = this.cbSysMenu.SelectedItem.ToString();
                wiiSerialNumber = this.tbSerialNumber.Text.Replace(" ", "");
                nandPath = this.tbSaveAs.Text;
                fullNand = this.rbFullNand.Checked;

                this.nusWorkerThread = new Thread(new ThreadStart(BuildNand));
                this.nusWorkerThread.Start();
        }

        private void nusClient_Progress(object sender, ProgressChangedEventArgs e)
        {
            objectInvoker v = new objectInvoker(this.updateProgress);
            this.Invoke(v, e.ProgressPercentage);
        }

        private void updateProgress(object newValue)
        {
            this.pbProgressBuildNand.Value = (int)newValue;
        }

        private void nusClient_Debug(object sender, MessageEventArgs e)
        {
            objectInvoker v = new objectInvoker(this.updateLog);
            this.Invoke(v, e.Message);
        }

        private void updateLog(object mes)
        {
            rtbOutput.Text += mes + "\n";

            if (((string)mes).ToLower().Contains("finished"))
                rtbOutput.Text += "\n";

            rtbOutput.SelectionStart = rtbOutput.Text.Length;
            rtbOutput.ScrollToCaret();
        }

        private void updateLabelLog(object mes)
        {
            this.tsslInfoDl.Text = (string)mes;
        }

        private void wadExtract_Progress(object sender, Wii.ProgressChangedEventArgs e)
        {
            objectInvoker v = new objectInvoker(this.updateProgress);
            this.Invoke(v, e.PercentProgress);
        }

        private void updateGlobalProgress(object value)
        {
            this.pbGlobal.Value = (int)value;
        }

        private void initGlobalProgress(object value)
        {
            this.pbGlobal.Maximum = (int)value;
        }

        private void btnSaveAs_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialogNandSaveAs = new FolderBrowserDialog();

            if (folderBrowserDialogNandSaveAs.ShowDialog() == DialogResult.OK)
            {
                this.tbSaveAs.Text = folderBrowserDialogNandSaveAs.SelectedPath;
            }
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            if (this.nusWorkerThread != null && this.nusWorkerThread.IsAlive)
            {
                this.isStopRequired = true;
                this.nusClient.IsStopRequired(true);
                this.tsslInfoDl.Text = "Stopping ! Please Wait";
            }
            else
            {
                nusClient.Debug -= new EventHandler<MessageEventArgs>(nusClient_Debug);
                nusClient.Progress -= new EventHandler<ProgressChangedEventArgs>(nusClient_Progress);
                Wii.Tools.ProgressChanged -= new EventHandler<Wii.ProgressChangedEventArgs>(wadExtract_Progress);
                this.Close();
            }
        }

        private void lbDetail_Click(object sender, EventArgs e)
        {
            if (this.rtbOutput.Visible)
            {
                this.rtbOutput.Hide();
                this.lbDetail.Text = "[+] More detail...";
            }
            else
            {
                this.rtbOutput.Show();
                this.lbDetail.Text = "[-] Less detail";
            }
        }
        #endregion

        private void LockUnlockForm()
        {
            if (!isLocked)
            {
                this.btnSaveAs.Enabled = false;
                this.btnStart.Enabled = false;
                this.btnQuit.Text = "Cancel";
                this.tbSaveAs.ReadOnly = true;
                this.tbSerialNumber.ReadOnly = true;
                this.cbSysMenu.Enabled = false;
                this.rbFullNand.Enabled = false;
                this.rbLightNand.Enabled = false;

                this.isLocked = true;
            }
            else
            {
                this.btnSaveAs.Enabled = true;
                this.btnStart.Enabled = true;
                this.btnQuit.Text = "Quit";
                this.tbSaveAs.ReadOnly = false;
                this.tbSerialNumber.ReadOnly = false;
                this.cbSysMenu.Enabled = true;
                this.rbFullNand.Enabled = true;
                this.rbLightNand.Enabled = true;

                this.isLocked = false;

                if (this.nusClient != null)
                    this.nusClient.IsStopRequired(false);

                this.isStopRequired = false;
            }
        }

        private void BuildNand()
        {
            // Deletage to fire current action description
            objectInvoker delegateMethodeLabelLog = new objectInvoker(this.updateLabelLog);
            objectInvoker delegateMethodeLog = new objectInvoker(this.updateLog);
            objectInvoker delegateMethodeGlobalProgress = new objectInvoker(this.initGlobalProgress);

            // IOS list
            List<string[]> titleList = new List<string[]>();

            // Temp directory
            string tmpPath = Path.GetTempPath();

            // System Menu and his IOS.
            switch (this.sysMenu)
            {
                case "4.2J":
                    // System Menu
                    titleList.Add(new string[2] { "0000000100000002", "480" });
                    // IOS70
                    titleList.Add(new string[2] { "0000000100000046", "6944" });
                    break;
                case "4.2U":
                    // System Menu
                    titleList.Add(new string[2] { "0000000100000002", "481" });
                    // IOS70
                    titleList.Add(new string[2] { "0000000100000046", "6944" });
                    break;
                case "4.2E":
                    // System Menu
                    titleList.Add(new string[2] { "0000000100000002", "482" });
                    // IOS70
                    titleList.Add(new string[2] { "0000000100000046", "6944" });
                    break;
                case "4.3J":
                    // System Menu
                    titleList.Add(new string[2] { "0000000100000002", "512" });
                    // IOS80
                    titleList.Add(new string[2] { "0000000100000050", "6944" });
                    break;
                case "4.3U":
                    // System Menu
                    titleList.Add(new string[2] { "0000000100000002", "513" });
                    // IOS80
                    titleList.Add(new string[2] { "0000000100000050", "6944" });
                    break;
                case "4.3E":
                    // System Menu
                    titleList.Add(new string[2] { "0000000100000002", "514" });
                    // IOS80
                    titleList.Add(new string[2] { "0000000100000050", "6944" });
                    break;
                default:
                    throw new Exception("Invalid System Menu !!");
            }

            // Full list of usefull IOS
            if (this.fullNand)
            {
                // IOS28
                titleList.Add(new string[2] { "000000010000001C", "1807" });
                // IOS31
                titleList.Add(new string[2] { "000000010000001F", "3608" });
                // IOS33
                titleList.Add(new string[2] { "0000000100000021", "3608" });
                // IOS34
                titleList.Add(new string[2] { "0000000100000022", "3608" });
                // IOS35
                titleList.Add(new string[2] { "0000000100000023", "3608" });
                // IOS36
                titleList.Add(new string[2] { "0000000100000024", "3608" });
                // IOS37
                titleList.Add(new string[2] { "0000000100000025", "5663" });
                // IOS38
                titleList.Add(new string[2] { "0000000100000026", "4124" });
                // IOS53
                titleList.Add(new string[2] { "0000000100000035", "5663" });
                // IOS55
                titleList.Add(new string[2] { "0000000100000037", "5663" });
                // IOS56
                titleList.Add(new string[2] { "0000000100000038", "5662" });
                // IOS57
                titleList.Add(new string[2] { "0000000100000039", "5919" });
                // IOS61
                titleList.Add(new string[2] { "000000010000003D", "5662" });
            }

            IAsyncResult r = this.BeginInvoke(delegateMethodeGlobalProgress, ((titleList.Count * 2) + 1));
            this.EndInvoke(r);

            delegateMethodeGlobalProgress = new objectInvoker(this.updateGlobalProgress);

            try
            {
                int cptProgress = 0;

                foreach (string[] title in titleList)
                {
                    string currentWadFileName = String.Format("{0}v{1}.wad", title[0], title[1]);

                    if (!isStopRequired)
                    {

                        if (title[0] == "0000000100000002")
                        {
                            this.Invoke(delegateMethodeLabelLog, "Downloading System Menu " + this.sysMenu);
                        }
                        else
                        {
                            this.Invoke(delegateMethodeLabelLog, "Downloading IOS" + Wii.Tools.HexStringToInt(title[0].Substring(8)) + "v" + title[1]);
                        }

                        nusClient.DownloadTitle(title[0], title[1], tmpPath, StoreType.WAD);

                        cptProgress++;
                        this.Invoke(delegateMethodeGlobalProgress, cptProgress);
                    }
                    else
                    {
                        break;
                    }

                    if (!isStopRequired)
                    {
                        this.Invoke(delegateMethodeLabelLog, "Installing Downloaded File");
                        this.Invoke(delegateMethodeLog, "Installing Downloaded File");

                        Wii.WadUnpack.UnpackToNand(tmpPath + currentWadFileName, this.nandPath);
                    }
                    else
                    {
                        break;
                    }

                    if (!isStopRequired)
                    {
                        this.Invoke(delegateMethodeLabelLog, "Delete Temporary Downloaded File");
                        this.Invoke(delegateMethodeLog, "Delete Temporary Downloaded File");

                        File.Delete(tmpPath + currentWadFileName);

                        cptProgress++;
                        this.Invoke(delegateMethodeGlobalProgress, cptProgress);
                    }
                    else
                    {
                        break;
                    }
                }

                if (!isStopRequired)
                {
                    this.Invoke(delegateMethodeLabelLog, "Generate setting.txt");
                    this.Invoke(delegateMethodeLog, "Generate setting.txt");

                    SettingTxt.GenerateFile(this.wiiSerialNumber, this.sysMenu[3].ToString(),
                        this.nandPath + Path.DirectorySeparatorChar + "title" + Path.DirectorySeparatorChar + "00000001" +
                        Path.DirectorySeparatorChar + "00000002" + Path.DirectorySeparatorChar + "data");

                    cptProgress++;
                    this.Invoke(delegateMethodeGlobalProgress, cptProgress);
                }

                if (!isStopRequired)
                {
                    this.Invoke(delegateMethodeLabelLog, "Build successfull !");
                    this.Invoke(delegateMethodeLog, "Build successfull !");
                }
                else
                {
                    this.Invoke(delegateMethodeLabelLog, "Build aborted !");
                    this.Invoke(delegateMethodeLog, "Build aborted !");
                }
            }
            catch (Exception ex)
            {
                if (this.IsHandleCreated)
                {
                    this.Invoke(delegateMethodeLabelLog, ex.Message);
                    this.Invoke(delegateMethodeLog, "Build aborted !");
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            finally
            {
                if (this.IsHandleCreated)
                {
                    resetFormInvoker rst = new resetFormInvoker(this.LockUnlockForm);
                    this.Invoke(rst);
                }
            }
        }
    }
}
