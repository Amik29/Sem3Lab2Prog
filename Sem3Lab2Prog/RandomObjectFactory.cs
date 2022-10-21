using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sem3Lab2Prog
{
    internal class RandomObjectFactory: IGraphicFactory
    {
        public RandomObjectFactory() 
        {

        }

        public GraphObject CreateGraphObject()
        {
          Random random = new Random();
            if (random.Next(0, 2) == 1)
            {
                Rectangle go = new Rectangle();

                return go;
            }
            else
            {
                Ellipse go = new Ellipse();
               
                return go;
            }
        }


    }
}
