namespace DemoClassAndObject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Octopus octopus = new Octopus();
            octopus.Foo(1.2);
            octopus.Foo(1);

            Octopus octopus2 = new Octopus()
            {
                Age = 1,
                Date = DateTime.Now,
                CharA = 'a',
                Name = "  ABC   "
            };

            Console.WriteLine(octopus2.Name);

            Console.WriteLine(octopus2?.ToString() ?? "abc");


        }
    }
}