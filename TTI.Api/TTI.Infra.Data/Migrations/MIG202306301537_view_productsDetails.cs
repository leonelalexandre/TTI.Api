using Microsoft.EntityFrameworkCore.Migrations;

namespace TTI.Infra.Data.Migrations
{
    public partial class MIG202306301537_view_productsDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"CREATE VIEW ProductsDetails AS
                        SELECT ProductS.Name
                        	   , Products.Currency
                        	   , Products.Price
                        	   , Products.Description
                        	   , Categories.Description category
                        	   , SubCategories.Description subCategory
                        	   , Products.Country
                        FROM PRODUCTS
                        JOIN CATEGORIES ON CATEGORIES.ID = Products.IdCategory
                        JOIN SubCategories ON SubCategories.Id = Categories.IdSubCategory";

            migrationBuilder.Sql(sp);
        }
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
