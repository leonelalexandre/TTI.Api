using Microsoft.EntityFrameworkCore.Migrations;

namespace TTI.Infra.Data.Migrations
{
    public partial class MIG202306252007_create_products : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"
                       IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'Products')
                        BEGIN
                            CREATE TABLE [dbo].[Products](
                            	[Id] [int] IDENTITY(1,1) NOT NULL,
                            	[Name] [varchar] (250) NOT NULL,
                            	[Currency] [varchar] (10),
                            	[Price] [SMALLMONEY] NOT NULL,
                            	[Description] [text] NOT NULL,
                            	[IdCategory] [int] NOT NULL,
                            	[Country] [varchar](50)
                             CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
                            (
                            	[Id] ASC
                            )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
                            ) ON [PRIMARY]
                            
                            
                            ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_Categories] FOREIGN KEY([IdCategory])
                            REFERENCES [dbo].[Categories] ([Id])
                            
                            ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_Categories]
                        END  
                       ";

            migrationBuilder.Sql(sp);
        }
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
