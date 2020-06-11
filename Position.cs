using System;
using System.Collections.Generic;
using System.Text;

namespace TaskMartianRobots
{
    class Position
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Directions Direction { get; set; }
        public Position(int x, int y, Directions direction)
        {
            X = x;
            Y = y;
            Direction = direction;
        }
        public Position()
        {
            
        }
        public override string ToString()
        {
            return X + " " + Y + " " + Direction;
        }


    }
}
