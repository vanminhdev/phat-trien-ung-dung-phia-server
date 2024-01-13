using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoOOP
{
    /// <summary>
    /// Xử lý hoá đơn
    /// </summary>
    internal class OrderService
    {
        private readonly AbstractPaymentService _paymentService;

        public OrderService(AbstractPaymentService paymentService) 
        {
            _paymentService = paymentService;

            var test = paymentService as VCBPaymentService;
            if (test != null)
            {
                //thực hiện công việc
                test.Payment(123);
            }
        }

        /// <summary>
        /// Thanh toán order
        /// </summary>
        public void PaymentOrder()
        {
            //các logic khác xử lý thanh toán cho hoá đơn
            _paymentService.Payment(100);
        }
    }
}
