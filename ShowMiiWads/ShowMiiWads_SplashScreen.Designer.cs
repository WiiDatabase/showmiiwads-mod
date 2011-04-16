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
    partial class ShowMiiWads_SplashScreen
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
            this.lvWads = new System.Windows.Forms.ListView();
            this.lvName = new System.Windows.Forms.ColumnHeader();
            this.lvID = new System.Windows.Forms.ColumnHeader();
            this.lvBlocks = new System.Windows.Forms.ColumnHeader();
            this.lvFilesize = new System.Windows.Forms.ColumnHeader();
            this.lvIOS = new System.Windows.Forms.ColumnHeader();
            this.lvRegion = new System.Windows.Forms.ColumnHeader();
            this.lvData = new System.Windows.Forms.ColumnHeader();
            this.lvPath = new System.Windows.Forms.ColumnHeader();
            this.lvType = new System.Windows.Forms.ColumnHeader();
            this.lvVersion = new System.Windows.Forms.ColumnHeader();
            this.lvTitle = new System.Windows.Forms.ColumnHeader();
            this.lvNand = new System.Windows.Forms.ListView();
            this.lvNandName = new System.Windows.Forms.ColumnHeader();
            this.lvNandID = new System.Windows.Forms.ColumnHeader();
            this.lvNandBlocks = new System.Windows.Forms.ColumnHeader();
            this.lvNandSize = new System.Windows.Forms.ColumnHeader();
            this.lvNandIOS = new System.Windows.Forms.ColumnHeader();
            this.lvNandRegion = new System.Windows.Forms.ColumnHeader();
            this.lvNandContent = new System.Windows.Forms.ColumnHeader();
            this.lvNandPath = new System.Windows.Forms.ColumnHeader();
            this.lvNandType = new System.Windows.Forms.ColumnHeader();
            this.lvNandVersion = new System.Windows.Forms.ColumnHeader();
            this.lvNandTitle = new System.Windows.Forms.ColumnHeader();
            this.pbProgress = new System.Windows.Forms.ProgressBar();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lvWads
            // 
            this.lvWads.AllowDrop = true;
            this.lvWads.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.lvName,
            this.lvID,
            this.lvBlocks,
            this.lvFilesize,
            this.lvIOS,
            this.lvRegion,
            this.lvData,
            this.lvPath,
            this.lvType,
            this.lvVersion,
            this.lvTitle});
            this.lvWads.FullRowSelect = true;
            this.lvWads.Location = new System.Drawing.Point(8, 8);
            this.lvWads.Name = "lvWads";
            this.lvWads.Size = new System.Drawing.Size(30, 36);
            this.lvWads.TabIndex = 2;
            this.lvWads.UseCompatibleStateImageBehavior = false;
            this.lvWads.View = System.Windows.Forms.View.Details;
            this.lvWads.Visible = false;
            // 
            // lvName
            // 
            this.lvName.Text = "Filename";
            this.lvName.Width = 145;
            // 
            // lvID
            // 
            this.lvID.DisplayIndex = 3;
            this.lvID.Text = "Title ID";
            this.lvID.Width = 56;
            // 
            // lvBlocks
            // 
            this.lvBlocks.DisplayIndex = 5;
            this.lvBlocks.Tag = "Numeric";
            this.lvBlocks.Text = "Blocks";
            // 
            // lvFilesize
            // 
            this.lvFilesize.DisplayIndex = 6;
            this.lvFilesize.Text = "Filesize";
            this.lvFilesize.Width = 82;
            // 
            // lvIOS
            // 
            this.lvIOS.DisplayIndex = 7;
            this.lvIOS.Text = "IOS Flag";
            this.lvIOS.Width = 53;
            // 
            // lvRegion
            // 
            this.lvRegion.DisplayIndex = 8;
            this.lvRegion.Text = "Region Flag";
            this.lvRegion.Width = 70;
            // 
            // lvData
            // 
            this.lvData.DisplayIndex = 9;
            this.lvData.Tag = "Numeric";
            this.lvData.Text = "Content";
            this.lvData.Width = 49;
            // 
            // lvPath
            // 
            this.lvPath.DisplayIndex = 10;
            this.lvPath.Text = "Path";
            this.lvPath.Width = 122;
            // 
            // lvType
            // 
            this.lvType.DisplayIndex = 1;
            this.lvType.Text = "Type";
            this.lvType.Width = 78;
            // 
            // lvVersion
            // 
            this.lvVersion.DisplayIndex = 4;
            this.lvVersion.Tag = "Numeric";
            this.lvVersion.Text = "Version";
            this.lvVersion.Width = 47;
            // 
            // lvTitle
            // 
            this.lvTitle.DisplayIndex = 2;
            this.lvTitle.Text = "Channel Title";
            this.lvTitle.Width = 148;
            // 
            // lvNand
            // 
            this.lvNand.AllowDrop = true;
            this.lvNand.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.lvNandName,
            this.lvNandID,
            this.lvNandBlocks,
            this.lvNandSize,
            this.lvNandIOS,
            this.lvNandRegion,
            this.lvNandContent,
            this.lvNandPath,
            this.lvNandType,
            this.lvNandVersion,
            this.lvNandTitle});
            this.lvNand.FullRowSelect = true;
            this.lvNand.Location = new System.Drawing.Point(44, 8);
            this.lvNand.Name = "lvNand";
            this.lvNand.ShowGroups = false;
            this.lvNand.Size = new System.Drawing.Size(30, 36);
            this.lvNand.TabIndex = 5;
            this.lvNand.UseCompatibleStateImageBehavior = false;
            this.lvNand.View = System.Windows.Forms.View.Details;
            this.lvNand.Visible = false;
            // 
            // lvNandName
            // 
            this.lvNandName.Text = "Filename";
            this.lvNandName.Width = 145;
            // 
            // lvNandID
            // 
            this.lvNandID.DisplayIndex = 3;
            this.lvNandID.Text = "Title ID";
            this.lvNandID.Width = 56;
            // 
            // lvNandBlocks
            // 
            this.lvNandBlocks.DisplayIndex = 5;
            this.lvNandBlocks.Tag = "Numeric";
            this.lvNandBlocks.Text = "Blocks";
            // 
            // lvNandSize
            // 
            this.lvNandSize.DisplayIndex = 6;
            this.lvNandSize.Text = "Size";
            this.lvNandSize.Width = 82;
            // 
            // lvNandIOS
            // 
            this.lvNandIOS.DisplayIndex = 7;
            this.lvNandIOS.Text = "IOS Flag";
            this.lvNandIOS.Width = 53;
            // 
            // lvNandRegion
            // 
            this.lvNandRegion.DisplayIndex = 8;
            this.lvNandRegion.Text = "Region Flag";
            this.lvNandRegion.Width = 70;
            // 
            // lvNandContent
            // 
            this.lvNandContent.DisplayIndex = 9;
            this.lvNandContent.Tag = "Numeric";
            this.lvNandContent.Text = "Content";
            this.lvNandContent.Width = 49;
            // 
            // lvNandPath
            // 
            this.lvNandPath.DisplayIndex = 10;
            this.lvNandPath.Text = "Path";
            this.lvNandPath.Width = 122;
            // 
            // lvNandType
            // 
            this.lvNandType.DisplayIndex = 1;
            this.lvNandType.Text = "Type";
            this.lvNandType.Width = 78;
            // 
            // lvNandVersion
            // 
            this.lvNandVersion.DisplayIndex = 4;
            this.lvNandVersion.Tag = "Numeric";
            this.lvNandVersion.Text = "Version";
            this.lvNandVersion.Width = 47;
            // 
            // lvNandTitle
            // 
            this.lvNandTitle.DisplayIndex = 2;
            this.lvNandTitle.Text = "Channel Title";
            this.lvNandTitle.Width = 148;
            // 
            // pbProgress
            // 
            this.pbProgress.Location = new System.Drawing.Point(0, 83);
            this.pbProgress.Name = "pbProgress";
            this.pbProgress.Size = new System.Drawing.Size(300, 32);
            this.pbProgress.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pbProgress.TabIndex = 7;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::ShowMiiWads.Properties.Resources.ShowMiiWads_Loading;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(300, 80);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // SplashScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(300, 118);
            this.Controls.Add(this.pbProgress);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lvNand);
            this.Controls.Add(this.lvWads);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SplashScreen";
            this.Text = "ShowMiiWads";
            this.TransparencyKey = System.Drawing.SystemColors.Control;
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvWads;
        private System.Windows.Forms.ColumnHeader lvName;
        private System.Windows.Forms.ColumnHeader lvID;
        private System.Windows.Forms.ColumnHeader lvBlocks;
        private System.Windows.Forms.ColumnHeader lvFilesize;
        private System.Windows.Forms.ColumnHeader lvIOS;
        private System.Windows.Forms.ColumnHeader lvRegion;
        private System.Windows.Forms.ColumnHeader lvData;
        private System.Windows.Forms.ColumnHeader lvPath;
        private System.Windows.Forms.ColumnHeader lvType;
        private System.Windows.Forms.ColumnHeader lvVersion;
        private System.Windows.Forms.ColumnHeader lvTitle;
        private System.Windows.Forms.ListView lvNand;
        private System.Windows.Forms.ColumnHeader lvNandName;
        private System.Windows.Forms.ColumnHeader lvNandID;
        private System.Windows.Forms.ColumnHeader lvNandBlocks;
        private System.Windows.Forms.ColumnHeader lvNandSize;
        private System.Windows.Forms.ColumnHeader lvNandIOS;
        private System.Windows.Forms.ColumnHeader lvNandRegion;
        private System.Windows.Forms.ColumnHeader lvNandContent;
        private System.Windows.Forms.ColumnHeader lvNandPath;
        private System.Windows.Forms.ColumnHeader lvNandType;
        private System.Windows.Forms.ColumnHeader lvNandVersion;
        private System.Windows.Forms.ColumnHeader lvNandTitle;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ProgressBar pbProgress;
    }
}