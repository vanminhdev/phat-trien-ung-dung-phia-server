using WebAPI.Entities;

namespace WebAPI.Dtos
{
    public class PageResultDto<T>
    {
        public T Items { get; set; }
        public int TotalItem { get; set; }
    }
}
