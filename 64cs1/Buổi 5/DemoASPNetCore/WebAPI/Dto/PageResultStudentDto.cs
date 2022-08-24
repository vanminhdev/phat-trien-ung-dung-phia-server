using WebAPI.Entities;

namespace WebAPI.Dto
{
    public class PageResultStudentDto
    {
        public List<Student> Items { get; set; }
        public int TotalItem { get; set; }
    }
}
