namespace ConsoleAppDemo2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();
            //Console.Write("Nhap vao so luong sinh vien: ");
            //int num = int.Parse(Console.ReadLine());
            //for (int i = 0; i < num; i++)
            //{
            //    Console.WriteLine($"Nhap vao sinh vien thu {i + 1}:");
            //    var student = new Student();
            //    Console.Write("Nhap vao Id:");
            //    student.Id = Convert.ToInt32(Console.ReadLine());

            //    Console.Write("Nhap vao ten:");
            //    student.Name = Console.ReadLine();
            //    students.Add(student);
            //}

            students.Add(new Student()
            {
                Id = 1,
                Name = "A"
            });

            students.Add(new Student()
            {
                Id = 2,
                Name = "C"
            });

            students.Add(new Student()
            {
                Id = 3,
                Name = "B"
            });

            students.Add(new Student()
            {
                Id = 4,
                Name = "B"
            });

            //sắp xếp
            var students2 = students.OrderBy(s => s.Name);
            foreach (var student in students2)
            {
                Console.WriteLine(student);
            }

            Console.WriteLine();

            var students3 = students.OrderByDescending(s => s.Name);
            foreach(var student in students3)
            {
                student.Name = "A";
                Console.WriteLine(student);
            }

            //tìm kiếm: có thể null nếu như không thấy
            Student studentFind = students.FirstOrDefault(s => s.Name == "B"); //trả về tham chiếu
            if (studentFind != null)
            {
                studentFind.Name = "B1";
                Console.WriteLine(studentFind);
            }

            Student studentFind2 = students.LastOrDefault(s => s.Name == "B");
            if (studentFind2 != null)
            {
                Console.WriteLine(studentFind2);
            }

            double max = 0;
            double min = 0;
            if (students.Count > 0)
            {
                max = students.Max(x => x.Point);
                min = students.Min(x => x.Point);
            }
            Console.WriteLine($"Max = {max}");
            Console.WriteLine($"Min = {min}");


            List<double> numbers = new List<double>()
            {
                1.2, 3.2, 4.1
            };
            numbers.Max();
            numbers.Min();

            numbers.OrderBy(x => x);

        }
    }
}
