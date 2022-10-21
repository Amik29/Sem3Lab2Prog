using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sem3Lab2Prog
{
    internal class TwoTypeFactory : IGraphicFactory
    {
        bool typefigure= false;
        public TwoTypeFactory()
        {

        }

        public GraphObject CreateGraphObject()
        {
            if (typefigure)
            {
                Rectangle go = new Rectangle();
                typefigure= false;
                return go;
            }
            else
            {
                Ellipse go = new Ellipse();
                typefigure = true;
                return go;
            }
        }
    }
}
