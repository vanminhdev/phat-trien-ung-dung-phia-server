namespace ConsoleAppDemo
{
    internal class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return Id + " " + Name;
        }
    }
}
