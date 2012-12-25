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
}
