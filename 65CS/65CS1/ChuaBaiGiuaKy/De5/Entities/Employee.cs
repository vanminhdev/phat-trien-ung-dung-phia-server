using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace De5.Entities
{
    [Table("Employee")]
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)] //varchar(50) not null
        [Unicode(false)]
        public string Code { get; set; }

        [Required]
        [MaxLength(128)]
        public string Name { get; set; }

        public int Age { get; set; }

        [Required]
        [MaxLength(512)]
        public string Address { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
