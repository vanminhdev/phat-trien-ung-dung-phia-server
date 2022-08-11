namespace DemoDataType
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Point p1 = new Point();
            p1.X = 7;
            Point p2 = p1; // Copies p1 reference

            Console.WriteLine(p1.X); // 7 
            Console.WriteLine(p2.X); // 7 

            p1.X = 9; // Change p1.X 
            Console.WriteLine(p1.X); // 9 
            Console.WriteLine(p2.X); // 9

            //so sánh object
            Console.WriteLine(p2 == p1);
            p2 = new Point();
            Console.WriteLine(p2 == p1);

            Point p3 = null;
            int? i = null;
            Console.WriteLine(i == null);

            if (p3 != null) 
            {
                Console.WriteLine(p3.X);
            }

            string str1 = "ABC";
            if (str1 != null)
            {
                Console.WriteLine(str1.ToLower());
            }

            //int a = 1; 
            //int b = ++a; //2 a = a + 1;

            int b = 0;
            int c = 0; // throws DivideByZeroException

            if (b != 0)
            {
                c = 5 / b;
            }

            int a = int.MinValue;
            a--;
            Console.WriteLine(a == int.MaxValue);

            string abc = "123";
            Console.WriteLine($"Xin chao {abc, 5}");


            int x = 2;
            string s = $@"this interpolation spans\t{x} lines";
            Console.WriteLine(s); // this interpolation spans \t 2 lines\

            int[] arr = new int[5];
            int max = arr.Max();


            string s1 = "abc";
            string s2 = s1 ?? "nothing"; // s2 = "nothing"

            string foo = "12";
            char? c2 = foo?[1]; // c is null

            System.Text.StringBuilder sb = null;
            int? length = sb?.ToString().Length;

            DateTime dt1 = new DateTime(2019, 1, 1);
            DateTime? dt2 = null; //Error


            List<int> list1 = new List<int>();
            list1.Add(1);
            int count = list1.Count;

            List<Point> list2 = new List<Point>();
            list2.Add(new Point
            {
                X = 1,
                Y = 2
            });
            list2.OrderBy(x => x);
        }
    }
}