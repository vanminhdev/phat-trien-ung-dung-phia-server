namespace De5.Dtos.Common
{
    public class PageResultDto<T>
    {
        public List<T> Items { get; set; }
        public int TotalItem { get; set; }
    }
}
