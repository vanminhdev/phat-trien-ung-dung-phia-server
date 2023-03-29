using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inherit
{
    public interface ISum
    {
        int Count { get; set; }
        int Sum(int a, int b);
    }
}
