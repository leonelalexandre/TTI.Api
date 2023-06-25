using System.Collections.Generic;

#nullable disable

namespace TTI.Domain.Entity
{
    public partial class SubCategory
    {
        public SubCategory()
        {
            Categories = new HashSet<Category>();
        }

        public int Id { get; set; }
        public string Description { get; set; }
        public string Idiom { get; set; }

        public virtual ICollection<Category> Categories { get; set; }
    }
}
