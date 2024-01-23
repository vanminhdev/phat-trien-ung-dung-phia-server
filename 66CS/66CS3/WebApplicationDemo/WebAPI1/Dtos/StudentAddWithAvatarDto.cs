namespace WebAPI1.Dtos
{
    public class StudentAddWithAvatarDto : StudentAddDto
    {
        public IFormFile Avatar { get; set; }
    }
}
