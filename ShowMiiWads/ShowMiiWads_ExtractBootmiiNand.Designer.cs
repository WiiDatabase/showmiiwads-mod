namespace ShowMiiWads
{
    partial class ShowMiiWads_ExtractBootmiiNand
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
            this.btNandFile = new System.Windows.Forms.Button();
            this.btExtractToPath = new System.Windows.Forms.Button();
            this.btStartExtract = new System.Windows.Forms.Button();
            this.tbNandFile = new System.Windows.Forms.TextBox();
            this.tbExtractToPath = new System.Windows.Forms.TextBox();
            this.lbNandFile = new System.Windows.Forms.Label();
            this.lbExtractToPath = new System.Windows.Forms.Label();
            this.pbExtract = new System.Windows.Forms.ProgressBar();
            this.lbExtractedFile = new System.Windows.Forms.Label();
            this.btCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btNandFile
            // 
            this.btNandFile.Location = new System.Drawing.Point(411, 29);
            this.btNandFile.Name = "btNandFile";
            this.btNandFile.Size = new System.Drawing.Size(75, 23);
            this.btNandFile.TabIndex = 0;
            this.btNandFile.Text = "Open...";
            this.btNandFile.UseVisualStyleBackColor = true;
            this.btNandFile.Click += new System.EventHandler(this.btNandFile_Click);
            // 
            // btExtractToPath
            // 
            this.btExtractToPath.Location = new System.Drawing.Point(411, 97);
            this.btExtractToPath.Name = "btExtractToPath";
            this.btExtractToPath.Size = new System.Drawing.Size(75, 23);
            this.btExtractToPath.TabIndex = 1;
            this.btExtractToPath.Text = "Open...";
            this.btExtractToPath.UseVisualStyleBackColor = true;
            this.btExtractToPath.Click += new System.EventHandler(this.btExtractToPath_Click);
            // 
            // btStartExtract
            // 
            this.btStartExtract.Location = new System.Drawing.Point(330, 194);
            this.btStartExtract.Name = "btStartExtract";
            this.btStartExtract.Size = new System.Drawing.Size(75, 23);
            this.btStartExtract.TabIndex = 2;
            this.btStartExtract.Text = "Start...";
            this.btStartExtract.UseVisualStyleBackColor = true;
            this.btStartExtract.Click += new System.EventHandler(this.btStartExtract_Click);
            // 
            // tbNandFile
            // 
            this.tbNandFile.Location = new System.Drawing.Point(12, 31);
            this.tbNandFile.Name = "tbNandFile";
            this.tbNandFile.Size = new System.Drawing.Size(393, 20);
            this.tbNandFile.TabIndex = 4;
            // 
            // tbExtractToPath
            // 
            this.tbExtractToPath.Location = new System.Drawing.Point(12, 99);
            this.tbExtractToPath.Name = "tbExtractToPath";
            this.tbExtractToPath.Size = new System.Drawing.Size(393, 20);
            this.tbExtractToPath.TabIndex = 5;
            // 
            // lbNandFile
            // 
            this.lbNandFile.AutoSize = true;
            this.lbNandFile.Location = new System.Drawing.Point(12, 15);
            this.lbNandFile.Name = "lbNandFile";
            this.lbNandFile.Size = new System.Drawing.Size(98, 13);
            this.lbNandFile.TabIndex = 6;
            this.lbNandFile.Text = "BootMii NAND file :";
            // 
            // lbExtractToPath
            // 
            this.lbExtractToPath.AutoSize = true;
            this.lbExtractToPath.Location = new System.Drawing.Point(12, 83);
            this.lbExtractToPath.Name = "lbExtractToPath";
            this.lbExtractToPath.Size = new System.Drawing.Size(101, 13);
            this.lbExtractToPath.TabIndex = 7;
            this.lbExtractToPath.Text = "Extract to directory :";
            // 
            // pbExtract
            // 
            this.pbExtract.Location = new System.Drawing.Point(15, 153);
            this.pbExtract.Name = "pbExtract";
            this.pbExtract.Size = new System.Drawing.Size(471, 23);
            this.pbExtract.Step = 1;
            this.pbExtract.TabIndex = 8;
            // 
            // lbExtractedFile
            // 
            this.lbExtractedFile.AutoSize = true;
            this.lbExtractedFile.Location = new System.Drawing.Point(12, 137);
            this.lbExtractedFile.Name = "lbExtractedFile";
            this.lbExtractedFile.Size = new System.Drawing.Size(29, 13);
            this.lbExtractedFile.TabIndex = 9;
            this.lbExtractedFile.Text = "label";
            // 
            // btCancel
            // 
            this.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCancel.Location = new System.Drawing.Point(411, 194);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(75, 23);
            this.btCancel.TabIndex = 10;
            this.btCancel.Text = "Quit/Cancel";
            this.btCancel.UseVisualStyleBackColor = true;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(220, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "(Note : keys.bin must be on the same folder !)";
            // 
            // ShowMiiWads_ExtractBootmiiNand
            // 
            this.AcceptButton = this.btStartExtract;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btCancel;
            this.ClientSize = new System.Drawing.Size(498, 229);
            this.ControlBox = false;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.lbExtractedFile);
            this.Controls.Add(this.pbExtract);
            this.Controls.Add(this.lbExtractToPath);
            this.Controls.Add(this.lbNandFile);
            this.Controls.Add(this.tbExtractToPath);
            this.Controls.Add(this.tbNandFile);
            this.Controls.Add(this.btStartExtract);
            this.Controls.Add(this.btExtractToPath);
            this.Controls.Add(this.btNandFile);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ShowMiiWads_ExtractBootmiiNand";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Bootmii NAND Extraction";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btNandFile;
        private System.Windows.Forms.Button btExtractToPath;
        private System.Windows.Forms.Button btStartExtract;
        private System.Windows.Forms.TextBox tbNandFile;
        private System.Windows.Forms.TextBox tbExtractToPath;
        private System.Windows.Forms.Label lbNandFile;
        private System.Windows.Forms.Label lbExtractToPath;
        private System.Windows.Forms.ProgressBar pbExtract;
        private System.Windows.Forms.Label lbExtractedFile;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.Label label1;
    }
}