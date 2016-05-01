namespace InputValidator
{
    partial class InpValidator
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.BtnSave = new System.Windows.Forms.Button();
            this.TxtName = new System.Windows.Forms.TextBox();
            this.TxtPhone = new System.Windows.Forms.TextBox();
            this.TxtEmail = new System.Windows.Forms.TextBox();
            this.NameLab = new System.Windows.Forms.Label();
            this.PhoneLab = new System.Windows.Forms.Label();
            this.EmailLab = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // BtnSave
            // 
            this.BtnSave.Location = new System.Drawing.Point(304, 139);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(86, 23);
            this.BtnSave.TabIndex = 0;
            this.BtnSave.Text = "Save";
            this.BtnSave.UseVisualStyleBackColor = true;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // TxtName
            // 
            this.TxtName.Location = new System.Drawing.Point(54, 28);
            this.TxtName.Name = "TxtName";
            this.TxtName.Size = new System.Drawing.Size(230, 20);
            this.TxtName.TabIndex = 1;
            // 
            // TxtPhone
            // 
            this.TxtPhone.Location = new System.Drawing.Point(54, 65);
            this.TxtPhone.Name = "TxtPhone";
            this.TxtPhone.Size = new System.Drawing.Size(230, 20);
            this.TxtPhone.TabIndex = 1;
            // 
            // TxtEmail
            // 
            this.TxtEmail.Location = new System.Drawing.Point(54, 104);
            this.TxtEmail.Name = "TxtEmail";
            this.TxtEmail.Size = new System.Drawing.Size(230, 20);
            this.TxtEmail.TabIndex = 1;
            // 
            // NameLab
            // 
            this.NameLab.AutoSize = true;
            this.NameLab.Location = new System.Drawing.Point(13, 31);
            this.NameLab.Name = "NameLab";
            this.NameLab.Size = new System.Drawing.Size(35, 13);
            this.NameLab.TabIndex = 2;
            this.NameLab.Text = "Name";
            // 
            // PhoneLab
            // 
            this.PhoneLab.AutoSize = true;
            this.PhoneLab.Location = new System.Drawing.Point(13, 68);
            this.PhoneLab.Name = "PhoneLab";
            this.PhoneLab.Size = new System.Drawing.Size(38, 13);
            this.PhoneLab.TabIndex = 2;
            this.PhoneLab.Text = "Phone";
            // 
            // EmailLab
            // 
            this.EmailLab.AutoSize = true;
            this.EmailLab.Location = new System.Drawing.Point(13, 107);
            this.EmailLab.Name = "EmailLab";
            this.EmailLab.Size = new System.Drawing.Size(35, 13);
            this.EmailLab.TabIndex = 2;
            this.EmailLab.Text = "E-mail";
            // 
            // InpValidator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(402, 174);
            this.Controls.Add(this.EmailLab);
            this.Controls.Add(this.PhoneLab);
            this.Controls.Add(this.NameLab);
            this.Controls.Add(this.TxtEmail);
            this.Controls.Add(this.TxtPhone);
            this.Controls.Add(this.TxtName);
            this.Controls.Add(this.BtnSave);
            this.Name = "InpValidator";
            this.Text = "Input Validator";
            this.Load += new System.EventHandler(this.InpValidator_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.TextBox TxtName;
        private System.Windows.Forms.TextBox TxtPhone;
        private System.Windows.Forms.TextBox TxtEmail;
        private System.Windows.Forms.Label NameLab;
        private System.Windows.Forms.Label PhoneLab;
        private System.Windows.Forms.Label EmailLab;
    }
}

