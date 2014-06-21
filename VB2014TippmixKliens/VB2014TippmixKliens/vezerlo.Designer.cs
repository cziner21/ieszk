namespace VB2014TippmixKliens
{
    partial class vezerlo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(vezerlo));
            this.kilepBtn = new System.Windows.Forms.Button();
            this.generalBtn = new System.Windows.Forms.Button();
            this.egyenlegBtn = new System.Windows.Forms.Button();
            this.fogadasBtn = new System.Windows.Forms.Button();
            this.usernameLbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // kilepBtn
            // 
            this.kilepBtn.Location = new System.Drawing.Point(33, 198);
            this.kilepBtn.Name = "kilepBtn";
            this.kilepBtn.Size = new System.Drawing.Size(75, 23);
            this.kilepBtn.TabIndex = 13;
            this.kilepBtn.Text = "Kilép";
            this.kilepBtn.UseVisualStyleBackColor = true;
            this.kilepBtn.Click += new System.EventHandler(this.kilepBtn_Click);
            // 
            // generalBtn
            // 
            this.generalBtn.Location = new System.Drawing.Point(33, 132);
            this.generalBtn.Name = "generalBtn";
            this.generalBtn.Size = new System.Drawing.Size(75, 23);
            this.generalBtn.TabIndex = 12;
            this.generalBtn.Text = "Generál";
            this.generalBtn.UseVisualStyleBackColor = true;
            this.generalBtn.Click += new System.EventHandler(this.generalBtn_Click);
            // 
            // egyenlegBtn
            // 
            this.egyenlegBtn.Location = new System.Drawing.Point(33, 81);
            this.egyenlegBtn.Name = "egyenlegBtn";
            this.egyenlegBtn.Size = new System.Drawing.Size(75, 23);
            this.egyenlegBtn.TabIndex = 11;
            this.egyenlegBtn.Text = "Egyenleg";
            this.egyenlegBtn.UseVisualStyleBackColor = true;
            this.egyenlegBtn.Click += new System.EventHandler(this.egyenlegBtn_Click);
            // 
            // fogadasBtn
            // 
            this.fogadasBtn.Location = new System.Drawing.Point(33, 48);
            this.fogadasBtn.Name = "fogadasBtn";
            this.fogadasBtn.Size = new System.Drawing.Size(75, 23);
            this.fogadasBtn.TabIndex = 10;
            this.fogadasBtn.Text = "Fogadás";
            this.fogadasBtn.UseVisualStyleBackColor = true;
            this.fogadasBtn.Click += new System.EventHandler(this.fogadasBtn_Click);
            // 
            // usernameLbl
            // 
            this.usernameLbl.AutoSize = true;
            this.usernameLbl.Location = new System.Drawing.Point(13, 13);
            this.usernameLbl.Name = "usernameLbl";
            this.usernameLbl.Size = new System.Drawing.Size(35, 13);
            this.usernameLbl.TabIndex = 14;
            this.usernameLbl.Text = "label1";
            // 
            // vezerlo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.usernameLbl);
            this.Controls.Add(this.kilepBtn);
            this.Controls.Add(this.generalBtn);
            this.Controls.Add(this.egyenlegBtn);
            this.Controls.Add(this.fogadasBtn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "vezerlo";
            this.Text = "Vezérlő -- ";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button kilepBtn;
        private System.Windows.Forms.Button generalBtn;
        private System.Windows.Forms.Button egyenlegBtn;
        private System.Windows.Forms.Button fogadasBtn;
        private System.Windows.Forms.Label usernameLbl;
    }
}