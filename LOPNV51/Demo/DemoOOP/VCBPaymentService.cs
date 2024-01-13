using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoOOP
{
    internal class VCBPaymentService : AbstractPaymentService
    {
        public override void Payment(double money)
        {
            //các logic liên quan đến việc gọi sang ngân hàng vietcombank
        }
    }
}
