using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace affordable_skin.Migrations
{
    /// <inheritdoc />
    public partial class linkBrandProductAndLowestPrice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Brand",
                table: "Product",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Link",
                table: "Product",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "LowestPrice",
                table: "Product",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Brand",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "Link",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "LowestPrice",
                table: "Product");
        }
    }
}
