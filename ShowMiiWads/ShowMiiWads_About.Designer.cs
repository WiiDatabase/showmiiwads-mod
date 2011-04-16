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
    partial class ShowMiiWads_About
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShowMiiWads_About));
            this.lbSMW = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.gbCredits = new System.Windows.Forms.GroupBox();
            this.panCredits = new System.Windows.Forms.Panel();
            this.lbCredits = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbDonate = new System.Windows.Forms.LinkLabel();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lbPlatform = new System.Windows.Forms.Label();
            this.gbCredits.SuspendLayout();
            this.panCredits.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lbSMW
            // 
            this.lbSMW.Location = new System.Drawing.Point(0, 59);
            this.lbSMW.Name = "lbSMW";
            this.lbSMW.Size = new System.Drawing.Size(200, 13);
            this.lbSMW.TabIndex = 0;
            this.lbSMW.Text = "ShowMiiWads by Leathl";
            this.lbSMW.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(0, 150);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(200, 45);
            this.label3.TabIndex = 4;
            this.label3.Text = "For further information or if you have suggestions, found bugs or anything else, " +
                "visit:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // linkLabel1
            // 
            this.linkLabel1.Location = new System.Drawing.Point(0, 198);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(200, 14);
            this.linkLabel1.TabIndex = 5;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "http://showmiiwads.googlecode.com/";
            this.linkLabel1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // gbCredits
            // 
            this.gbCredits.Controls.Add(this.panCredits);
            this.gbCredits.Location = new System.Drawing.Point(210, 2);
            this.gbCredits.Name = "gbCredits";
            this.gbCredits.Size = new System.Drawing.Size(178, 216);
            this.gbCredits.TabIndex = 8;
            this.gbCredits.TabStop = false;
            this.gbCredits.Text = "Thanks:";
            // 
            // panCredits
            // 
            this.panCredits.Controls.Add(this.lbCredits);
            this.panCredits.Location = new System.Drawing.Point(6, 15);
            this.panCredits.Name = "panCredits";
            this.panCredits.Size = new System.Drawing.Size(166, 195);
            this.panCredits.TabIndex = 1;
            // 
            // lbCredits
            // 
            this.lbCredits.AutoSize = true;
            this.lbCredits.Location = new System.Drawing.Point(6, 191);
            this.lbCredits.Name = "lbCredits";
            this.lbCredits.Size = new System.Drawing.Size(154, 260);
            this.lbCredits.TabIndex = 0;
            this.lbCredits.Text = resources.GetString("lbCredits.Text");
            this.lbCredits.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 231);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(182, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "If you want to support this application";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lbDonate
            // 
            this.lbDonate.AutoSize = true;
            this.lbDonate.Location = new System.Drawing.Point(187, 231);
            this.lbDonate.Name = "lbDonate";
            this.lbDonate.Size = new System.Drawing.Size(40, 13);
            this.lbDonate.TabIndex = 10;
            this.lbDonate.TabStop = true;
            this.lbDonate.Text = "donate";
            this.lbDonate.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lbDonate.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lbDonate_LinkClicked);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(228, 231);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(160, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "or just use it and tell your friends!";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(0, 76);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(200, 26);
            this.label5.TabIndex = 12;
            this.label5.Text = "is licensed under the terms of the GNU General Public License v2";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ShowMiiWads.Properties.Resources.ShowMiiWads_Logo;
            this.pictureBox1.Location = new System.Drawing.Point(-1, -1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(196, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // lbPlatform
            // 
            this.lbPlatform.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPlatform.Location = new System.Drawing.Point(0, 118);
            this.lbPlatform.Name = "lbPlatform";
            this.lbPlatform.Size = new System.Drawing.Size(200, 13);
            this.lbPlatform.TabIndex = 13;
            this.lbPlatform.Text = "You\'re running the 32 bit Version";
            this.lbPlatform.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // ShowMiiWads_About
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(396, 251);
            this.Controls.Add(this.lbPlatform);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lbDonate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.gbCredits);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbSMW);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ShowMiiWads_About";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "About";
            this.Load += new System.EventHandler(this.About_Load);
            this.gbCredits.ResumeLayout(false);
            this.panCredits.ResumeLayout(false);
            this.panCredits.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.LinkLabel linkLabel1;
        public System.Windows.Forms.Label lbSMW;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox gbCredits;
        private System.Windows.Forms.Label lbCredits;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.LinkLabel lbDonate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbPlatform;
        private System.Windows.Forms.Panel panCredits;
    }
}