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
    public partial class tippelek : Form
    {
        public List<string> tipplista = new List<string>();
        public tippelek() {
            InitializeComponent();

            dataGridView1.Columns.Add("e.sz", "Sorszám");
            dataGridView1.Columns.Add("e.nev", "Esemény neve");

            /*DataGridViewCheckBoxColumn cbcH = new DataGridViewCheckBoxColumn();
            cbcH.Name = "hazai";
            cbcH.HeaderText = "H";
            cbcH.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns.Add(cbcH);

            DataGridViewCheckBoxColumn cbcD = new DataGridViewCheckBoxColumn();
            cbcD.Name = "dontetlen";
            cbcD.HeaderText = "D";
            cbcD.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns.Add(cbcD);

            DataGridViewCheckBoxColumn cbcV = new DataGridViewCheckBoxColumn();
            cbcV.Name = "vendeg";
            cbcV.HeaderText = "V";
            cbcV.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns.Add(cbcV);*/

            DataGridTextBoxColumn mireFogad = new DataGridTextBoxColumn();
            mireFogad.HeaderText = "TIPP";
            dataGridView1.Columns.Add("tipp", "TIPP");

            dataGridView1.Rows.Add("001", "Brazília-Horvátosrzság");
            dataGridView1.Rows.Add("002", "asd-wsc");
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
                    //MessageBox.Show(tipp);
                }
                catch (Exception ex) {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e) {
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
                                if (dataGridView1.Rows[i].Cells[2].Value != null)
                                    fogadottMeccsekDataGrid++;
                            }
                            if (esemenyek != fogadottMeccsekDataGrid) {
                                tipplista.Clear();
                                throw new Exception("Nem egyezik a megjátszott események száma!");
                            }
                            else {
                                //Fogad(tet,tipplista);  szerver oldalon hozzárendelem a megfelelő oddsokat és beszorzom a téttel
                                

                            }
                        }

                    }

                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }

            foreach (string tipp in tipplista) {
                MessageBox.Show(tipp);
            }
        }
    }
}
