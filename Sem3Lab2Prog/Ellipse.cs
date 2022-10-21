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



        public Ellipse() : base(){
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
            float halfA = a / 2.0f;
            float halfB = b / 2.0f;
            float centerX = x + halfA;
            float centerY = y + halfB;
            double dx = Math.Pow(p.X - centerX,2);
            double dy = Math.Pow(p.Y - centerY, 2);



            return ((dx / (halfA * halfA) + (dy / (halfB * halfB))) <= 1);
        }
    }
}
