namespace DemoOOP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //OrderService orderService = new OrderService(new VCBPaymentService());
            OrderService orderService = new OrderService(new ViettinPaymentService());

            orderService.PaymentOrder();

            //SOLID
        }
    }
}
