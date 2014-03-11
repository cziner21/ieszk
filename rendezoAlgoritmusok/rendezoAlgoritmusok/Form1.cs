using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace rendezoAlgoritmusok
{
    public partial class Form1 : Form
    {
        Rendez r;
        Random rnd = new Random();

        public Form1() {
            InitializeComponent();
            fillLists(bubbleSortList,quickSortList);
            r = new Rendez(this,bubbleSortList, quickSortList);
            
        }

        public void SetorderedBubble(List<int> l1) {
            foreach (int x in l1) {
                this.orderedBubble.Items.Add(x);
            }
        }

        public void SetorderedQuick(List<int> l2) {
            foreach (int x in l2) {
                this.orderedQuick.Items.Add(x);
            }
        }

        private void button1_Click(object sender, EventArgs e) {
            
            Thread szal1 = new Thread(r.BubbleSort);
            Thread szal2 = new Thread(r.QuickSort);
            szal1.Start();
            szal2.Start();
        }

        private void fillLists(ListBox lbox, ListBox l2box){           
            for(int i = 0; i < 20; i++){
                lbox.Items.Add(rnd.Next(0,5001));
            }
            for (int i = 0; i < lbox.Items.Count; i++) {
                l2box.Items.Add(lbox.Items[i]);
            }
        }

        
    }

    public class Rendez
    {
        
        public List<int> l1 = new List<int>();
        public List<int> l2 = new List<int>();
        Form1 f;
        
        public Rendez(Form1 f, ListBox lbox1, ListBox lbox2) {           
            foreach (int x in lbox1.Items) {
                l1.Add(x);
                l2.Add(x);
            }
            this.f = f;
        }

        public void BubbleSort() {
            int csere = 0;

            for (int i = l1.Count; i > 1; i--) {
                for (int j = 0; j < i - 1; j++) {
                    if (l1[j] > l1[j + 1]) {
                        csere = l1[j];
                        l1[j] = l1[j + 1];
                        l1[j + 1] = csere;
                    }
                }
            }

            Monitor.Enter(typeof(Program));
            f.Invoke((MethodInvoker)delegate() {
                f.SetorderedBubble(l1);
            });
            Monitor.Pulse(typeof(Program));
            Monitor.Wait(typeof(Program));
            Monitor.Exit(typeof(Program));
        }

        public void QuickSort() {
            l2.Sort();

            Monitor.Enter(typeof(Program));
            f.Invoke((MethodInvoker)delegate() {
                f.SetorderedQuick(l2);
            });
            Monitor.Pulse(typeof(Program));
            Monitor.Wait(typeof(Program));
            Monitor.Exit(typeof(Program));
        }
    }
}
