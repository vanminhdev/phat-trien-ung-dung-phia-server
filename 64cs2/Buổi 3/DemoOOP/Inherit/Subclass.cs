using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inherit
{
    public class Subclass : Baseclass, ISum
    {
        public Subclass() : base()
        {
        }

        public Subclass(int x) : base(x)
        {
        }

        public int Sum(int x, int y)
        {
            return x + y;
        }
    }
}
