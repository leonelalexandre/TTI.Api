using Microsoft.EntityFrameworkCore.Migrations;

namespace TTI.Infra.Data.Migrations
{
    public partial class MIG20230625111_create_category : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"
                        IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'Categories')
                        BEGIN
                            CREATE TABLE [dbo].[Categories](
                            	[Id] [int] IDENTITY(1,1) NOT NULL,
                            	[Description] [varchar](250) NULL,
                            	[IdSubCategory] [int] NOT NULL,
                            	[Idiom] [varchar] (10) NOT NULL
                             CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
                            (
                            	[Id] ASC
                            )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
                            ) ON [PRIMARY]
                            
                            ALTER TABLE [dbo].[Categories]  WITH CHECK ADD  CONSTRAINT [FK_Categories_SubCategories] FOREIGN KEY([IdSubCategory])
                            REFERENCES [dbo].[SubCategories] ([Id])
                        END  
                       ";

            migrationBuilder.Sql(sp);
        }
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
