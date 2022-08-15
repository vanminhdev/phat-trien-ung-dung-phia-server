namespace Inherit
{
    internal class Program
    {
        public static void Display(Asset asset)
        {
            System.Console.WriteLine(asset.Name);
        }

        public static void Display(House house)
        {
            System.Console.WriteLine(house.Name);
        }

        static void Main(string[] args)
        {
            Stock msft = new Stock
            {
                Name = "MSFT",
                SharesOwned = 1000
            };

            Console.WriteLine(msft.Name); // MSFT
            Console.WriteLine(msft.SharesOwned); // 1000

            House mansion = new House
            {
                Name = "Mansion",
                Mortgage = 250000
            };
            Console.WriteLine(mansion.Name); // Mansion
            Console.WriteLine(mansion.Mortgage); // 250000

            Asset house1 = new House
            {
                Name = "House1",
                Mortgage = 250000
            };

            Console.WriteLine(mansion.Name);

            House house2 = (House)house1;
            Console.WriteLine(house2.Mortgage);

            Display(house1);
            Display(house2);

            Asset house3 = new Stock
            {
                Name = "Stock1",
                SharesOwned = 123
            };
            //House house4 = (House)house3;
            House house4 = house3 as House;
            if (house4 != null)
            {
                Console.WriteLine(house4.Mortgage);
            }

            Console.WriteLine(new Stock
            {
                Id = 1,
                Name = "abc"
            });


            Stock stock2 = new Stock();
            Asset a = stock2; // Upcast


            Subclass subclass = new Subclass();
            Subclass subclass2 = new Subclass(1);

            ISum subclass3 = new Subclass();
            Subclass subclass4 = subclass3 as Subclass;


        }
    }
}