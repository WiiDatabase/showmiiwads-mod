namespace ShowMiiWads
{
    partial class ShowMiiWads_BuildNandFromScratch
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.ssBuildNand = new System.Windows.Forms.StatusStrip();
            this.pbProgressBuildNand = new System.Windows.Forms.ToolStripProgressBar();
            this.tsslInfoDl = new System.Windows.Forms.ToolStripStatusLabel();
            this.gbOption = new System.Windows.Forms.GroupBox();
            this.lbPathToStore = new System.Windows.Forms.Label();
            this.btnSaveAs = new System.Windows.Forms.Button();
            this.tbSaveAs = new System.Windows.Forms.TextBox();
            this.rbFullNand = new System.Windows.Forms.RadioButton();
            this.rbLightNand = new System.Windows.Forms.RadioButton();
            this.lbSerial = new System.Windows.Forms.Label();
            this.tbSerialNumber = new System.Windows.Forms.TextBox();
            this.lbSysMenu = new System.Windows.Forms.Label();
            this.cbSysMenu = new System.Windows.Forms.ComboBox();
            this.rtbOutput = new System.Windows.Forms.RichTextBox();
            this.lbDetail = new System.Windows.Forms.Label();
            this.btnQuit = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.pbGlobal = new System.Windows.Forms.ProgressBar();
            this.lbGlobalProgress = new System.Windows.Forms.Label();
            this.gbAction = new System.Windows.Forms.GroupBox();
            this.ssBuildNand.SuspendLayout();
            this.gbOption.SuspendLayout();
            this.gbAction.SuspendLayout();
            this.SuspendLayout();
            // 
            // ssBuildNand
            // 
            this.ssBuildNand.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pbProgressBuildNand,
            this.tsslInfoDl});
            this.ssBuildNand.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.ssBuildNand.Location = new System.Drawing.Point(0, 460);
            this.ssBuildNand.Name = "ssBuildNand";
            this.ssBuildNand.Size = new System.Drawing.Size(442, 22);
            this.ssBuildNand.SizingGrip = false;
            this.ssBuildNand.TabIndex = 0;
            this.ssBuildNand.Text = "statusStrip1";
            // 
            // pbProgressBuildNand
            // 
            this.pbProgressBuildNand.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.pbProgressBuildNand.Name = "pbProgressBuildNand";
            this.pbProgressBuildNand.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.pbProgressBuildNand.Size = new System.Drawing.Size(100, 16);
            this.pbProgressBuildNand.Step = 1;
            this.pbProgressBuildNand.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pbProgressBuildNand.Value = 100;
            // 
            // tsslInfoDl
            // 
            this.tsslInfoDl.Name = "tsslInfoDl";
            this.tsslInfoDl.Size = new System.Drawing.Size(70, 17);
            this.tsslInfoDl.Text = "Download...";
            // 
            // gbOption
            // 
            this.gbOption.AutoSize = true;
            this.gbOption.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.gbOption.Controls.Add(this.lbPathToStore);
            this.gbOption.Controls.Add(this.btnSaveAs);
            this.gbOption.Controls.Add(this.tbSaveAs);
            this.gbOption.Controls.Add(this.rbFullNand);
            this.gbOption.Controls.Add(this.rbLightNand);
            this.gbOption.Controls.Add(this.lbSerial);
            this.gbOption.Controls.Add(this.tbSerialNumber);
            this.gbOption.Controls.Add(this.lbSysMenu);
            this.gbOption.Controls.Add(this.cbSysMenu);
            this.gbOption.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbOption.Location = new System.Drawing.Point(0, 0);
            this.gbOption.Name = "gbOption";
            this.gbOption.Size = new System.Drawing.Size(442, 172);
            this.gbOption.TabIndex = 1;
            this.gbOption.TabStop = false;
            this.gbOption.Text = "Options";
            // 
            // lbPathToStore
            // 
            this.lbPathToStore.AutoSize = true;
            this.lbPathToStore.Location = new System.Drawing.Point(13, 114);
            this.lbPathToStore.Name = "lbPathToStore";
            this.lbPathToStore.Size = new System.Drawing.Size(102, 13);
            this.lbPathToStore.TabIndex = 11;
            this.lbPathToStore.Text = "Path to store Nand :";
            // 
            // btnSaveAs
            // 
            this.btnSaveAs.Location = new System.Drawing.Point(372, 130);
            this.btnSaveAs.Name = "btnSaveAs";
            this.btnSaveAs.Size = new System.Drawing.Size(54, 23);
            this.btnSaveAs.TabIndex = 10;
            this.btnSaveAs.Text = "Open...";
            this.btnSaveAs.UseVisualStyleBackColor = true;
            this.btnSaveAs.Click += new System.EventHandler(this.btnSaveAs_Click);
            // 
            // tbSaveAs
            // 
            this.tbSaveAs.Location = new System.Drawing.Point(16, 130);
            this.tbSaveAs.Name = "tbSaveAs";
            this.tbSaveAs.Size = new System.Drawing.Size(349, 20);
            this.tbSaveAs.TabIndex = 9;
            // 
            // rbFullNand
            // 
            this.rbFullNand.AutoSize = true;
            this.rbFullNand.Checked = true;
            this.rbFullNand.Location = new System.Drawing.Point(16, 63);
            this.rbFullNand.Name = "rbFullNand";
            this.rbFullNand.Size = new System.Drawing.Size(116, 17);
            this.rbFullNand.TabIndex = 3;
            this.rbFullNand.TabStop = true;
            this.rbFullNand.Text = "Full Nand (~70 Mb)";
            this.rbFullNand.UseVisualStyleBackColor = true;
            // 
            // rbLightNand
            // 
            this.rbLightNand.AutoSize = true;
            this.rbLightNand.Location = new System.Drawing.Point(16, 86);
            this.rbLightNand.Name = "rbLightNand";
            this.rbLightNand.Size = new System.Drawing.Size(135, 17);
            this.rbLightNand.TabIndex = 6;
            this.rbLightNand.Text = "Minimal Nand (~65 Mb)";
            this.rbLightNand.UseVisualStyleBackColor = true;
            // 
            // lbSerial
            // 
            this.lbSerial.AutoSize = true;
            this.lbSerial.Location = new System.Drawing.Point(243, 17);
            this.lbSerial.Name = "lbSerial";
            this.lbSerial.Size = new System.Drawing.Size(91, 13);
            this.lbSerial.TabIndex = 5;
            this.lbSerial.Text = "Wii Serial Number";
            // 
            // tbSerialNumber
            // 
            this.tbSerialNumber.Location = new System.Drawing.Point(243, 36);
            this.tbSerialNumber.Name = "tbSerialNumber";
            this.tbSerialNumber.Size = new System.Drawing.Size(165, 20);
            this.tbSerialNumber.TabIndex = 4;
            // 
            // lbSysMenu
            // 
            this.lbSysMenu.AutoSize = true;
            this.lbSysMenu.Location = new System.Drawing.Point(13, 20);
            this.lbSysMenu.Name = "lbSysMenu";
            this.lbSysMenu.Size = new System.Drawing.Size(71, 13);
            this.lbSysMenu.TabIndex = 1;
            this.lbSysMenu.Text = "System Menu";
            // 
            // cbSysMenu
            // 
            this.cbSysMenu.FormattingEnabled = true;
            this.cbSysMenu.Location = new System.Drawing.Point(16, 36);
            this.cbSysMenu.Name = "cbSysMenu";
            this.cbSysMenu.Size = new System.Drawing.Size(121, 21);
            this.cbSysMenu.TabIndex = 0;
            // 
            // rtbOutput
            // 
            this.rtbOutput.BackColor = System.Drawing.SystemColors.HighlightText;
            this.rtbOutput.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.rtbOutput.Location = new System.Drawing.Point(0, 285);
            this.rtbOutput.Name = "rtbOutput";
            this.rtbOutput.ReadOnly = true;
            this.rtbOutput.Size = new System.Drawing.Size(442, 175);
            this.rtbOutput.TabIndex = 2;
            this.rtbOutput.Text = "";
            // 
            // lbDetail
            // 
            this.lbDetail.AutoSize = true;
            this.lbDetail.Location = new System.Drawing.Point(12, 88);
            this.lbDetail.Name = "lbDetail";
            this.lbDetail.Size = new System.Drawing.Size(83, 13);
            this.lbDetail.TabIndex = 15;
            this.lbDetail.Text = "[+] More detail...";
            this.lbDetail.Click += new System.EventHandler(this.lbDetail_Click);
            // 
            // btnQuit
            // 
            this.btnQuit.Location = new System.Drawing.Point(349, 77);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(75, 23);
            this.btnQuit.TabIndex = 14;
            this.btnQuit.Text = "Quit";
            this.btnQuit.UseVisualStyleBackColor = true;
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(259, 77);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 13;
            this.btnStart.Text = "Start...";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // pbGlobal
            // 
            this.pbGlobal.Location = new System.Drawing.Point(16, 32);
            this.pbGlobal.Name = "pbGlobal";
            this.pbGlobal.Size = new System.Drawing.Size(409, 23);
            this.pbGlobal.Step = 1;
            this.pbGlobal.TabIndex = 16;
            this.pbGlobal.Value = 100;
            // 
            // lbGlobalProgress
            // 
            this.lbGlobalProgress.AutoSize = true;
            this.lbGlobalProgress.Location = new System.Drawing.Point(16, 16);
            this.lbGlobalProgress.Name = "lbGlobalProgress";
            this.lbGlobalProgress.Size = new System.Drawing.Size(81, 13);
            this.lbGlobalProgress.TabIndex = 17;
            this.lbGlobalProgress.Text = "Global Progress";
            // 
            // gbAction
            // 
            this.gbAction.Controls.Add(this.btnStart);
            this.gbAction.Controls.Add(this.lbGlobalProgress);
            this.gbAction.Controls.Add(this.btnQuit);
            this.gbAction.Controls.Add(this.pbGlobal);
            this.gbAction.Controls.Add(this.lbDetail);
            this.gbAction.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbAction.Location = new System.Drawing.Point(0, 172);
            this.gbAction.Name = "gbAction";
            this.gbAction.Size = new System.Drawing.Size(442, 106);
            this.gbAction.TabIndex = 18;
            this.gbAction.TabStop = false;
            // 
            // ShowMiiWads_BuildNandFromScratch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(442, 482);
            this.Controls.Add(this.gbAction);
            this.Controls.Add(this.rtbOutput);
            this.Controls.Add(this.gbOption);
            this.Controls.Add(this.ssBuildNand);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(447, 335);
            this.Name = "ShowMiiWads_BuildNandFromScratch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Build Nand From Scratch";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ShowMiiWads_BuildNandFromScratch_FormClosing);
            this.ssBuildNand.ResumeLayout(false);
            this.ssBuildNand.PerformLayout();
            this.gbOption.ResumeLayout(false);
            this.gbOption.PerformLayout();
            this.gbAction.ResumeLayout(false);
            this.gbAction.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip ssBuildNand;
        private System.Windows.Forms.ToolStripProgressBar pbProgressBuildNand;
        private System.Windows.Forms.GroupBox gbOption;
        private System.Windows.Forms.RadioButton rbFullNand;
        private System.Windows.Forms.RadioButton rbLightNand;
        private System.Windows.Forms.Label lbSerial;
        private System.Windows.Forms.TextBox tbSerialNumber;
        private System.Windows.Forms.Label lbSysMenu;
        private System.Windows.Forms.ComboBox cbSysMenu;
        private System.Windows.Forms.RichTextBox rtbOutput;
        private System.Windows.Forms.ToolStripStatusLabel tsslInfoDl;
        private System.Windows.Forms.Button btnSaveAs;
        private System.Windows.Forms.TextBox tbSaveAs;
        private System.Windows.Forms.Label lbPathToStore;
        private System.Windows.Forms.Label lbDetail;
        private System.Windows.Forms.Button btnQuit;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.ProgressBar pbGlobal;
        private System.Windows.Forms.Label lbGlobalProgress;
        private System.Windows.Forms.GroupBox gbAction;
    }
}