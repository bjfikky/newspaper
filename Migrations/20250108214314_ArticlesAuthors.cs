using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Newspaper.Migrations
{
    /// <inheritdoc />
    public partial class ArticlesAuthors : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ArticleAuthor",
                columns: table => new
                {
                    ArticlesId = table.Column<int>(type: "integer", nullable: false),
                    AuthorsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleAuthor", x => new { x.ArticlesId, x.AuthorsId });
                    table.ForeignKey(
                        name: "FK_ArticleAuthor_Articles_ArticlesId",
                        column: x => x.ArticlesId,
                        principalTable: "Articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArticleAuthor_Authors_AuthorsId",
                        column: x => x.AuthorsId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArticleAuthor_AuthorsId",
                table: "ArticleAuthor",
                column: "AuthorsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArticleAuthor");
        }
    }
}
