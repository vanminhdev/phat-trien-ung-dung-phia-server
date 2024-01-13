using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoOOP
{
    internal abstract class AbstractPaymentService
    {
        protected HttpClient _httpClient;

        protected AbstractPaymentService()
        {
            _httpClient = new HttpClient();
        }

        public abstract void Payment(double money);

        public void Method2()
        {
            //xử lý công việc
        }
    }
}
