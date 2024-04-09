using System.ComponentModel.DataAnnotations;

namespace WebAPI.Entities
{
    public class Post
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [MaxLength(256)]
        public string AvatarUrl { get; set; }

        [Required]
        [MaxLength(500)]
        public string Summary { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        [MaxLength(10)]
        public string StudentCode { get; set; }
    }
}
