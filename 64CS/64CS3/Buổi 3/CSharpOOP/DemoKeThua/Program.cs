namespace DemoKeThua
{
    internal class Program
    {
        public static void Display(Asset asset)
        {
            System.Console.WriteLine(asset.Name);
        }

        public static void Display(House house) // Will not accept Asset
        {
            System.Console.WriteLine(house.Mortgage);
        }

        static void Main(string[] args)
        {
            //thông thường
            Stock msft = new Stock
            {
                Name = "MSFT",
                SharesOwned = 1000
            };

            Console.WriteLine(msft.Name); // MSFT
            Console.WriteLine(msft.SharesOwned); // 1000

            House mansion = new House
            {
                Name="Mansion",
                Mortgage = 250000
            };
            Console.WriteLine(mansion.Name); // Mansion
            Console.WriteLine(mansion.Mortgage); // 250000


            Asset fpt = new Stock
            {
                Name = "FPT",
                SharesOwned = 1000
            };

            Stock fpt2 = fpt as Stock;

            Console.WriteLine(fpt2.Name);
            Console.WriteLine(fpt2.SharesOwned);

            Display(fpt2);

            Display(mansion);

            House fpt3 = fpt as House; //sẽ trả về null
            if (fpt3 != null)
            {
                //
            }

            //House fpt4 = (House)fpt; //throw ra ngoại lệ

            Subclass subclass = new Subclass(123);
            Subclass subclass2 = new Subclass();

            Interface1 subclass3 = new Subclass();
            Subclass subclass4 = subclass3 as Subclass;
            if (subclass4 != null)
            {
                Console.WriteLine(subclass4.Sum2(1, 2));
            }
        }
    }
}