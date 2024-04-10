namespace WebApplication1.Entity
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string StudentCode { get; set; }
        public DateTime DateOfBirth { get; set; }
        
        /// <summary>
        /// Xoá mềm
        /// </summary>
        public bool IsDeleted { get; set; }
        //public DateTime DeletedDate { get; set; }
    }
}
