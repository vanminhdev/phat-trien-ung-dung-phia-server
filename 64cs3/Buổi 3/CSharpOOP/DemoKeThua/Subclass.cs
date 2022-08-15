using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoKeThua
{
    public class Subclass : Baseclass, Interface1
    {
        public Subclass() : base()
        {
        }

        public Subclass(int x) : base(x)
        {
        }

        public int Sum(int a, int b)
        {
            return a + b;
        }

        public int Sum2(int a, int b)
        {
            return a + b;
        }
    }
}
