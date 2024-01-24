using Microsoft.AspNetCore.Mvc;

namespace WebAPI1.Dtos
{
    public class StudentFilterDto
    {
        private string _studentCode;
        [FromQuery(Name = "studentCode")]
        public string StudentCode
        { 
            get => _studentCode; 
            set => _studentCode = value?.Trim(); 
        }

        //public void setStudentCode(string studentCode)
        //{
        //    this._studentCode = studentCode?.Trim();
        //}

        private string _studentName;

        [FromQuery(Name = "studentName")]
        public string StudentName 
        { 
            get => _studentName; 
            set => _studentName = value?.Trim(); 
        }
    }
}
