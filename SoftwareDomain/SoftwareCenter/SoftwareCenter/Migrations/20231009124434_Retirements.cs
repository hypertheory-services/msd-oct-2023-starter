using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoftwareCenter.Migrations
{
    /// <inheritdoc />
    public partial class Retirements : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Retired",
                table: "Titles",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Retired",
                table: "Titles");
        }
    }
}
