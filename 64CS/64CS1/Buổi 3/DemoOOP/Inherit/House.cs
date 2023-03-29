using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inherit
{
    public class House : Asset, ISum // inherits from Asset
    {
        public decimal Mortgage;

        public int Count { get; set; }

        public override string ShowName()
        {
            throw new NotImplementedException();
        }

        public int Sum(int a, int b)
        {
            return a + b;
        }
    }
}
