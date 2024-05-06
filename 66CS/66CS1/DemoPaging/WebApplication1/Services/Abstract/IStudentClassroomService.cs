using WebApplication1.Dto.Classrooms;
using WebApplication1.Dto.Students;

namespace WebApplication1.Services.Abstract
{
    public interface IStudentClassroomService
    {
        /// <summary>
        /// Thêm sinh viên vào lớp môn học
        /// </summary>
        /// <param name="input"></param>
        void AddStudents(AddStudentToClassDto input);

        //xoá sinh viên khỏi lớp

        /// <summary>
        /// lấy danh sách sinh viên trong lớp
        /// </summary>
        /// <param name="classroomId"></param>
        /// <returns></returns>
        List<StudentDto> GetAllStudent(int classroomId);
    }
}
