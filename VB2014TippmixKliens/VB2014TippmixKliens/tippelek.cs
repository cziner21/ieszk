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
    public partial class tippelek : Form
    {
        public string szerveruzenet;
        public List<string> tipplista = new List<string>();
        
        //List<string> ml;
        public string username;
        public SzerverClient kliens;
        public tippelek(SzerverClient kliens,string username) {
            InitializeComponent();

            this.username = username;
            this.kliens = kliens;
            dataGridView1.Columns.Add("e.sz", "Sorszám");
            dataGridView1.Columns.Add("e.nev", "Esemény neve");
            dataGridView1.Columns.Add("h", "H");
            dataGridView1.Columns.Add("d", "D");
            dataGridView1.Columns.Add("v", "V");

            try {
                foreach (string m in kliens.Meccslista()) {
                    dataGridView1.Rows.Add(m.Split(';'));
                }

                DataGridTextBoxColumn mireFogad = new DataGridTextBoxColumn();
                mireFogad.HeaderText = "TIPP";
                dataGridView1.Columns.Add("tipp", "TIPP");

                dataGridView1.AutoResizeColumns();
                dataGridView1.AutoSizeColumnsMode =
                    DataGridViewAutoSizeColumnsMode.AllCells;
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }

        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e) {
            string tipp;
            
            if (e.ColumnIndex == 2) {
                try {
                    tipp = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().ToUpper();
                    if (tipp.Length == 1 &&
                    tipp == "H" ||
                    tipp == "D" ||
                    tipp == "V")

                        tipplista.Add(dataGridView1.Rows[e.RowIndex].Cells[0].Value + ";" + tipp);


                    else
                        throw new Exception("Csak 1 betűt írhat be, ami vagy H, vagy D, vagy V");
                    
                }
                catch (Exception ex) {
                    MessageBox.Show(ex.Message, "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void fogadBtn_Click(object sender, EventArgs e) {
            if (username != null) {
                List<string> fogadottMeccsek = new List<string>();
                int fogadottMeccsekDataGrid = 0;
                int esemenyek = 0;
                int tet = 0;
                try {
                    esemenyek = int.Parse(esemenyekTbx.Text);
                    tet = int.Parse(tetTbx.Text);
                    if (esemenyek == 0) {
                        throw new Exception("Legalább 1 eseményre fogadni kell!");
                    }
                    else {
                        if (tet < 200) {
                            throw new Exception("Legalább 200 forint értékben kell fogadni!");
                        }
                        else {
                            if (tet > 100000) {
                                throw new Exception("A tét nem lehet nagyobb 100000 forintnál!");
                            }
                            else {
                                for (int i = 0; i < dataGridView1.Rows.Count; i++) {
                                    if (dataGridView1.Rows[i].Cells[5].Value != null) {
                                        fogadottMeccsekDataGrid++;
                                        fogadottMeccsek.Add(dataGridView1.Rows[i].Cells[0].Value + ";" + dataGridView1.Rows[i].Cells[1].Value + ";" + dataGridView1.Rows[i].Cells[5].Value.ToString().ToUpper());
                                    }
                                }
                                if (esemenyek != fogadottMeccsekDataGrid) {
                                    MessageBox.Show(fogadottMeccsekDataGrid.ToString());
                                    tipplista.Clear();
                                    throw new Exception("Nem egyezik a megjátszott események száma!");
                                }
                                else {
                                    string[] mikrefogad = new string[fogadottMeccsek.Count()];
                                    for (int i = 0; i < fogadottMeccsek.Count(); i++) {
                                        mikrefogad[i] = fogadottMeccsek[i];
                                    }

                                    kliens.Fogad(username, int.Parse(tetTbx.Text), mikrefogad);

                                    DialogResult dialogResult = MessageBox.Show("Sikeresen fogadtál\n" + kliens.SzelvenyInfo(), "Sikeres fogadás!", MessageBoxButtons.OK,MessageBoxIcon.Information);
                                    if (dialogResult == DialogResult.OK) {
                                        this.Close();
                                    }
                                    //MessageBox.Show("Sikeresen fogadtál\n" +
                                    //                 kliens.SzelvenyInfo());
                                    //Fogad(tet,tipplista);  szerver oldalon hozzárendelem a megfelelő oddsokat és beszorzom a téttel

                                }
                            }

                        }

                    }
                }
                catch (Exception ex) {
                    MessageBox.Show(ex.Message, "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
            }
            else {
                MessageBox.Show("Nem vagy belépve!");
            }
        }
    }
}
