using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodingWiki.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class check : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Fluent_AuthorBooks",
                columns: table => new
                {
                    Author_Id = table.Column<int>(type: "int", nullable: false),
                    Book_Id = table.Column<int>(type: "int", nullable: false),
                    CustomNote = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fluent_AuthorBooks", x => new { x.Author_Id, x.Book_Id });
                    table.ForeignKey(
                        name: "FK_Fluent_AuthorBooks_Fluent_Authors_Author_Id",
                        column: x => x.Author_Id,
                        principalTable: "Fluent_Authors",
                        principalColumn: "Author_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Fluent_AuthorBooks_Fluent_Books_Book_Id",
                        column: x => x.Book_Id,
                        principalTable: "Fluent_Books",
                        principalColumn: "Book_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Fluent_AuthorBooks_Book_Id",
                table: "Fluent_AuthorBooks",
                column: "Book_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Fluent_AuthorBooks");
        }
    }
}
