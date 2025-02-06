using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Evcomp.API.Migrations
{
    /// <inheritdoc />
    public partial class AddTitleAndShortDescriptionToComputerEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ShortDescription",
                table: "Computers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Computers",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShortDescription",
                table: "Computers");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Computers");
        }
    }
}
