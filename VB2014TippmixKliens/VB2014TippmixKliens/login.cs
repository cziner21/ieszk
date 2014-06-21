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
    public partial class login : Form
    {
        public SzerverClient kliens = new SzerverClient();
        public string username;
        public string szerveruzenet;
        //public list<string> eredmenyek = new list<string>();
        public login() {
            InitializeComponent();
            //this.BackColor = Color.FromArgb(0, 104, 0);
        }

        private void loginBtn_Click(object sender, EventArgs e) {
            try {
                
                //siker= k.Bejelentkezes(userTbx.Text, passwordTbx.Text);
                
                
                if (kliens.Bejelentkezes(userTbx.Text, passwordTbx.Text)) {
                    MessageBox.Show("siker");
                    string nev = kliens.UserName();
                    username = nev;
                    szerveruzenet = "Kapcsolat létrejött a szerverrel...";
                    

                    vezerlo v = new vezerlo(kliens,username);
                    v.Show();
                    v.Focus();
                    this.Close();
                   /* using (var v = new vezerlo(kliens,username)) {
                        v.ShowDialog(this);
                    }*/
                    
                }
                else {
                    MessageBox.Show("nem siker");
                    szerveruzenet = "Nem sikerült kapcsolódni a szerverhez...";
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        /*private void fogadasBtn_Click(object sender, EventArgs e) {
            using (var t = new tippelek(kliens,username)) {
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
            
            StreamWriter w = new StreamWriter(@"D:\eredmenyek.log", true, Encoding.UTF8);
            foreach (var item in eredmenyek) {
                w.WriteLine(item);
            }
            w.Close();

            
        }

        private void kilepBtn_Click(object sender, EventArgs e) {
            try {
                if (kliens.Kilepes())
                    MessageBox.Show("Sikeresen kiléptél!");
                else
                    throw new Exception("Nem voltál belépve!");
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }*/

        
    }
}
