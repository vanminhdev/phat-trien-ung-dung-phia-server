//Thông tin sinh viên bao gồm:
//Id, tên sinh viên (tối đa 50 ký tự),
//mã số sinh viên, ngày tháng năm sinh (chỉ nhập ngày)
using System.ComponentModel.DataAnnotations.Schema;

namespace Filter_DCSon.Entities
{
    [Table("Student")]
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string StudentCode { get; set; }
        public DateTime DateOfBirth { get; set; } //chỉ nhập ngày

        // Relation
        public ICollection<StudentSubject> StudentSubjects { set; get; }
        public Student()
        {
            StudentSubjects = new HashSet<StudentSubject>();
        }
    }
}