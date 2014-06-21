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
using System.IO;

namespace VB2014TippmixKliens
{
    
    public partial class vezerlo : Form
    {
        public string username;
        SzerverClient kliens;

        public vezerlo(SzerverClient kliens,string username) {
            InitializeComponent();
            this.kliens = kliens;
            this.username = username;
            this.Text = "";
            this.Text = "Vezérlő -- " + username;
            usernameLbl.Text = "";
            usernameLbl.Text = "Üdv, " + username;
        }

        private void fogadasBtn_Click(object sender, EventArgs e) {
            using (var t = new tippelek(kliens, username)) {
                t.ShowDialog(this);
            }
        }

        private void egyenlegBtn_Click(object sender, EventArgs e) {
            if (username != null)
                MessageBox.Show("Az aktuális egyenleged: \n" + kliens.egyenleg(username));
            else
                MessageBox.Show("Nem vagy belépve!");
        }

        private void generalBtn_Click(object sender, EventArgs e) {
            List<string> eredmenyek = new List<string>();
            eredmenyek = kliens.EredmenytGeneral().ToList();
            var er = new eredmenyek(eredmenyek);
            er.Show();

            //DateTime time = DateTime.Today;
            string currentTime = DateTime.Now.ToString("yyyy-MM-dd--HH-mm-ss");
            string filename = "D:\\";
            filename += currentTime;
            filename += ".log";
            MessageBox.Show(filename);

            StreamWriter w = new StreamWriter(filename, true, Encoding.UTF8);
            foreach (var item in eredmenyek) {
                w.WriteLine(item);
            }
            w.Close();
            MessageBox.Show(kliens.NyertemE());
        }

        private void szelvenyemBtn_Click(object sender, EventArgs e) {
            MessageBox.Show(kliens.SzelvenyInfo());
        }

        private void kilepBtn_Click(object sender, EventArgs e) {
            try {
                if (kliens.Kilepes()) {
                    DialogResult dialogResult = MessageBox.Show("Sikeresen kiléptél!", "Sikeres kilépés!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (dialogResult == DialogResult.OK) {
                        this.Close();
                    }
                }
                else
                    throw new Exception("Nem voltál belépve!");
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
                login l = new login();
                l.Show();
                this.Close();
            }
        }
    }
}
