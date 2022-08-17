using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inherit
{
    public abstract class Asset
    {
        public string Age;
        public string Name { get; set; }
        public abstract string ShowName();
    }
}
