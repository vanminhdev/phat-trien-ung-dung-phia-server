using Filter_DCSon.Entities;

namespace Filter_DCSon.Dto
{
    public class PageResultStudentDto
    {
        public List<Student> Items { get; set; }
        public int TotalItem { get; set; }
    }
}
