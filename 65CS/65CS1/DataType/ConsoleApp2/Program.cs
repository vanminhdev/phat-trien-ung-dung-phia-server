namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();

            students.Add(new Student
            {
                Name = "Nguyen Van A",
                StudentCode = "1",
                DateOfBirth = new DateTime(2002, 1, 1)
            });

            students.Add(new Student
            {
                Name = "Nguyen Van B",
                StudentCode = "2",
                DateOfBirth = new DateTime(2002, 2, 1)
            });

            students.Add(new Student
            {
                Name = "Nguyen Van C",
                StudentCode = "123",
                DateOfBirth = new DateTime(2002, 3, 1)
            });

            Student studentFind = students.FirstOrDefault(s => s.StudentCode == "123");
            if (studentFind != null)
            {
                studentFind.StudentCode = "1234";
            }

            foreach (Student student in students)
            {
                Console.WriteLine(student.Name);
            }
        }
    }
}