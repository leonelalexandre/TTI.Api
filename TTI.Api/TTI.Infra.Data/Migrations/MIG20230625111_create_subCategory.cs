using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTI.Infra.Data.Migrations
{
    public partial class MIG20230625111_create_subCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"
                        IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'SubCategories')
                        BEGIN
                            CREATE TABLE [dbo].[SubCategories](
                            	[Id] [int] IDENTITY(1,1) NOT NULL,
                            	[Description] [varchar](250) NOT NULL,
                            	[Idiom] [varchar](10) NOT NULL
                             CONSTRAINT [PK_SubCategories] PRIMARY KEY CLUSTERED 
                            (
                            	[Id] ASC
                            )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
                            ) ON [PRIMARY]
                        END  
                       ";

            migrationBuilder.Sql(sp);
        }
    }
}
