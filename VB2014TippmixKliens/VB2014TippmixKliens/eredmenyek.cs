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
    public partial class eredmenyek : Form
    {
        public eredmenyek(List<string> eredmenyek) {
            InitializeComponent();
            foreach (var item in eredmenyek) {
                this.listBox1.Items.Add(item);
            }
        }
    }
}
