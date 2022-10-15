using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sem3Lab2Prog
{
    internal class Ellipse : GraphObject
    {
        float a;
        float b;



        Ellipse() : base(){
            a = 80;
            b = 60;
        }

        override public void Draw(Graphics G)
        {
            G.FillEllipse(brush, x, y, a, b);
            if (Selected) G.DrawEllipse(Pens.Red, x, y, a, b);
            else G.DrawEllipse(Pens.Blue, x, y, a, b);
        }

       override public bool ContainsPoint(Point p)
        {
            float Cx = a / 2.0f;
            float Cy = b / 2.0f;
            return ((((p.X - Cx) * (p.X + Cx)) / (a * a) - (p.Y - Cy) * (p.Y + Cy) / (b * b)) <= 1);
        }
    }
}
