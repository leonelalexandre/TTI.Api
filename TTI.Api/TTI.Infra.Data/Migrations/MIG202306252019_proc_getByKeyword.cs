using Microsoft.EntityFrameworkCore.Migrations;

namespace TTI.Infra.Data.Migrations
{
    public partial class MIG202306252019_proc_getByKeyword : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"CREATE PROCEDURE [dbo].[GetByProductsKeyword] @Keyword varchar(50) AS BEGIN
                            SELECT PROD.*
                            FROM Products AS PROD
                            JOIN Categories ON Categories.id = PROD.IDCATEGORY
                            JOIN SubCategories AS SUBCAT ON SUBCAT.ID = Categories.IDSUBCATEGORY
                            WHERE CONTAINS (PROD.Name,
                                            @Keyword)
                              OR CONTAINS(Categories.Description, @Keyword)
                              OR CONTAINS(SUBCAT.DESCRIPTION, @Keyword) END
                       ";

            migrationBuilder.Sql(sp);
        }
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
