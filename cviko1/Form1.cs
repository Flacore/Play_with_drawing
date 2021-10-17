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
        private int Button_case;
        private Rectangle RcDraw;
        private List<Point> points_circle;
        private List<Point> points;

        public Form1()
        {
            Button_case = 1;

            points = new List<Point>();
            Point tmp = new Point(0,0);
            points.Add(tmp);

            points_circle = new List<Point>();
            points_circle.Add(tmp);

            InitializeComponent();
        }



        private void Form1_Load(object sender, EventArgs e)
        {
   
        }
        

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            /*
            RcDraw.X = e.X;
            RcDraw.Y = e.Y;
            this.Invalidate();
            */
            if (e.Clicks == 1)
            {
                if (e.Button == MouseButtons.Left)
                {
                    Point tmp = new Point(e.X, e.Y);
                    points.Add(tmp);
                    this.Invalidate();
        }
                else
                {
                    points.Clear();
                    this.Invalidate();
                };
            }
            else {
                if (e.Button == MouseButtons.Left)
                {
                    if (points_circle.Count >= 2)
                        points_circle.Clear();
                    Point tmp = new Point(e.X, e.Y);
                    points_circle.Add(tmp);
                    this.Invalidate();
                }
                else
                {
                    points_circle.Clear();
                    this.Invalidate();
                };
            }
        }

        private void Form1_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {

        }

        private void Form1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            Pen pn;
            Rectangle rect;
            Graphics g = e.Graphics;

            switch (Button_case)
            {
                case 1:
                    pn = new Pen(Color.Blue);
                    rect = new Rectangle(50, 50, 100, 100);
             g.DrawArc(pn, rect, 12, 84);
                    break;
                case 2:
                    pn = new Pen(Color.Blue);
                    Point pt1 = new Point(50, 50);
                    Point pt2 = new Point(200, 100);
            g.DrawLine(pn, pt1, pt2);
                    break;
                case 3:
                    pn = new Pen(Color.Red, 100);
                    rect = new Rectangle(200, 200, 100, 50);
            g.DrawEllipse(pn, rect);
                    break;
                case 4:
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
                    break;
                case 5:
            Font fnt = new Font("Times new romane", 16);
            g.DrawString("GDI+", fnt, new SolidBrush(Color.Red), 14, 20);
                    break;
                case 6:
                    rect = new Rectangle(RcDraw.X, RcDraw.Y, 100, 100);

            using (LinearGradientBrush LGB = new LinearGradientBrush(rect, Color.Red, Color.Blue, LinearGradientMode.BackwardDiagonal))
            {
                g.FillRectangle(LGB, rect);
            };
                    break;
                case 7:
                    if (points.Count > 1)
                    {
                        pn = new Pen(Color.Blue);
                        g.DrawLines(pn, points.ToArray());
                    };
                    break;
                case 8:
                    if (points.Count == 2)
                    {
                        pn = new Pen(Color.Red, 100);
                        rect = new Rectangle(points[0].X, points[0].Y, points[1].X - points[0].X, points[1].Y - points[0].Y);
                        g.DrawEllipse(pn, rect);
                        points.Clear();
                    };
                    break;
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Button_case = 1;
            this.Invalidate();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Button_case = 2;
            this.Invalidate();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Button_case = 3;
            this.Invalidate();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Button_case = 4;
            this.Invalidate();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Button_case = 5;
            this.Invalidate();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Button_case = 6;
            this.Invalidate();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Button_case = 7;
            points.Clear();
            this.Invalidate();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Button_case = 8;
            points.Clear();
            this.Invalidate();
        }
    }
}
