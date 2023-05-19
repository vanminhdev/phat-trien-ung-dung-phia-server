using De3.Dtos.Common;

namespace De3.Dtos.Book
{
    public class BookFilterDto : FilterDto
    {
        public double? StartPrice { get; set; }
        public double? EndPrice { get; set; }
    }
}
