namespace WebAPI1.Dtos
{
    public class StudentAddDto
    {
        private string _studentCode;
        public string StudentCode 
        { 
            get => _studentCode;
            set => _studentCode = value?.Trim(); 
        }

        private string _studentName;
        public string StudentName
        {
            get => _studentName;
            set => _studentName = value?.Trim();
        }
    }
}
