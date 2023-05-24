using Microsoft.AspNetCore.Mvc;

namespace De5.Dtos.Common
{
    public class FilterDto
    {
        [FromQuery(Name = "pageSize")]
        public int PageSize { get; set; }

        [FromQuery(Name = "pageIndex")]
        public int PageIndex { get; set; }

        private string _keyword;
        [FromQuery(Name = "keyword")]
        public string Keyword
        {
            get => _keyword;
            set => _keyword = value?.Trim();
        }

        public int Skip()
        {
            return (PageIndex - 1) * PageSize;
        }
        //public int Skip() => (PageIndex - 1) * PageSize;
    }
}
