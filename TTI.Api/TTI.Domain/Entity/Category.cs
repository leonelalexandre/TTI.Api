using System.Collections.Generic;

#nullable disable

namespace TTI.Domain.Entity
{
    public partial class Category
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string Description { get; set; }
        public int IdSubCategory { get; set; }
        public string Idiom { get; set; }

        public virtual SubCategory IdSubCategoryNavigation { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
