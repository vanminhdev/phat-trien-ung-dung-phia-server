namespace DemoConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Nhap vao so");
            string input = Console.ReadLine();

            //int n = int.Parse(input);
            int n;
            int.TryParse(input, out n);

            Console.WriteLine($"So vua nhap la: {n}");
        }
    }
}