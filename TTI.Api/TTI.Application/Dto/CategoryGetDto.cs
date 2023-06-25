namespace TTI.Application.Dto
{
    public class CategoryGetDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Idiom { get; set; }
        public int IdSubCategory { get; set; }
        public SubCategoryGetDto IdSubCategoryNavigation { get; set; }
    }
}
