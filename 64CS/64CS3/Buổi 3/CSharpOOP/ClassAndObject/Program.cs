namespace ClassAndObject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Octopus octopus = new Octopus();

            Octopus.CharA = 'a';
            Console.WriteLine(Octopus.CharA);
            //Octopus.ClassRoom = "a";
            Console.WriteLine(Octopus.ClassRoom);


            Octopus octopus2 = new Octopus
            {
                Age = 1,
                Name = "    abc      "
            };

            Console.WriteLine(octopus2.Name);
        }
    }
}