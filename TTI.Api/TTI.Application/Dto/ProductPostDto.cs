using Microsoft.AspNetCore.Http;

namespace TTI.Application.Dto
{
    public class ProductPostDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Currency { get; set; }
        public decimal Price { get; set; }
        public int IdCategory { get; set; }
        public string Description { get; set; }
        public string Country { get; set; }
        public byte[]? Photo { get; set; }
        public IFormFile? File { get; set; }

    }
}
