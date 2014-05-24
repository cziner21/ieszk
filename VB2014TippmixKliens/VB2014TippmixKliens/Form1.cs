using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VB2014TippmixKliens
{
    public partial class Form1 : Form
    {
        public Form1() {
            InitializeComponent();
            //this.BackColor = Color.FromArgb(0, 104, 0);
            menuStrip1.BackColor = Color.FromArgb(230, 181, 3);
            //this.msgFromServer.Text = "";
            this.menuStrip1.ForeColor = Color.Blue;
            
        }

        private void aCsoportToolStripMenuItem_Click(object sender, EventArgs e) {
            csoportok cs = new csoportok(0);
            cs.Show();
        }

        private void bCsoportToolStripMenuItem_Click(object sender, EventArgs e) {
            csoportok cs = new csoportok(1);
            cs.Show();
        }

        private void cCsoportToolStripMenuItem_Click(object sender, EventArgs e) {
            csoportok cs = new csoportok(2);
            cs.Show();
        }

        private void dCsoportToolStripMenuItem_Click(object sender, EventArgs e) {
            csoportok cs = new csoportok(3);
            cs.Show();
        }

        private void eCsoportToolStripMenuItem_Click(object sender, EventArgs e) {
            csoportok cs = new csoportok(4);
            cs.Show();
        }

        private void fCsoportToolStripMenuItem_Click(object sender, EventArgs e) {
            csoportok cs = new csoportok(5);
            cs.Show();
        }

        private void gCsoportToolStripMenuItem_Click(object sender, EventArgs e) {
            csoportok cs = new csoportok(6);
            cs.Show();
        }

        private void hCsoportToolStripMenuItem_Click(object sender, EventArgs e) {
            csoportok cs = new csoportok(7);
            cs.Show();
        }

        private void bejelentkezésToolStripMenuItem_Click(object sender, EventArgs e) {
            login l = new login();
            l.Show();
        }

        private void tIPPELEKToolStripMenuItem_Click(object sender, EventArgs e) {
            tippelek t = new tippelek();
            t.Show();
        }

       
    }
}
