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
        public abstract void SaveTo(StreamWriter sw);
    }
    public class Cross : Shape
    {
        int X, Y;
        Pen p = new Pen(Color.Red);
        public Cross(int _X, int _Y)
        {
            X = _X; Y = _Y;
        }
        public override void SaveTo(StreamWriter sw)
        {
            sw.WriteLine("Cross");
            sw.Write(Convert.ToString(X));
            sw.Write(' ');
            sw.WriteLine(Convert.ToString(Y));
        }
        public override void DrawWith(Graphics g)
        {
            g.DrawLine(p, X - 4, Y - 4, X + 4, Y + 4);
            g.DrawLine(p, X + 4, Y - 4, X - 4, Y + 4);
        }
        public Cross(StreamReader _sr)
        {
            string line = _sr.ReadLine();
            string[] str = line.Split(' ');
            X = Convert.ToInt32(str[0]);
            Y = Convert.ToInt32(str[1]);
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
        public override void SaveTo(StreamWriter sw)
        {
            sw.WriteLine("Line");
            sw.Write(Convert.ToString(C.X));
            sw.Write(' ');
            sw.Write(Convert.ToString(C.Y));
            sw.Write(' ');
            sw.Write(Convert.ToString(F.X));
            sw.Write(' ');
            sw.WriteLine(Convert.ToString(F.Y));
        }
        public Line(StreamReader _sr)
        {
            string line = _sr.ReadLine();
            string[] str = line.Split(' ');
            C.X = Convert.ToInt32(str[0]);
            C.Y = Convert.ToInt32(str[1]);
            F.X = Convert.ToInt32(str[2]);
            F.Y = Convert.ToInt32(str[3]);
        }
    }
    public class Circle : Shape
    {
        Point C, P;
        Pen p = new Pen(Color.Blue);
        int r;
        public Circle(Point _C, Point _P)
        {
            C = _C;
            P = _P;
            r = Convert.ToInt32(Math.Sqrt(Math.Pow(C.X - P.X,2) + Math.Pow(C.Y - P.Y,2)));
        }
        public override void DrawWith(Graphics g)
        {
            g.DrawEllipse(p,C.X - r, C.Y - r, 2 * r, 2 * r);
        }
        public override void SaveTo(StreamWriter sw)
        {
            sw.WriteLine("Circle");
            sw.Write(Convert.ToString(C.X));
            sw.Write(' ');
            sw.Write(Convert.ToString(C.Y));
            sw.Write(' ');
            sw.WriteLine(Convert.ToString(r));
        }
        public Circle(StreamReader _sr)
        {
            string line = _sr.ReadLine();
            string[] str = line.Split(' ');
            C.X = Convert.ToInt32(str[0]);
            C.Y = Convert.ToInt32(str[1]);
            r = Convert.ToInt32(str[2]);
        }
    }
}
