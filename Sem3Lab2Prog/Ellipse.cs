using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sem3Lab2Prog
{
    internal class Ellipse : GraphObject
    {


        public Ellipse() : base(){
            w = 80;
            h = 60;
        }

        override public void Draw(Graphics G)
        {
            G.FillEllipse(brush, x, y, w, h);
            if (Selected) G.DrawEllipse(Pens.Red, x, y, w, h);
            else G.DrawEllipse(Pens.Blue, x, y, w, h);
        }

       override public bool ContainsPoint(Point p)
        {
            float halfA = w / 2.0f;
            float halfB = h / 2.0f;
            float centerX = x + halfA;
            float centerY = y + halfB;
            double dx = Math.Pow(p.X - centerX,2);
            double dy = Math.Pow(p.Y - centerY, 2);



            return ((dx / (halfA * halfA) + (dy / (halfB * halfB))) <= 1);
        }
    }
}
