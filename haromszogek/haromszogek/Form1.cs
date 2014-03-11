using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;


namespace haromszogek
{
    public partial class Form1 : Form
    {
        Haromszog h1;
        Haromszog h2;
        //Haromszog h3;
        public Form1() {
            InitializeComponent();
            h1 = new Haromszog(this.CreateGraphics(), new SolidBrush(Color.Tomato),true);
            h2 = new Haromszog(this.CreateGraphics(), new SolidBrush(Color.SteelBlue),false);
            //h3 = new Haromszog(this.CreateGraphics(), new SolidBrush(Color.LightGreen));
        }

        private void button1_Click(object sender, EventArgs e) {
            Thread szal1 = new Thread(h1.Draw1);
            Thread szal2 = new Thread(h2.Draw2);
            //Thread szal3 = new Thread(h3.Draw1);
            szal1.Start();
            szal2.Start();
            //szal3.Start();
        }

        public System.Drawing.Drawing2D.SmoothingMode SmoothingMode { get; set; }
    }

    public class Haromszog
    {
        Graphics g;
        Random rnd = new Random();
        SolidBrush color1;
        SolidBrush color2;

        public Haromszog(Graphics g, SolidBrush color, bool elsoE) {
            this.g = g;
            if (elsoE)
                this.color1 = color;
            else
                this.color2 = color;
        }

        public void Draw1() {
            Point[] points = { new Point(rnd.Next(0,350),rnd.Next(0,350)), new Point(rnd.Next(0,350),rnd.Next(0,350)), new Point(rnd.Next(0,350),rnd.Next(0,350)) }; //new Point(150, 150), new Point(100, 100), new Point(150, 100)
            Monitor.Enter(typeof(Program));
            g.FillPolygon(color1, points);
            Monitor.Pulse(typeof(Program));
            Monitor.Wait(typeof(Program));
            Monitor.Exit(typeof(Program));
        }

        public void Draw2() {
            Point[] points = { new Point(rnd.Next(0, 350), rnd.Next(0, 350)), new Point(rnd.Next(0, 350), rnd.Next(0, 350)), new Point(rnd.Next(0, 350), rnd.Next(0, 350)) }; //new Point(150, 150), new Point(100, 100), new Point(150, 100)
            Monitor.Enter(typeof(Program));
            g.FillPolygon(color2, points);
            Monitor.Pulse(typeof(Program));
            Monitor.Wait(typeof(Program));
            Monitor.Exit(typeof(Program));
        }
    }
}
