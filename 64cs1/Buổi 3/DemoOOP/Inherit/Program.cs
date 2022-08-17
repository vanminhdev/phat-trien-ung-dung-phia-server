namespace Inherit
{
    internal class Program
    {
        public static void Display(Asset asset)
        {
            asset.Name = "abcxyz";
            System.Console.WriteLine(asset.Name);
        }

        public static void Display(House asset)
        {
            System.Console.WriteLine(asset.Name);
        }

        static void Main(string[] args)
        {
            Asset asset = new House() //upcast
            {
                Name = "house1"
            };
            House house = (House)asset; //downcast

            Console.WriteLine(asset == house); //true

            Asset asset2 = new Stock()
            {
                Name = "stock1"
            };

            //Stock stock = (Stock)asset; //ngoại lệ
            Stock stock = asset as Stock;
            if (stock != null)
            {
                Console.WriteLine(stock.Name);
            }

            Display(asset);
            Display(house);

            Asset asset3 = new House();
        }
    }
}