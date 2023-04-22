using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace affordable_skin.Migrations
{
    /// <inheritdoc />
    public partial class prodPricePK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductPrice",
                table: "ProductPrice");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductPrice",
                table: "ProductPrice",
                columns: new[] { "Date", "ProductId", "SellerName" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductPrice",
                table: "ProductPrice");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductPrice",
                table: "ProductPrice",
                columns: new[] { "Date", "ProductId" });
        }
    }
}
