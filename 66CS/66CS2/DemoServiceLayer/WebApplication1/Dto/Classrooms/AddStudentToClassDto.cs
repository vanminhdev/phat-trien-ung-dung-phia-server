namespace WebApplication1.Dto.Classrooms
{
    public class AddStudentToClassDto
    {
        public int ClassroomId { get; set; }
        public List<int> StudentIds { get; set; }
    }
}
