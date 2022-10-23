using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sem3Lab2Prog
{
    internal class Rectangle : GraphObject
    {

        public override void Draw(Graphics G)
        {
            G.FillRectangle(brush, x, y, w, h);
            if (Selected)
            {
                G.DrawRectangle(Pens.Cyan, x, y, w, h);
            }
            else
            {
                G.DrawRectangle(Pens.Black, x, y, w, h);
            }
        }


        public Rectangle() : base()
        {
            w = 50;
            h = 50;

        }

        public override bool ContainsPoint(Point p)
        {
            return (p.X <= x + w && p.Y <= y + h && p.X >= x && p.Y >= y);
        }
    }
}
