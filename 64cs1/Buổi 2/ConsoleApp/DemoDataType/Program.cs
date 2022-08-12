using System.Text;

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

            p2 = new Point();

            p1.X = 9; // Change p1.X 
            Console.WriteLine(p1.X); // 9 
            Console.WriteLine(p2.X); // 0 | un | null | 


            Point p = null;
            Console.WriteLine(p == null);
            
            if (p != null)
            {
                Console.WriteLine(p.X); // (a NullReferenceException is thrown):
            }

            //int x = null;

            int i = 5;
            System.Int32 i1 = 5;


            int a = 1;
            int b = a++;

            Console.WriteLine(b); //2 | 1 | 


            int c = 2;
            double d = 0;

            if (c != 0)
            {
                d = 5 / (double)c;
            }

            Console.WriteLine(d); //2  | 2.5 | 


            int num = int.MinValue;
            num--;
            Console.WriteLine(num == int.MaxValue);


            int num2 = unchecked (int.MaxValue + 1);
            num2++;
            Console.WriteLine(num2 == int.MinValue);

            string str1 = "test";
            string str2 = @"test \t" + "abc";
            Console.WriteLine(str1 == str2);


            string str3 = $@"abc\t{num2,20}|";
            Console.WriteLine(str3);


            char[] vowels = new char[5]; // Declare an array of 5 characters
            vowels[0] = 'a';
            vowels[1] = 'e';
            vowels[2] = 'i';
            vowels[3] = 'o';
            vowels[4] = 'u';
            Console.WriteLine(vowels[1]); // e


            char[] vowels2 = vowels.OrderBy(x => x).ToArray(); //trả ra 1 mảng được sx

            int[] myNumbers = { 5, 1, 8, 9 };
            Array.Sort(myNumbers);  //thay đổi trên chính mảng đó
            foreach (int numi in myNumbers)
            {
                Console.WriteLine($"{numi,20}");
            }


            int[] arr = null;
            if (arr != null)
            {
                foreach (int numi in arr)
                {
                    Console.WriteLine(numi);
                }
            }

            StringBuilder ref1 = new StringBuilder("object1");
            Console.WriteLine(ref1); //giải phóng ref1.
            StringBuilder ref2 = new StringBuilder("object2");
            StringBuilder ref3 = ref2; //Không giải phóng được ref2 vì còn tham chiếu ref3
            Console.WriteLine(ref3); // object2


            string s1 = null;
            string s2 = s1 ?? "nothing"; // s2 = "nothing" 

            string s3 = "abc";
            s3 ??= "gi do";
            Console.WriteLine(s3);
            

            string s4 = null;
            string s5 = s4?.ToUpper();

            Console.WriteLine(s5);

            int? number1 = null;
            number1 = 1;

            int number2 = number1 ?? 0;
            //if (number1 != null)
            //{
            //    number2 = number1.Value;
            //}

            int? n = null;
            //int m1 = n; 
            int n2 = n ?? 0;


            DateTime dt1 = new DateTime(2022, 8, 12);
            DateTime dt2 = new DateTime(2022, 8, 11);

            TimeSpan ts = dt1 - dt2;

            DateTime? dt3 = null;

            Console.WriteLine(dt1.ToString("dd-MM-yyyy HH:mm:ss"));

            var points = new List<Point>();
            points.Add(new Point
            {
                X = 1,
                Y = 2
            });
            var point1 = new Point
            {
                X = 1,
                Y = 2
            };
            points.Add(point1);

            var point2 = new Point
            {
                X = 1,
                Y = 2
            };
            points.Add(point2);

            var points2 = points.OrderBy(o => o.X).ToList();

            for (int index = 0; index < points2.Count; index++)
            {
                Console.WriteLine($"{points2[index].X} {points2[index].Y}");
            }

            foreach (Point point in points)
            {
                Console.WriteLine($"{point.X} {point.Y}");
            }


            int number3 = int.Parse(Console.ReadLine());
            int number4 = Convert.ToInt32(Console.ReadLine());

            
        }
    }
}