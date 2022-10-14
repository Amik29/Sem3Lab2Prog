using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Sem3Lab2Prog
{
    internal class GraphObject
    {
        static Random r = new Random();
        Color c;
        private int x;
        private int y;
        private int w;
        private int h;

        int X
        {
            get { return x; }
            set
            {
                if (value < 0) { throw new ArgumentException("x<0!"); }
                else { x = value; }
            }
        }
        int Y
        {
            get { return y; }
            set
            {
                if (value < 0) { throw new ArgumentException("x<0!"); }
                else { y = value; }
            }
        }
        SolidBrush brush;
        public GraphObject()
        {
            Color[] cols = {Color.Red, Color.Green, Color.Yellow, Color.Tomato, Color.Cyan};
            c = cols[r.Next(cols.Length)];
            x = r.Next(200);
            y = r.Next(200);
            w = 50;
            h = 50;
            brush = new SolidBrush(c);
        }
        public void Draw(Graphics G)
        {
            G.FillRectangle(brush, x, y, w, h);
            G.DrawRectangle(Pens.Black, x, y, w, h);
        }
    }
}
