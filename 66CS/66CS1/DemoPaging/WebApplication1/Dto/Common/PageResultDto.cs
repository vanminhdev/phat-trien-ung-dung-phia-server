namespace WebApplication1.Dto.Common
{
    public class PageResultDto<T>
    {
        public IEnumerable<T> Items { get; set; }
        public int TotalItem { get; set; }
    }
}
