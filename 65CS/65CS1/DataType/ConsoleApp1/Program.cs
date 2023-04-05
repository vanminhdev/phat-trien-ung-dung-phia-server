namespace ConsoleApp1
{
    internal class Program
    {
        static void Hello(string name)
        {
            name = name?.ToUpper() ?? ""; //demo check null

            //if (name != null && name != "")
            if (!string.IsNullOrEmpty(name))
            {
                Console.WriteLine($"Xin chao {name}");
            }
            else 
            {
                Console.WriteLine("Khong truyen vao ten");
            }
        }

        static void Main(string[] args)
        {
            int a = 2;
            int b = a--;
            Console.WriteLine(b);

            string name = "Nguyen Van A";
            Hello(name);
            int age = 20;
            string str1 = $"Xin Chao {name} {age} tuoi\n";
            Console.WriteLine(str1);

            bool check = name.Contains("Nguyen");

            List<string> list = new List<string>();
        }
    }
}