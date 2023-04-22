using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace affordable_skin.Migrations
{
    /// <inheritdoc />
    public partial class brandingProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Brand",
                table: "Product");

            migrationBuilder.AddColumn<string>(
                name: "BrandName",
                table: "Product",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Brand",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brand", x => x.Name);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_BrandName",
                table: "Product",
                column: "BrandName");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Brand_BrandName",
                table: "Product",
                column: "BrandName",
                principalTable: "Brand",
                principalColumn: "Name",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Brand_BrandName",
                table: "Product");

            migrationBuilder.DropTable(
                name: "Brand");

            migrationBuilder.DropIndex(
                name: "IX_Product_BrandName",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "BrandName",
                table: "Product");

            migrationBuilder.AddColumn<string>(
                name: "Brand",
                table: "Product",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
