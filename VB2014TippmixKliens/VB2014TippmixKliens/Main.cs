using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ServiceModel;
using System.ServiceModel.Description;
using VB2014TippmixKliens.ServiceReference1;

namespace VB2014TippmixKliens
{
    

    public partial class Main : Form
    {
        public static SzerverClient kliens = new SzerverClient();
        public static string username;
        public static double egyenleg;
        

        public Main() {
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
            using (var f = new login()) {
                f.ShowDialog(this);
                this.msgFromServer.Text = f.szerveruzenet;
                username = f.username;
                
            }
            
        }

        private void tIPPELEKToolStripMenuItem_Click(object sender, EventArgs e) {
            
            using (var t = new tippelek(kliens,username)) {
                t.ShowDialog(this);
                this.msgFromServer.Text = t.szerveruzenet;
            }
        }

        private void button1_Click(object sender, EventArgs e) {
            //SzerverClient kliens = new SzerverClient();
            
        }

        public void uzenet(string msg) {
            msgFromServer.Text = "";
            msgFromServer.Text = msg;
        }

        private void egyenlegToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
                MessageBox.Show(username);
                egyenleg = kliens.egyenleg(username);
                msgFromServer.Text = "";
                msgFromServer.Text="Az egyenleged: " + egyenleg;
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void kilépésToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
                if (kliens.Kilepes())
                    MessageBox.Show("Sikeresen kiléptél");
                else
                    MessageBox.Show("Nem sikerült kilépni, valószínűleg be sem voltál lépve...");
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void fájlToolStripMenuItem_Click(object sender, EventArgs e) {
            using (var f = new login()) {
                f.ShowDialog(this);
                this.msgFromServer.Text = f.szerveruzenet;
                username = f.username;

            }
        }

       
    }

    
}
