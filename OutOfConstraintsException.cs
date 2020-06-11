using System;
using System.Collections.Generic;
using System.Text;

namespace TaskMartianRobots
{
    class OutOfConstraintsException : Exception
    {
        public OutOfConstraintsException(string message)
       : base(message)
        { }

    }
}
