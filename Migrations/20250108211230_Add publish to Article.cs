using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Newspaper.Migrations
{
    /// <inheritdoc />
    public partial class AddpublishtoArticle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Articles",
                type: "character varying(250)",
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Body",
                table: "Articles",
                type: "character varying(500000)",
                maxLength: 500000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<bool>(
                name: "IsPublished",
                table: "Articles",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastEditDate",
                table: "Articles",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PublishDate",
                table: "Articles",
                type: "timestamp with time zone",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPublished",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "LastEditDate",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "PublishDate",
                table: "Articles");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Articles",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(250)",
                oldMaxLength: 250);

            migrationBuilder.AlterColumn<string>(
                name: "Body",
                table: "Articles",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(500000)",
                oldMaxLength: 500000);
        }
    }
}
