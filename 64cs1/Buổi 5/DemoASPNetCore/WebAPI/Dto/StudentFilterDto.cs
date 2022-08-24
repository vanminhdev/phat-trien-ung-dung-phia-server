using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace WebAPI.Dto
{
    public class StudentFilterDto
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
    }
}
