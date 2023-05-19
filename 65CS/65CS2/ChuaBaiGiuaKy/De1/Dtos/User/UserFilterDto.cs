using De1.Dtos.Common;

namespace De1.Dtos.User
{
    public class UserFilterDto : FilterDto
    {
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
