using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;


namespace VisualDraw_1
{
    public abstract class Shape
    {
        public abstract void DrawWith(Graphics g);
    }
    public class Cross : Shape
    {
        int X, Y;
        Pen p = new Pen(Color.Red);
        public Cross(int _X, int _Y)
        {
            X = _X; Y = _Y;
        }
        public override void DrawWith(Graphics g)
        {
            g.DrawLine(p, X - 4, Y - 4, X + 4, Y + 4);
            g.DrawLine(p, X + 4, Y - 4, X - 4, Y + 4);
        }
    }

    public class Line : Shape
    {
        Point C, F;
        Pen p = new Pen(Color.Blue);
        public Line(Point _C, Point _F)
        {
            this.C = _C; this.F = _F;
        }
        public override void DrawWith(Graphics g)
        {
            g.DrawLine(p, C, F);
        }
    }
    public class Circle : Shape
    {
        Point a, b;
        Pen p = new Pen(Color.Blue);
        int r;
        public Circle(Point _a, Point _b)
        {
            a = _a;
            b = _b;
            r = Convert.ToInt32(Math.Sqrt(Math.Pow(a.X - b.X,2) + Math.Pow(a.Y - b.Y,2)));
        }
        public override void DrawWith(Graphics g)
        {
            g.DrawEllipse(p,a.X - r, a.Y - r, 2 * r, 2 * r);
        }
    }
}
