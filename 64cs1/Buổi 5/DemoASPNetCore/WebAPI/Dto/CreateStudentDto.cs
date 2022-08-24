namespace WebAPI.Dto
{
    public class CreateStudentDto
    {
        public string Name { get; set; }
        public string StudentCode { get; set; }
        public DateTime DateOfBirth { get; set; }
        public IFormFile Avatar { get; set; } //lấy file.
    }
}
