using System.ComponentModel.DataAnnotations;

namespace Filter_DCSon.Dto
{
    public class AddListStudentDto
    {
        public int ClassroomId { get; set; }

        [MinLength(1, ErrorMessage = "Danh sách sinh viên phải có tối thiểu 1 phần tử")]
        public List<int> StudentIds { get; set; }
    }
}
