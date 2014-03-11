namespace rendezoAlgoritmusok
{
    partial class Form1
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
            this.bubbleSortList = new System.Windows.Forms.ListBox();
            this.quickSortList = new System.Windows.Forms.ListBox();
            this.orderedBubble = new System.Windows.Forms.ListBox();
            this.orderedQuick = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bubbleSortList
            // 
            this.bubbleSortList.FormattingEnabled = true;
            this.bubbleSortList.Location = new System.Drawing.Point(12, 36);
            this.bubbleSortList.Name = "bubbleSortList";
            this.bubbleSortList.Size = new System.Drawing.Size(129, 147);
            this.bubbleSortList.TabIndex = 0;
            // 
            // quickSortList
            // 
            this.quickSortList.FormattingEnabled = true;
            this.quickSortList.Location = new System.Drawing.Point(308, 36);
            this.quickSortList.Name = "quickSortList";
            this.quickSortList.Size = new System.Drawing.Size(129, 147);
            this.quickSortList.TabIndex = 1;
            // 
            // orderedBubble
            // 
            this.orderedBubble.FormattingEnabled = true;
            this.orderedBubble.Location = new System.Drawing.Point(88, 220);
            this.orderedBubble.Name = "orderedBubble";
            this.orderedBubble.Size = new System.Drawing.Size(129, 147);
            this.orderedBubble.TabIndex = 2;
            // 
            // orderedQuick
            // 
            this.orderedQuick.FormattingEnabled = true;
            this.orderedQuick.Location = new System.Drawing.Point(223, 220);
            this.orderedQuick.Name = "orderedQuick";
            this.orderedQuick.Size = new System.Drawing.Size(129, 147);
            this.orderedQuick.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Buborékos rendezés:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(305, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Gyors rendezés:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(163, 190);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(134, 18);
            this.label3.TabIndex = 6;
            this.label3.Text = "Rendezett listák:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(186, 90);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Rendez";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 375);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.orderedQuick);
            this.Controls.Add(this.orderedBubble);
            this.Controls.Add(this.quickSortList);
            this.Controls.Add(this.bubbleSortList);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox bubbleSortList;
        private System.Windows.Forms.ListBox quickSortList;
        private System.Windows.Forms.ListBox orderedBubble;
        private System.Windows.Forms.ListBox orderedQuick;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
    }
}

