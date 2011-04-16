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
 
 namespace ChannelNameBox
{
    partial class ChannelNameDialog
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
            this.txtEng = new System.Windows.Forms.TextBox();
            this.txtJap = new System.Windows.Forms.TextBox();
            this.txtDe = new System.Windows.Forms.TextBox();
            this.txtFr = new System.Windows.Forms.TextBox();
            this.txtEs = new System.Windows.Forms.TextBox();
            this.txtIt = new System.Windows.Forms.TextBox();
            this.txtNe = new System.Windows.Forms.TextBox();
            this.lbEng = new System.Windows.Forms.Label();
            this.lbJap = new System.Windows.Forms.Label();
            this.lbGerman = new System.Windows.Forms.Label();
            this.lbFr = new System.Windows.Forms.Label();
            this.lbEs = new System.Windows.Forms.Label();
            this.lbIt = new System.Windows.Forms.Label();
            this.lbNe = new System.Windows.Forms.Label();
            this.cbLink = new System.Windows.Forms.CheckBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtKor = new System.Windows.Forms.TextBox();
            this.lbKor = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtEng
            // 
            this.txtEng.Location = new System.Drawing.Point(59, 6);
            this.txtEng.MaxLength = 20;
            this.txtEng.Name = "txtEng";
            this.txtEng.Size = new System.Drawing.Size(150, 20);
            this.txtEng.TabIndex = 0;
            this.txtEng.TextChanged += new System.EventHandler(this.txtChanged);
            // 
            // txtJap
            // 
            this.txtJap.Location = new System.Drawing.Point(276, 6);
            this.txtJap.MaxLength = 20;
            this.txtJap.Name = "txtJap";
            this.txtJap.Size = new System.Drawing.Size(150, 20);
            this.txtJap.TabIndex = 1;
            this.txtJap.TextChanged += new System.EventHandler(this.txtChanged);
            // 
            // txtDe
            // 
            this.txtDe.Location = new System.Drawing.Point(59, 32);
            this.txtDe.MaxLength = 20;
            this.txtDe.Name = "txtDe";
            this.txtDe.Size = new System.Drawing.Size(150, 20);
            this.txtDe.TabIndex = 2;
            this.txtDe.TextChanged += new System.EventHandler(this.txtChanged);
            // 
            // txtFr
            // 
            this.txtFr.Location = new System.Drawing.Point(276, 32);
            this.txtFr.MaxLength = 20;
            this.txtFr.Name = "txtFr";
            this.txtFr.Size = new System.Drawing.Size(150, 20);
            this.txtFr.TabIndex = 3;
            this.txtFr.TextChanged += new System.EventHandler(this.txtChanged);
            // 
            // txtEs
            // 
            this.txtEs.Location = new System.Drawing.Point(59, 58);
            this.txtEs.MaxLength = 20;
            this.txtEs.Name = "txtEs";
            this.txtEs.Size = new System.Drawing.Size(150, 20);
            this.txtEs.TabIndex = 4;
            this.txtEs.TextChanged += new System.EventHandler(this.txtChanged);
            // 
            // txtIt
            // 
            this.txtIt.Location = new System.Drawing.Point(276, 58);
            this.txtIt.MaxLength = 20;
            this.txtIt.Name = "txtIt";
            this.txtIt.Size = new System.Drawing.Size(150, 20);
            this.txtIt.TabIndex = 5;
            this.txtIt.TextChanged += new System.EventHandler(this.txtChanged);
            // 
            // txtNe
            // 
            this.txtNe.Location = new System.Drawing.Point(59, 84);
            this.txtNe.MaxLength = 20;
            this.txtNe.Name = "txtNe";
            this.txtNe.Size = new System.Drawing.Size(150, 20);
            this.txtNe.TabIndex = 6;
            this.txtNe.TextChanged += new System.EventHandler(this.txtChanged);
            // 
            // lbEng
            // 
            this.lbEng.AutoSize = true;
            this.lbEng.Location = new System.Drawing.Point(12, 9);
            this.lbEng.Name = "lbEng";
            this.lbEng.Size = new System.Drawing.Size(41, 13);
            this.lbEng.TabIndex = 1;
            this.lbEng.Text = "English";
            // 
            // lbJap
            // 
            this.lbJap.AutoSize = true;
            this.lbJap.Location = new System.Drawing.Point(217, 9);
            this.lbJap.Name = "lbJap";
            this.lbJap.Size = new System.Drawing.Size(53, 13);
            this.lbJap.TabIndex = 2;
            this.lbJap.Text = "Japanese";
            // 
            // lbGerman
            // 
            this.lbGerman.AutoSize = true;
            this.lbGerman.Location = new System.Drawing.Point(9, 35);
            this.lbGerman.Name = "lbGerman";
            this.lbGerman.Size = new System.Drawing.Size(44, 13);
            this.lbGerman.TabIndex = 3;
            this.lbGerman.Text = "German";
            // 
            // lbFr
            // 
            this.lbFr.AutoSize = true;
            this.lbFr.Location = new System.Drawing.Point(230, 35);
            this.lbFr.Name = "lbFr";
            this.lbFr.Size = new System.Drawing.Size(40, 13);
            this.lbFr.TabIndex = 4;
            this.lbFr.Text = "French";
            // 
            // lbEs
            // 
            this.lbEs.AutoSize = true;
            this.lbEs.Location = new System.Drawing.Point(8, 61);
            this.lbEs.Name = "lbEs";
            this.lbEs.Size = new System.Drawing.Size(45, 13);
            this.lbEs.TabIndex = 5;
            this.lbEs.Text = "Spanish";
            // 
            // lbIt
            // 
            this.lbIt.AutoSize = true;
            this.lbIt.Location = new System.Drawing.Point(230, 61);
            this.lbIt.Name = "lbIt";
            this.lbIt.Size = new System.Drawing.Size(35, 13);
            this.lbIt.TabIndex = 6;
            this.lbIt.Text = "Italian";
            // 
            // lbNe
            // 
            this.lbNe.AutoSize = true;
            this.lbNe.Location = new System.Drawing.Point(17, 87);
            this.lbNe.Name = "lbNe";
            this.lbNe.Size = new System.Drawing.Size(36, 13);
            this.lbNe.TabIndex = 7;
            this.lbNe.Text = "Dutch";
            // 
            // cbLink
            // 
            this.cbLink.AutoSize = true;
            this.cbLink.Checked = true;
            this.cbLink.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbLink.Location = new System.Drawing.Point(181, 118);
            this.cbLink.Name = "cbLink";
            this.cbLink.Size = new System.Drawing.Size(82, 17);
            this.cbLink.TabIndex = 7;
            this.cbLink.Text = "Link Names";
            this.cbLink.UseVisualStyleBackColor = true;
            this.cbLink.CheckedChanged += new System.EventHandler(this.cbLink_CheckedChanged);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(12, 114);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(143, 23);
            this.btnOK.TabIndex = 8;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(283, 114);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(143, 23);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtKor
            // 
            this.txtKor.Location = new System.Drawing.Point(276, 84);
            this.txtKor.MaxLength = 20;
            this.txtKor.Name = "txtKor";
            this.txtKor.Size = new System.Drawing.Size(150, 20);
            this.txtKor.TabIndex = 5;
            this.txtKor.TextChanged += new System.EventHandler(this.txtChanged);
            // 
            // lbKor
            // 
            this.lbKor.AutoSize = true;
            this.lbKor.Location = new System.Drawing.Point(224, 87);
            this.lbKor.Name = "lbKor";
            this.lbKor.Size = new System.Drawing.Size(41, 13);
            this.lbKor.TabIndex = 6;
            this.lbKor.Text = "Korean";
            // 
            // ChannelNameDialog
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(438, 149);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.cbLink);
            this.Controls.Add(this.lbNe);
            this.Controls.Add(this.lbKor);
            this.Controls.Add(this.lbIt);
            this.Controls.Add(this.lbEs);
            this.Controls.Add(this.lbFr);
            this.Controls.Add(this.lbGerman);
            this.Controls.Add(this.lbJap);
            this.Controls.Add(this.lbEng);
            this.Controls.Add(this.txtNe);
            this.Controls.Add(this.txtKor);
            this.Controls.Add(this.txtIt);
            this.Controls.Add(this.txtEs);
            this.Controls.Add(this.txtFr);
            this.Controls.Add(this.txtDe);
            this.Controls.Add(this.txtJap);
            this.Controls.Add(this.txtEng);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChannelNameDialog";
            this.Load += new System.EventHandler(this.ChannelNameDialog_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtEng;
        private System.Windows.Forms.TextBox txtJap;
        private System.Windows.Forms.TextBox txtDe;
        private System.Windows.Forms.TextBox txtFr;
        private System.Windows.Forms.TextBox txtEs;
        private System.Windows.Forms.TextBox txtIt;
        private System.Windows.Forms.TextBox txtNe;
        private System.Windows.Forms.Label lbEng;
        private System.Windows.Forms.Label lbJap;
        private System.Windows.Forms.Label lbGerman;
        private System.Windows.Forms.Label lbFr;
        private System.Windows.Forms.Label lbEs;
        private System.Windows.Forms.Label lbIt;
        private System.Windows.Forms.Label lbNe;
        private System.Windows.Forms.CheckBox cbLink;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtKor;
        private System.Windows.Forms.Label lbKor;
    }
}