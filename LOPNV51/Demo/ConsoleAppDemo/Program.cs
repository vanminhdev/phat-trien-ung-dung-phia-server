namespace ConsoleAppDemo
{
    internal class Program
    {
        static void PrintInfo(Student student)
        {
            //student.Id = 100;
            Console.WriteLine(student.Id + " " + student.Name);
        }

        static void Main(string[] args)
        {
            int a = 1;
            int b = a;
            a = 2;

            Console.WriteLine(b);

            Student student = new Student();
            student.Id = 1;
            student.Name = "Nguyễn Văn A";

            Student student2 = student;
            student2.Name = "Nguyễn Văn B";

            Console.WriteLine(student.Id + " " + student.Name);

            Student student3 = new Student()
            {
                Id = 1,
                Name = "Nguyễn Văn B"
            };

            Console.WriteLine(student == student2); //True
            Console.WriteLine(student == student3); //False

            Console.WriteLine(student.Id == student3.Id && student.Name.Equals(student3.Name));
            Console.WriteLine(student.Id == student3.Id && student.Name == student3.Name);

            PrintInfo(student);

            Console.WriteLine(student.ToString());
            Console.WriteLine(student);


            string str = "Abc";
            if (str.Contains("A"))
            {
                Console.WriteLine("Có chứa ký tự \"A\"");
            }

            string str2 = "   A    ";
            string test = str2.Trim();
            if (!string.IsNullOrEmpty(test))
            {
                Console.WriteLine(str2);
            }

            if (!string.IsNullOrWhiteSpace(str))
            {
                Console.WriteLine(str);
            }

        }
    }
}
