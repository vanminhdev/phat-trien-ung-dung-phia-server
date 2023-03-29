using ClassLibrary1;
using System.Text;

namespace DemoDataTypes
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
            Console.WriteLine(p2.X); // 7   | 0 | null

            Point p = null;
            Console.WriteLine(p == null);

            if (p != null)
            {
                Console.WriteLine(p.X); // (a NullReferenceException is thrown):
            }

            int a = 1;
            //int b = a++;
            int b = ++a;
            Console.WriteLine(b); //1 | 2


            int c = 0;
            int d = 0; // throws DivideByZeroException
            if (c != 0)
            {
                d = c / 5;
            }

            int e = 5;
            double f = (double)e / 2; //0 | 2


            int a1 = int.MinValue;
            a1--;
            Console.WriteLine(a1 == int.MaxValue); // True


            int a2 = int.MaxValue;
            a2++;
            Console.WriteLine(a2 == int.MinValue); // True

            string str = "test";
            str += "123";


            string str2 = @"test\t123";
            Console.WriteLine(str2);

            string str3 = $@"test {1,-8} \n";
            Console.WriteLine(str3);


            string myStr1 = "Hello";
            string myStr2 = "Hello";
            Console.WriteLine(myStr1.CompareTo(myStr2)); // Returns 0 because they are equal

            string myStr3 = "Hello";
            string myStr4 = "Hello1";
            Console.WriteLine(myStr3.CompareTo(myStr4)); //= ? -1

            string myStr5 = "Hello1";
            string myStr6 = "Hello";
            Console.WriteLine(myStr5.CompareTo(myStr6)); //=?  1


            char[] vowels = new char[5]; // Declare an array of 5 characters
            vowels[0] = 'a';
            vowels[1] = 'e';
            vowels[2] = 'i';
            vowels[3] = 'o';
            vowels[4] = 'u';
            Console.WriteLine(vowels[1]); // e

            vowels = vowels.OrderBy(x => x).ToArray();


            char[] vowels2 = null;
            if (vowels2 != null)
            {
                for (int i = 0; i < vowels2.Length; i++)
                    Console.Write(vowels2[i]);
            }

            StringBuilder ref1 = new StringBuilder("object1");
            Console.WriteLine(ref1); //giải phóng ref1.
            StringBuilder ref2 = new StringBuilder("object2");
            StringBuilder ref3 = ref2; 
            ref2 = new StringBuilder("object3");
            Console.WriteLine(ref2);
            Console.WriteLine(ref3);

            string s1 = null;
            s1 ??= "gi do";
            string s2 = s1 ?? "nothing";


            string str4 = null;
            string s = str4?.ToUpper();

            int? len = str4?.Length;
            int len2 = 0;
            if (len != null)
            {
                len2 = len.Value;
            }

            DateTime dt1 = new DateTime();
            DateTime dt2 = DateTime.Now;

            TimeSpan ts = dt2 - dt1;

            int day = ts.Days;

            Console.WriteLine(dt2.ToString("dd/MM/yyyy HH:mm:ss"));


            List<Point> points = new List<Point>();
            points.Add(new Point
            {
                X = 1,
                Y = 2
            });

            int num = int.Parse("1");
        }
    }
}