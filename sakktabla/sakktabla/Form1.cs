using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace sakktabla
{
    public partial class Form1 : Form
    {
        Sakk s;
        public Form1() {
            InitializeComponent();
            s = new Sakk(this.CreateGraphics());
        }

        private void button1_Click(object sender, EventArgs e) {
            Thread szal1 = new Thread(s.DrawFromUp);
            Thread szal2 = new Thread(s.DrawFromDown);
            szal1.Start();
            szal2.Start();
        }
    }

    public class Sakk
    {
        int width;
        int width2;
        int height;
        int height2;
        SolidBrush b;
        SolidBrush b2;
        bool black;
        bool black2;
        Graphics g;

        public Sakk(Graphics g) {
            width = 0;
            height = 0;
            width2 = 350;
            height2 = 350;
            black = true;
            black2 = true;
            this.g = g;
        }

        public void DrawFromUp() {
            while ((width != width2) || (height != height2)) {
                //így váltakozik a szín
                if (black) {
                    b = new SolidBrush(Color.Black);
                    black = false;
                }
                else {
                    b = new SolidBrush(Color.White);
                    black = true;
                }

                Monitor.Enter(typeof(Program));
                g.FillRectangle(b, width, height, 50, 50);
                Monitor.Pulse(typeof(Program));
                Monitor.Wait(typeof(Program));
                Monitor.Exit(typeof(Program));

                width += 50;
                if (width > 350) {
                    height += 50;
                    width = 0;
                    black = !black;
                    
                }
            }
        }

        public void DrawFromDown() {
            while ((width != width2) || (height != height2)) {
                //így váltakozik a szín
                if (black2) {
                    b2 = new SolidBrush(Color.Black);
                    black2 = false;
                }
                else {
                    b2 = new SolidBrush(Color.White);
                    black2 = true;
                }

                Monitor.Enter(typeof(Program));
                g.FillRectangle(b2, width2, height2, 50, 50);
                Monitor.Pulse(typeof(Program));
                Monitor.Wait(typeof(Program));
                Monitor.Exit(typeof(Program));

                width2 -= 50;
                if (width2 < 0) {
                    height2 -= 50;
                    width2 = 350;
                    black2 = !black2;
                    
                }
            }
        }
    }
}
