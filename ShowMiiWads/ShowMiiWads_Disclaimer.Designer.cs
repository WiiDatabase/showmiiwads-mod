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
    partial class ShowMiiWads_Disclaimer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShowMiiWads_Disclaimer));
            this.rtbDisclaimer = new System.Windows.Forms.RichTextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.rbAccept = new System.Windows.Forms.RadioButton();
            this.rbNoUse = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // rtbDisclaimer
            // 
            this.rtbDisclaimer.Cursor = System.Windows.Forms.Cursors.Default;
            this.rtbDisclaimer.Location = new System.Drawing.Point(12, 12);
            this.rtbDisclaimer.Name = "rtbDisclaimer";
            this.rtbDisclaimer.ReadOnly = true;
            this.rtbDisclaimer.Size = new System.Drawing.Size(261, 149);
            this.rtbDisclaimer.TabIndex = 0;
            this.rtbDisclaimer.Text = resources.GetString("rtbDisclaimer.Text");
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(12, 206);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(261, 28);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // rbAccept
            // 
            this.rbAccept.AutoSize = true;
            this.rbAccept.Location = new System.Drawing.Point(12, 165);
            this.rbAccept.Name = "rbAccept";
            this.rbAccept.Size = new System.Drawing.Size(262, 17);
            this.rbAccept.TabIndex = 4;
            this.rbAccept.Text = "I accept and take the risk of WAD editing features";
            this.rbAccept.UseVisualStyleBackColor = true;
            // 
            // rbNoUse
            // 
            this.rbNoUse.AutoSize = true;
            this.rbNoUse.Checked = true;
            this.rbNoUse.Location = new System.Drawing.Point(12, 183);
            this.rbNoUse.Name = "rbNoUse";
            this.rbNoUse.Size = new System.Drawing.Size(216, 17);
            this.rbNoUse.TabIndex = 5;
            this.rbNoUse.TabStop = true;
            this.rbNoUse.Text = "I don\'t want to use WAD editing features";
            this.rbNoUse.UseVisualStyleBackColor = true;
            // 
            // Disclaimer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(285, 244);
            this.Controls.Add(this.rbNoUse);
            this.Controls.Add(this.rbAccept);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.rtbDisclaimer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Disclaimer";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Disclaimer";
            this.Load += new System.EventHandler(this.Disclaimer_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbDisclaimer;
        private System.Windows.Forms.Button btnOK;
        public System.Windows.Forms.RadioButton rbAccept;
        public System.Windows.Forms.RadioButton rbNoUse;
    }
}