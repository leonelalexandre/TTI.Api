namespace TTI.Application.Dto
{
    public class ProductGetDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public string Currency { get; set; }
        public decimal Price { get; set; }
        public string Country { get; set; }
        public byte[] Photo { get; set; }

        public string ImageSelected { get; set; }
        public CategoryGetDto IdCategoriesNavigation { get; set; }
    }
}
 