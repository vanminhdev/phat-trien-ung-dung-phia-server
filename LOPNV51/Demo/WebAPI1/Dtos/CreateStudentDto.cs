namespace WebAPI1.Dtos
{
    public class CreateStudentDto
    {
        public string StudentName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public IFormFile Avatar { get; set; }
    }
}
