using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace affordable_skin.Migrations
{
    /// <inheritdoc />
    public partial class initialSetup3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Seller",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Webpage",
                table: "Seller",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Product",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Product",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "Product",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SellerId",
                table: "Product",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Product_SellerId",
                table: "Product",
                column: "SellerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Seller_SellerId",
                table: "Product",
                column: "SellerId",
                principalTable: "Seller",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Seller_SellerId",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_SellerId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Seller");

            migrationBuilder.DropColumn(
                name: "Webpage",
                table: "Seller");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "SellerId",
                table: "Product");
        }
    }
}
