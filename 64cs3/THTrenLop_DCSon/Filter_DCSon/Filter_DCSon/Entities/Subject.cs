//Thông tin môn học gồm:
//Id, tên mon (tối đa 50 ký tự),
//mã lớp (tối thiểu 5 ký tự), số sinh viên tối đa (số lớn hơn 0). 
using System.ComponentModel.DataAnnotations.Schema;

namespace Filter_DCSon.Entities
{
    [Table("Subject")]
    public class Subject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SubjectCode { get; set; } //(tối thiểu 5 ký tự)
        public int NumberCredits { get; set; } // (số lớn hơn 0)

        // Relation
        public ICollection<StudentSubject> StudentSubjects { set; get; }
        public Subject()
        {
            StudentSubjects = new HashSet<StudentSubject>();
        }
    }
}
