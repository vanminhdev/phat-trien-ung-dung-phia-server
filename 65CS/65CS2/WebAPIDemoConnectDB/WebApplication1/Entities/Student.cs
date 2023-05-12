using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Entities
{
    [Table("Student")] //đặt tên bảng
    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required] //tương ứng là not null
        [MaxLength(100)]
        //[Unicode]
        //tương ứng là nvarchar(100)
        public string Name { get; set; }

        //[Required] //không cần viết required do kiểu int không chứa null, chỉ viết required khi kiểu dữ liệu có thể chứa null
        public int Age { get; set; }

        [Required]
        [MaxLength(128)]
        public string StudentCode { get; set; }
    }
}
