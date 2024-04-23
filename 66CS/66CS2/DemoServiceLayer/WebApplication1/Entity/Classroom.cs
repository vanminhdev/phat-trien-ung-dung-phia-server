using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Entity
{
    [Table("Classroom")]
    public class Classroom
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(50)]
        [Required]
        [Unicode]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        [Unicode]
        public string Code { get; set; }

        public int MaxStudent { get; set; }
    }
}
