using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Sem3Lab2Prog
{
    abstract class GraphObject
    {
        static Random r = new Random();


        protected Color c;
        protected float x;
        protected float y;

        protected int w;
        protected int h;



        public static Size MaxSize { get; set; }


        public float X
        {
            get { return x; }
            set
            {
                if (value+w >= MaxSize.Width) { throw new ArgumentException("x<0!"); }
                else { x = value; }
            }
        }
        public float Y
        {
            get { return y; }
            set
            {
                if (value+h >= MaxSize.Height) { throw new ArgumentException("y<0!"); }
                else { y = value; }
            }
        }

        public bool Selected { get; set; }

        protected SolidBrush brush;
        public GraphObject()
        {
            Color[] cols = {Color.Red, Color.Green, Color.Yellow, Color.Tomato, Color.Cyan};
            c = cols[r.Next(cols.Length)];
            x = r.Next(200);
            y = r.Next(200);
            brush = new SolidBrush(c);
        }
        abstract public void Draw(Graphics G);

        abstract public bool ContainsPoint(Point p);



    }
}
