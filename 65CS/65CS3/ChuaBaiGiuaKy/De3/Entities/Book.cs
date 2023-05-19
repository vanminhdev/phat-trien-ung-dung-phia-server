using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace De3.Entities
{
    [Table("Book")]
    public class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Title { get; set; }
        
        [Required, MaxLength(255)]   
        public string Author { get; set; }

        public int PulishYear { get; set; }
        public double Price { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
