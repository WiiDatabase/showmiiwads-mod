/* This file is part of ShowMiiWads
 * Copyright (C) 2009 Leathl
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

namespace ShowMiiWads
{
    partial class ShowMiiWads_Preview
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.Panel = new System.Windows.Forms.Panel();
            this.cbLz77 = new System.Windows.Forms.CheckBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.cbIcon = new System.Windows.Forms.ComboBox();
            this.lbIcon = new System.Windows.Forms.Label();
            this.lbBanner = new System.Windows.Forms.Label();
            this.cbBanner = new System.Windows.Forms.ComboBox();
            this.cmPic = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmSave = new System.Windows.Forms.ToolStripMenuItem();
            this.cmSaveAll = new System.Windows.Forms.ToolStripMenuItem();
            this.cmBannerImages = new System.Windows.Forms.ToolStripMenuItem();
            this.cmIconImages = new System.Windows.Forms.ToolStripMenuItem();
            this.cmBothImages = new System.Windows.Forms.ToolStripMenuItem();
            this.sepReplace = new System.Windows.Forms.ToolStripSeparator();
            this.tsReplace = new System.Windows.Forms.ToolStripMenuItem();
            this.cmRGBA8 = new System.Windows.Forms.ToolStripMenuItem();
            this.cmRGB565 = new System.Windows.Forms.ToolStripMenuItem();
            this.cmRGB5A3 = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbFormat = new System.Windows.Forms.Label();
            this.lbFormatText = new System.Windows.Forms.Label();
            this.lbSize = new System.Windows.Forms.Label();
            this.lbSizeText = new System.Windows.Forms.Label();
            this.pbPic = new System.Windows.Forms.PictureBox();
            this.Panel.SuspendLayout();
            this.cmPic.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPic)).BeginInit();
            this.SuspendLayout();
            // 
            // Panel
            // 
            this.Panel.Controls.Add(this.cbLz77);
            this.Panel.Controls.Add(this.btnSave);
            this.Panel.Controls.Add(this.btnClose);
            this.Panel.Controls.Add(this.cbIcon);
            this.Panel.Controls.Add(this.lbIcon);
            this.Panel.Controls.Add(this.lbBanner);
            this.Panel.Controls.Add(this.cbBanner);
            this.Panel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Panel.Location = new System.Drawing.Point(0, 473);
            this.Panel.Name = "Panel";
            this.Panel.Size = new System.Drawing.Size(852, 28);
            this.Panel.TabIndex = 0;
            // 
            // cbLz77
            // 
            this.cbLz77.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cbLz77.AutoSize = true;
            this.cbLz77.Checked = true;
            this.cbLz77.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbLz77.Location = new System.Drawing.Point(397, 7);
            this.cbLz77.Name = "cbLz77";
            this.cbLz77.Size = new System.Drawing.Size(98, 17);
            this.cbLz77.TabIndex = 4;
            this.cbLz77.Text = "Lz77 Compress";
            this.cbLz77.UseVisualStyleBackColor = true;
            this.cbLz77.Visible = false;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(516, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(160, 21);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Close && Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(682, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(160, 21);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Close && Discard";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // cbIcon
            // 
            this.cbIcon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbIcon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbIcon.FormattingEnabled = true;
            this.cbIcon.Location = new System.Drawing.Point(239, 4);
            this.cbIcon.MaxDropDownItems = 20;
            this.cbIcon.Name = "cbIcon";
            this.cbIcon.Size = new System.Drawing.Size(121, 21);
            this.cbIcon.TabIndex = 1;
            this.cbIcon.SelectedIndexChanged += new System.EventHandler(this.cbIcon_SelectedIndexChanged);
            // 
            // lbIcon
            // 
            this.lbIcon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbIcon.AutoSize = true;
            this.lbIcon.Location = new System.Drawing.Point(203, 7);
            this.lbIcon.Name = "lbIcon";
            this.lbIcon.Size = new System.Drawing.Size(31, 13);
            this.lbIcon.TabIndex = 2;
            this.lbIcon.Text = "Icon:";
            // 
            // lbBanner
            // 
            this.lbBanner.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbBanner.AutoSize = true;
            this.lbBanner.Location = new System.Drawing.Point(3, 7);
            this.lbBanner.Name = "lbBanner";
            this.lbBanner.Size = new System.Drawing.Size(44, 13);
            this.lbBanner.TabIndex = 1;
            this.lbBanner.Text = "Banner:";
            // 
            // cbBanner
            // 
            this.cbBanner.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbBanner.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBanner.FormattingEnabled = true;
            this.cbBanner.Location = new System.Drawing.Point(51, 4);
            this.cbBanner.MaxDropDownItems = 20;
            this.cbBanner.Name = "cbBanner";
            this.cbBanner.Size = new System.Drawing.Size(121, 21);
            this.cbBanner.TabIndex = 0;
            this.cbBanner.SelectedIndexChanged += new System.EventHandler(this.cbBanner_SelectedIndexChanged);
            // 
            // cmPic
            // 
            this.cmPic.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmSave,
            this.cmSaveAll,
            this.sepReplace,
            this.tsReplace});
            this.cmPic.Name = "cmPic";
            this.cmPic.Size = new System.Drawing.Size(116, 76);
            // 
            // cmSave
            // 
            this.cmSave.Name = "cmSave";
            this.cmSave.Size = new System.Drawing.Size(115, 22);
            this.cmSave.Text = "Save";
            this.cmSave.Click += new System.EventHandler(this.cmSave_Click);
            // 
            // cmSaveAll
            // 
            this.cmSaveAll.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmBannerImages,
            this.cmIconImages,
            this.cmBothImages});
            this.cmSaveAll.Name = "cmSaveAll";
            this.cmSaveAll.Size = new System.Drawing.Size(115, 22);
            this.cmSaveAll.Text = "Save All";
            // 
            // cmBannerImages
            // 
            this.cmBannerImages.Name = "cmBannerImages";
            this.cmBannerImages.Size = new System.Drawing.Size(152, 22);
            this.cmBannerImages.Text = "Banner Images";
            this.cmBannerImages.Click += new System.EventHandler(this.btnBannerImages_Click);
            // 
            // cmIconImages
            // 
            this.cmIconImages.Name = "cmIconImages";
            this.cmIconImages.Size = new System.Drawing.Size(152, 22);
            this.cmIconImages.Text = "Icon Images";
            this.cmIconImages.Click += new System.EventHandler(this.btnIconImages_Click);
            // 
            // cmBothImages
            // 
            this.cmBothImages.Name = "cmBothImages";
            this.cmBothImages.Size = new System.Drawing.Size(152, 22);
            this.cmBothImages.Text = "Both";
            this.cmBothImages.Click += new System.EventHandler(this.btnBothImages_Click);
            // 
            // sepReplace
            // 
            this.sepReplace.Name = "sepReplace";
            this.sepReplace.Size = new System.Drawing.Size(112, 6);
            this.sepReplace.Visible = false;
            // 
            // tsReplace
            // 
            this.tsReplace.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmRGBA8,
            this.cmRGB565,
            this.cmRGB5A3});
            this.tsReplace.Name = "tsReplace";
            this.tsReplace.Size = new System.Drawing.Size(115, 22);
            this.tsReplace.Text = "Replace";
            this.tsReplace.Visible = false;
            // 
            // cmRGBA8
            // 
            this.cmRGBA8.Name = "cmRGBA8";
            this.cmRGBA8.Size = new System.Drawing.Size(234, 22);
            this.cmRGBA8.Text = "As RGBA8 (High Quality )";
            this.cmRGBA8.Click += new System.EventHandler(this.btnRGBA8_Click);
            // 
            // cmRGB565
            // 
            this.cmRGB565.Name = "cmRGB565";
            this.cmRGB565.Size = new System.Drawing.Size(234, 22);
            this.cmRGB565.Text = "AS RGB565 (Moderate Quality)";
            this.cmRGB565.Click += new System.EventHandler(this.btnRGB565_Click);
            // 
            // cmRGB5A3
            // 
            this.cmRGB5A3.Name = "cmRGB5A3";
            this.cmRGB5A3.Size = new System.Drawing.Size(234, 22);
            this.cmRGB5A3.Text = "As RGB5A3 (Low Quality)";
            this.cmRGB5A3.Click += new System.EventHandler(this.btnRGB5A3_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbFormat);
            this.panel1.Controls.Add(this.lbFormatText);
            this.panel1.Controls.Add(this.lbSize);
            this.panel1.Controls.Add(this.lbSizeText);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(852, 22);
            this.panel1.TabIndex = 2;
            // 
            // lbFormat
            // 
            this.lbFormat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbFormat.AutoSize = true;
            this.lbFormat.Location = new System.Drawing.Point(791, 5);
            this.lbFormat.Name = "lbFormat";
            this.lbFormat.Size = new System.Drawing.Size(43, 13);
            this.lbFormat.TabIndex = 3;
            this.lbFormat.Text = "RGBA8";
            // 
            // lbFormatText
            // 
            this.lbFormatText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbFormatText.Location = new System.Drawing.Point(585, 5);
            this.lbFormatText.Name = "lbFormatText";
            this.lbFormatText.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbFormatText.Size = new System.Drawing.Size(205, 13);
            this.lbFormatText.TabIndex = 2;
            this.lbFormatText.Text = "Texture Format:";
            this.lbFormatText.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lbSize
            // 
            this.lbSize.AutoSize = true;
            this.lbSize.Location = new System.Drawing.Point(39, 5);
            this.lbSize.Name = "lbSize";
            this.lbSize.Size = new System.Drawing.Size(30, 13);
            this.lbSize.TabIndex = 1;
            this.lbSize.Text = "0 x 0";
            // 
            // lbSizeText
            // 
            this.lbSizeText.AutoSize = true;
            this.lbSizeText.Location = new System.Drawing.Point(4, 5);
            this.lbSizeText.Name = "lbSizeText";
            this.lbSizeText.Size = new System.Drawing.Size(30, 13);
            this.lbSizeText.TabIndex = 0;
            this.lbSizeText.Text = "Size:";
            // 
            // pbPic
            // 
            this.pbPic.ContextMenuStrip = this.cmPic;
            this.pbPic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbPic.Location = new System.Drawing.Point(0, 22);
            this.pbPic.Name = "pbPic";
            this.pbPic.Size = new System.Drawing.Size(852, 451);
            this.pbPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbPic.TabIndex = 3;
            this.pbPic.TabStop = false;
            // 
            // ShowMiiWads_Preview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(852, 501);
            this.Controls.Add(this.pbPic);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Panel);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(833, 500);
            this.Name = "ShowMiiWads_Preview";
            this.Text = "Preview";
            this.Load += new System.EventHandler(this.Preview_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Preview_FormClosing);
            this.Panel.ResumeLayout(false);
            this.Panel.PerformLayout();
            this.cmPic.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPic)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel Panel;
        private System.Windows.Forms.Label lbIcon;
        private System.Windows.Forms.Label lbBanner;
        public System.Windows.Forms.ComboBox cbBanner;
        public System.Windows.Forms.Button btnClose;
        public System.Windows.Forms.ComboBox cbIcon;
        private System.Windows.Forms.ContextMenuStrip cmPic;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pbPic;
        private System.Windows.Forms.Label lbSize;
        private System.Windows.Forms.Label lbFormat;
        public System.Windows.Forms.Button btnSave;
        public System.Windows.Forms.Label lbSizeText;
        public System.Windows.Forms.Label lbFormatText;
        public System.Windows.Forms.ToolStripMenuItem cmSave;
        public System.Windows.Forms.ToolStripMenuItem cmSaveAll;
        public System.Windows.Forms.ToolStripMenuItem cmBannerImages;
        public System.Windows.Forms.ToolStripMenuItem cmIconImages;
        public System.Windows.Forms.ToolStripMenuItem cmBothImages;
        private System.Windows.Forms.ToolStripSeparator sepReplace;
        public System.Windows.Forms.ToolStripMenuItem tsReplace;
        public System.Windows.Forms.ToolStripMenuItem cmRGBA8;
        public System.Windows.Forms.ToolStripMenuItem cmRGB565;
        public System.Windows.Forms.ToolStripMenuItem cmRGB5A3;
        public System.Windows.Forms.CheckBox cbLz77;
    }
}