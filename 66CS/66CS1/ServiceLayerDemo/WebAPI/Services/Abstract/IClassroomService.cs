using WebAPI.Dtos.Classrooms;
using WebAPI.Dtos.Students;

namespace WebAPI.Services.Abstract
{
    public interface IClassroomService
    {
        //add
        //update
        //delete
        //getall

        /// <summary>
        /// Thêm danh sách sinh viên vào lớp
        /// </summary>
        /// <param name="input"></param>
        void AddStudent(AddStudentToClassDto input);

        /// <summary>
        /// Lấy danh sách sinh viên trong một lớp
        /// </summary>
        /// <param name="classroomId"></param>
        /// <returns></returns>
        List<StudentDto> GetAllStudent(int classroomId);
    }
}
