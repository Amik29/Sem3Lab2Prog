﻿using System;
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
        protected int x;
        protected int y;

        static Size MaxSize
        {
            get
            {
                return MaxSize;
            }
            set
            {
                if (value.Width > MaxSize.Width) { throw new ArgumentException(""); }
            }
        }

        public int X
        {
            get { return x; }
            set
            {
                if (value < 0) { throw new ArgumentException("x<0!"); }
                else { x = value; }
            }
        }
        public int Y
        {
            get { return y; }
            set
            {
                if (value < 0) { throw new ArgumentException("y<0!"); }
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
