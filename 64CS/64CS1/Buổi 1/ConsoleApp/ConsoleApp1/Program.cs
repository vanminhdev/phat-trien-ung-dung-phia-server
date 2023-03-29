using ClassLibrary1;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Class1 class1 = new Class1();

            class1.Hello(1);

            Class1 @using = new Class1();

            Console.WriteLine("Hello, World!");

            Console.ReadLine();
        }
    }
}