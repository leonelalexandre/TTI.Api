#nullable disable

namespace TTI.Domain.Entity
{
    public partial class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Currency { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int IdCategory { get; set; }
        public string Country { get; set; }

        public virtual Category IdCategoriesNavigation { get; set; }
    }
}
