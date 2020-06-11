using System;
using System.Collections.Generic;
using System.Text;

namespace TaskMartianRobots
{
    class Surface
    {
        public int XAxisMax { get; set; }
        public int YAxisMax{ get; set; }

        public Surface(int xAxisLength, int yAxisLength)
        {
            if (xAxisLength > 50 || yAxisLength > 50)
            {
                throw new OutOfConstraintsException("The maximum value for any coordinate is 50");
            }
            
            XAxisMax = xAxisLength;
            YAxisMax = yAxisLength;
        }
        public override string ToString()
        {
            return XAxisMax + " " + YAxisMax;
        }
    }
}
