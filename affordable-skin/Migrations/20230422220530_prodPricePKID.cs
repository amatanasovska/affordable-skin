using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace affordable_skin.Migrations
{
    /// <inheritdoc />
    public partial class prodPricePKID : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductPrice",
                table: "ProductPrice");

            migrationBuilder.AlterColumn<string>(
                name: "Date",
                table: "ProductPrice",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "ProductPrice",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductPrice",
                table: "ProductPrice",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductPrice",
                table: "ProductPrice");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ProductPrice");

            migrationBuilder.AlterColumn<string>(
                name: "Date",
                table: "ProductPrice",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductPrice",
                table: "ProductPrice",
                columns: new[] { "Date", "ProductId", "SellerName" });
        }
    }
}
