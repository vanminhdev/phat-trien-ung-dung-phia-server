namespace WebApplication.Dtos.Subjects
{
    public class SubjectWithPointDto
    {
        public int Id { get; set; }
        public string SubjectName { get; set; }
        public string SubjectCode { get; set; }
        public int NumberOfCredit { get; set; }
        public float PointAvg { get; set; }
    }
}
