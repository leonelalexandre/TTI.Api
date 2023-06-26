using Microsoft.EntityFrameworkCore.Migrations;

namespace TTI.Infra.Data.Migrations
{
    public partial class MIG202306252019_create_fullText : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"
                        IF NOT EXISTS(SELECT * FROM sys.fulltext_catalogs WHERE NAME =  N'ftCatalog')
                        BEGIN
                        	CREATE FULLTEXT CATALOG ftCatalog
                        	CREATE FULLTEXT INDEX ON Products  
                            (  
                                Name
                                Language 1033            
                            )  
                                KEY INDEX PK_Products  
                                ON ftCatalog  
                                WITH CHANGE_TRACKING OFF, NO POPULATION;
                            
                            
                            ALTER FULLTEXT INDEX ON Products 
                                START FULL POPULATION; 
                        
                        
                        	CREATE FULLTEXT INDEX ON Categories  
                        	(  
                        		Description                           
                        
                        			Language 1033                
                        	)  
                        		KEY INDEX PK_Categories  
                        		ON ftCatalog  
                        		WITH CHANGE_TRACKING OFF, NO POPULATION; 
                        
                        
                        	ALTER FULLTEXT INDEX ON Categories 
                        	   START FULL POPULATION;
                        
                        
                            CREATE FULLTEXT INDEX ON SubCategories  
                            (  
                                description                        
                                    Language 1033                
                            )  
                                KEY INDEX PK_SubCategories  
                                ON ftCatalog  
                                WITH CHANGE_TRACKING OFF, NO POPULATION; 
                            
                            
                            ALTER FULLTEXT INDEX ON SubCategories 
                               START FULL POPULATION;
                            
                            
                            END
                       ";

            migrationBuilder.Sql(sp);
        }
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
