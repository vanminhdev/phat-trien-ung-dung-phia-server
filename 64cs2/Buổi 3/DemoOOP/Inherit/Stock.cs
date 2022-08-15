using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inherit
{
    public class Stock : Asset // inherits from Asset
    {
        public long SharesOwned;

        public override string ToString()
        {
            return $"{Id} {Name?.ToUpper()}";
        }
    }
}
