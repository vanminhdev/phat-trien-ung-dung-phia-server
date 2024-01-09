namespace ConsoleAppDemo
{
    internal class Program
    {
        static void PrintInfo(Student student)
        {
            Console.WriteLine(student.Id + " " + student.Name);
        }

        static Student ChangeData(Student student)
        {
            Student studentCopy = new Student()
            {
                Id = student.Id,
                Name = student.Name,
            };

            studentCopy.Id = 0;
            studentCopy.Name = "";

            return studentCopy;
        }

        static void Main(string[] args)
        {
            int a = 1;
            int b = a;
            a = 3;
            Console.WriteLine(a);
            Console.WriteLine(b);

            Student student = new Student();

            student.Id = 1;
            student.Name = "Nguyễn Văn A";

            Student student2 = student;

            student2.Id = 2;
            student2.Name = "Nguyễn Văn B";

            PrintInfo(student);
            //Console.WriteLine(student.Id + " " + student.Name);

            Student student3 = new Student()
            {
                Id = 2,
                Name = "Nguyễn Văn B"
            };

            Console.WriteLine(student2 == student3);

            Console.WriteLine(student3);
        }
    }
}
