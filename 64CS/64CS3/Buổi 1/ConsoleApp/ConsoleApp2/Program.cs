using ClassLibrary1;
using System;

namespace ConsoleApp2
{
    internal class Program
    {
        static int Func1(int a, int b)
        {
            return a + b;
        }

        static void Main(string[] args)
        {
            int c = Func1(1, 2);

            Class1 class1 = new Class1();
            class1.Hello();

            class1.Hello2();
        }
    }
}
