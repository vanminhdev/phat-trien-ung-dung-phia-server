namespace WebAPI1.Dto
{
    public class CreateProductDto
    {
        public string? Name { get; set; }

        public IFormFile? Avatar { get; set; }
    }
}
