using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
/*
         *TODO: Uloha
         *Nakresli okolo obdlznika ciaru
         *Vykreslednie trojuholniku ktoreho zaciatok bude na mieste kde uz. klikol mysou
         *Kreslenie pomocou mysi
         *Vymazanie pomocou kliknutia pravym tlacitkom 
*/
namespace cviko1
{
    public partial class Form1 : Form
    {
        private Rectangle RcDraw;

        public Form1()
        {
            InitializeComponent();
        }



        private void Form1_Load(object sender, EventArgs e)
        {
   
        }
        

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            RcDraw.X = e.X;
            RcDraw.Y = e.Y;
            this.Invalidate();
        }

        private void Form1_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {

        }

        private void Form1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {

            Graphics g = e.Graphics;

            /*
             Pen pn = new Pen(Color.Blue);
             Rectangle rect = new Rectangle(50, 50, 100, 100);
             g.DrawArc(pn, rect, 12, 84);
            */

            /*
            Pen pn = new Pen(Color.Blue);
            Point pt1 = new Point(20, 20);
            Point pt2 = new Point(100, 100);
            g.DrawLine(pn, pt1, pt2);
            */

            /*
            Pen pn = new Pen(Color.Red,100);
            Rectangle rect = new Rectangle(50, 50, 100, 200);
            g.DrawEllipse(pn, rect);
            */

            /*
            g.FillRectangle(new SolidBrush(Color.White), ClientRectangle);
            GraphicsPath path = new GraphicsPath(new Point[] {
                new Point(40,140),
                new Point(275,200),
                new Point(105,225),
                new Point(190,300),
                new Point(50,350),
                new Point(20,180)
            },
            new byte[] { 
                (byte)PathPointType.Start,
                 (byte)PathPointType.Bezier,
                  (byte)PathPointType.Bezier,
                   (byte)PathPointType.Bezier,
                    (byte)PathPointType.Line,
                     (byte)PathPointType.Line,
            });
            PathGradientBrush pgn = new PathGradientBrush(path);
            pgn.SurroundColors = new Color[] {
                Color.Green,
                Color.Yellow,
                Color.Red,
                Color.Beige,
                Color.White
            };
            g.FillPath(pgn, path);
            */

            /*
            Font fnt = new Font("Times new romane", 16);
            g.DrawString("GDI+", fnt, new SolidBrush(Color.Red), 14, 20);
            */

            Rectangle rect = new Rectangle(RcDraw.X, RcDraw.Y, 100, 100);

            using (LinearGradientBrush LGB = new LinearGradientBrush(rect, Color.Red, Color.Blue, LinearGradientMode.BackwardDiagonal))
            {
                g.FillRectangle(LGB, rect);
            };
        }
    }
}
