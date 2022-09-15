using System.ComponentModel.DataAnnotations.Schema;

namespace Filter_DCSon.Entities
{
    [Table("StudentSubject")]
    public class StudentSubject
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int SubjectId { get; set; }
        public float Score { get; set; }

        //relationship
        public Student Student { get; set; }
        public Subject Subject { get; set; }
    }
}
