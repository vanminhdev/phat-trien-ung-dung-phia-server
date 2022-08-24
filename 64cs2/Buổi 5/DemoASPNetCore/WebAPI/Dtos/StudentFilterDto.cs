using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;

namespace WebAPI.Dtos
{
    public class StudentFilterDto
    {
        [FromQuery(Name = "pageSize")]
        public int PageSize { get; set; }

        [FromQuery(Name = "pageIndex")]
        public int PageIndex { get; set; }

        [FromQuery(Name = "keyWord")]
        public string KeyWord { get; set; }
    }
}
