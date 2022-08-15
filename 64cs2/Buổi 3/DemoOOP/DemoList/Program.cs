namespace DemoList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();
            students.Add(new Student
            {
                Id = 1,
                Name = "Son",
                Age = 18
            });

            students.Add(new Student
            {
                Id = 2,
                Name = "Cuong",
                Age = 20
            });

            students.Add(new Student
            {
                Id = 3,
                Name = "Khanh",
                Age = 20
            });

            //tăng dần theo tuổi
            List<Student> sxTang = students.OrderBy(s => s.Age).ToList();

            //giảm dần theo tuổi
            List<Student> sxGiam = students.OrderByDescending(s => s.Age).ToList();

            int maxAge = students.Max(s => s.Age);
            int minAge = students.Min(s => s.Age);

            students.Average(s => s.Age);

            students.Sum(s => s.Age);

            Student find = students.FirstOrDefault(s => s.Name == "Cuong");
            if (find != null)
            {
                //students.Remove(find);

                find.Name = "Xuan Cuong";
            }

            Student findAgeMax = students.FirstOrDefault(s => s.Age == maxAge && s.Age > 10);

            List<int> list = new();
            list.Add(1);
            list.Add(2);
            list.Add(3);

            int num = list.FirstOrDefault(x => x == 2);
            num = 9;

            int index = list.FindIndex(x => x == 2);
            if (index != -1)
            {
                list[index] = 9;
            }

            Console.WriteLine(students[0]);

            int[] arr = new int[] { 1, 2, 3 };
        }
    }
}