namespace ClassAndObject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Octopus octopus = new Octopus("A", 18, 'a');
            Octopus.Gender = "a";

            //octopus.CharA = 'b';

            Console.WriteLine(octopus.CharA);

            int a = 1;
            float b = 2;
            double c = 3;

            octopus.Sum(a);

            octopus.Sum(a, b);

            octopus.Sum(b, a);

            decimal price = 100.4M;
            //Wine wine = new Wine(price, 2022);

            Wine wine = new Wine
            { 
                Price = price,
                Name = "   wine1   ",
                Year = 2022
            };

            Wine wine2 = new Wine
            {
                Price = price,
                Name = null,
                Year = 2022
            };

            wine2.Name = "wine2";

        }
    }
}