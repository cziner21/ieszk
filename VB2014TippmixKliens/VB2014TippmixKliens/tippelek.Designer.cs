﻿namespace VB2014TippmixKliens
{
    partial class tippelek
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.fogadBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.esemenyekTbx = new System.Windows.Forms.TextBox();
            this.tetTbx = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 21);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(376, 68);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValueChanged);
            // 
            // fogadBtn
            // 
            this.fogadBtn.Location = new System.Drawing.Point(313, 225);
            this.fogadBtn.Name = "fogadBtn";
            this.fogadBtn.Size = new System.Drawing.Size(75, 23);
            this.fogadBtn.TabIndex = 1;
            this.fogadBtn.Text = "Fogad";
            this.fogadBtn.UseVisualStyleBackColor = true;
            this.fogadBtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 168);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Tét";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 125);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Események száma:";
            // 
            // esemenyekTbx
            // 
            this.esemenyekTbx.Location = new System.Drawing.Point(131, 122);
            this.esemenyekTbx.Name = "esemenyekTbx";
            this.esemenyekTbx.Size = new System.Drawing.Size(31, 20);
            this.esemenyekTbx.TabIndex = 5;
            // 
            // tetTbx
            // 
            this.tetTbx.Location = new System.Drawing.Point(27, 202);
            this.tetTbx.Name = "tetTbx";
            this.tetTbx.Size = new System.Drawing.Size(100, 20);
            this.tetTbx.TabIndex = 6;
            // 
            // tippelek
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(420, 262);
            this.Controls.Add(this.tetTbx);
            this.Controls.Add(this.esemenyekTbx);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.fogadBtn);
            this.Controls.Add(this.dataGridView1);
            this.Name = "tippelek";
            this.Text = "tippelek";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button fogadBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox esemenyekTbx;
        private System.Windows.Forms.TextBox tetTbx;


    }
}