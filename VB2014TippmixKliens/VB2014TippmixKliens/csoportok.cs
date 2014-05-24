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
    public partial class csoportok : Form
    {
        
        public csoportok(int index) {
            InitializeComponent();
            fillDataGrid();
            colorDatagrid(dataGridView1);
            colorDatagrid(dataGridView2);
            colorDatagrid(dataGridView3);
            colorDatagrid(dataGridView4);
            colorDatagrid(dataGridView5);
            colorDatagrid(dataGridView6);
            colorDatagrid(dataGridView7);
            colorDatagrid(dataGridView8);
            switch (index) {
                case 0:
                    this.tabControl1.SelectedTab = aCsop;                   
                    break;
                case 1:
                    this.tabControl1.SelectedTab = bCsop;
                    break;
                case 2:
                    this.tabControl1.SelectedTab = cCsop;
                    break;
                case 3:
                    this.tabControl1.SelectedTab = dCsop;
                    break;
                case 4:
                    this.tabControl1.SelectedTab = eCsop;
                    break;
                case 5:
                    this.tabControl1.SelectedTab = fCsop;
                    break;
                case 6:
                    this.tabControl1.SelectedTab = gCsop;
                    break;
                case 7:
                    this.tabControl1.SelectedTab = hCsop;
                    break;
                default:
                    this.tabControl1.SelectedTab = aCsop;
                    break;
            }
        }

        private void fillDataGrid() {
            #region fejlécek
            dataGridView1.Columns.Add("date", "Dátum, kezdési idő");
            dataGridView1.Columns.Add("place", "Helyszín");
            dataGridView1.Columns.Add("vs", "Párosítás");

            dataGridView2.Columns.Add("date", "Dátum, kezdési idő");
            dataGridView2.Columns.Add("place", "Helyszín");
            dataGridView2.Columns.Add("vs", "Párosítás");

            dataGridView3.Columns.Add("date", "Dátum, kezdési idő");
            dataGridView3.Columns.Add("place", "Helyszín");
            dataGridView3.Columns.Add("vs", "Párosítás");

            dataGridView4.Columns.Add("date", "Dátum, kezdési idő");
            dataGridView4.Columns.Add("place", "Helyszín");
            dataGridView4.Columns.Add("vs", "Párosítás");

            dataGridView5.Columns.Add("date", "Dátum, kezdési idő");
            dataGridView5.Columns.Add("place", "Helyszín");
            dataGridView5.Columns.Add("vs", "Párosítás");

            dataGridView6.Columns.Add("date", "Dátum, kezdési idő");
            dataGridView6.Columns.Add("place", "Helyszín");
            dataGridView6.Columns.Add("vs", "Párosítás");

            dataGridView7.Columns.Add("date", "Dátum, kezdési idő");
            dataGridView7.Columns.Add("place", "Helyszín");
            dataGridView7.Columns.Add("vs", "Párosítás");

            dataGridView8.Columns.Add("date", "Dátum, kezdési idő");
            dataGridView8.Columns.Add("place", "Helyszín");
            dataGridView8.Columns.Add("vs", "Párosítás"); 
            #endregion
           
            dataGridView1.Rows.Add("2014. 06. 12., 22:00", "Sao Paulo", "Brazília–Horvátország");
            dataGridView1.Rows.Add("2014. 06. 13., 18:00", "Natal", "Mexikó–Kamerun");
            dataGridView1.Rows.Add("2014. 06. 17., 21:00", "Fortaleza", "Brazília–Mexikó");
            dataGridView1.Rows.Add("2014. 06. 19., 00:00", "Manaus", "Kamerun–Horvátország");
            dataGridView1.Rows.Add("2014. 06. 23., 22:00", "Brazíliaváros", "Kamerun–Brazília");
            dataGridView1.Rows.Add("2014. 06. 23., 22:00", "Recife", "Horvátország–Mexikó");

            dataGridView2.Rows.Add("2014. 06. 13., 21:00", "Salvador", "Spanyolország–Hollandia");
            dataGridView2.Rows.Add("2014. 06. 13., 18:00", "Cuiabá", "Chile–Ausztrália");
            dataGridView2.Rows.Add("2014. 06. 17., 21:00", "Porto Alegre", "Ausztrália–Hollandia");
            dataGridView2.Rows.Add("2014. 06. 19., 00:00", "Rio De Janeiro", "Spanyolország–Chile");
            dataGridView2.Rows.Add("2014. 06. 23., 22:00", "Curitiba", "Ausztrália–Spanyolország");
            dataGridView2.Rows.Add("2014. 06. 23., 22:00", "Sao Paulo", "Hollandia–Chile");

            dataGridView3.Rows.Add("2014. 06. 12., 22:00", "Sao Paulo", "Brazília–Horvátország");
            dataGridView3.Rows.Add("2014. 06. 13., 18:00", "Natal", "Mexikó–Kamerun");
            dataGridView3.Rows.Add("2014. 06. 17., 21:00", "Fortaleza", "Brazília–Mexikó");
            dataGridView3.Rows.Add("2014. 06. 19., 00:00", "Manaus", "Kamerun–Horvátország");
            dataGridView3.Rows.Add("2014. 06. 23., 22:00", "Brazíliaváros", "Kamerun–Brazília");
            dataGridView3.Rows.Add("2014. 06. 23., 22:00", "Recife", "Horvátország–Mexikó");

            dataGridView4.Rows.Add("2014. 06. 12., 22:00", "Sao Paulo", "Brazília–Horvátország");
            dataGridView4.Rows.Add("2014. 06. 13., 18:00", "Natal", "Mexikó–Kamerun");
            dataGridView4.Rows.Add("2014. 06. 17., 21:00", "Fortaleza", "Brazília–Mexikó");
            dataGridView4.Rows.Add("2014. 06. 19., 00:00", "Manaus", "Kamerun–Horvátország");
            dataGridView4.Rows.Add("2014. 06. 23., 22:00", "Brazíliaváros", "Kamerun–Brazília");
            dataGridView4.Rows.Add("2014. 06. 23., 22:00", "Recife", "Horvátország–Mexikó");

            dataGridView5.Rows.Add("2014. 06. 12., 22:00", "Sao Paulo", "Brazília–Horvátország");
            dataGridView5.Rows.Add("2014. 06. 13., 18:00", "Natal", "Mexikó–Kamerun");
            dataGridView5.Rows.Add("2014. 06. 17., 21:00", "Fortaleza", "Brazília–Mexikó");
            dataGridView5.Rows.Add("2014. 06. 19., 00:00", "Manaus", "Kamerun–Horvátország");
            dataGridView5.Rows.Add("2014. 06. 23., 22:00", "Brazíliaváros", "Kamerun–Brazília");
            dataGridView5.Rows.Add("2014. 06. 23., 22:00", "Recife", "Horvátország–Mexikó");

            dataGridView6.Rows.Add("2014. 06. 12., 22:00", "Sao Paulo", "Brazília–Horvátország");
            dataGridView6.Rows.Add("2014. 06. 13., 18:00", "Natal", "Mexikó–Kamerun");
            dataGridView6.Rows.Add("2014. 06. 17., 21:00", "Fortaleza", "Brazília–Mexikó");
            dataGridView6.Rows.Add("2014. 06. 19., 00:00", "Manaus", "Kamerun–Horvátország");
            dataGridView6.Rows.Add("2014. 06. 23., 22:00", "Brazíliaváros", "Kamerun–Brazília");
            dataGridView6.Rows.Add("2014. 06. 23., 22:00", "Recife", "Horvátország–Mexikó");

            dataGridView7.Rows.Add("2014. 06. 12., 22:00", "Sao Paulo", "Brazília–Horvátország");
            dataGridView7.Rows.Add("2014. 06. 13., 18:00", "Natal", "Mexikó–Kamerun");
            dataGridView7.Rows.Add("2014. 06. 17., 21:00", "Fortaleza", "Brazília–Mexikó");
            dataGridView7.Rows.Add("2014. 06. 19., 00:00", "Manaus", "Kamerun–Horvátország");
            dataGridView7.Rows.Add("2014. 06. 23., 22:00", "Brazíliaváros", "Kamerun–Brazília");
            dataGridView7.Rows.Add("2014. 06. 23., 22:00", "Recife", "Horvátország–Mexikó");

            dataGridView8.Rows.Add("2014. 06. 12., 22:00", "Sao Paulo", "Brazília–Horvátország");
            dataGridView8.Rows.Add("2014. 06. 13., 18:00", "Natal", "Mexikó–Kamerun");
            dataGridView8.Rows.Add("2014. 06. 17., 21:00", "Fortaleza", "Brazília–Mexikó");
            dataGridView8.Rows.Add("2014. 06. 19., 00:00", "Manaus", "Kamerun–Horvátország");
            dataGridView8.Rows.Add("2014. 06. 23., 22:00", "Brazíliaváros", "Kamerun–Brazília");
            dataGridView8.Rows.Add("2014. 06. 23., 22:00", "Recife", "Horvátország–Mexikó");

            #region autoszélesség
            dataGridView1.AutoResizeColumns();
            dataGridView1.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView2.AutoResizeColumns();
            dataGridView2.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView3.AutoResizeColumns();
            dataGridView3.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView4.AutoResizeColumns();
            dataGridView4.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView5.AutoResizeColumns();
            dataGridView5.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView6.AutoResizeColumns();
            dataGridView6.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView7.AutoResizeColumns();
            dataGridView7.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView8.AutoResizeColumns();
            dataGridView8.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.AllCells; 
            #endregion
        }

        private void colorDatagrid(DataGridView dname) {
            for (int i = 0; i < dname.Rows.Count; i++) {
                if (i % 2 == 0) {
                    dname.Rows[i].DefaultCellStyle.BackColor = Color.LightBlue;
                }
                else {
                    dname.Rows[i].DefaultCellStyle.BackColor = Color.White;
                }
            }
        }
        
    }
}
