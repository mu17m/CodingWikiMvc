using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodingWiki.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class createView : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.Sql("CREATE OR ALTER VIEW dbo.vw_BookEssentials AS SELECT b.ISBN, b.Price FROM Books b");
            migrationBuilder.Sql("CREATE OR ALTER PROCEDURE dbo.sp_GetBookById (@Id INT) AS BEGIN SELECT * FROM Books WHERE Id = @Id END");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP VIEW dbo.vw_BookEssentials");
            migrationBuilder.Sql("DROP PROCEDURE dbo.sp_GetBookById");
        }
    }
}
