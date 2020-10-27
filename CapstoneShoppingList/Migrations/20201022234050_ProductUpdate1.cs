using Microsoft.EntityFrameworkCore.Migrations;

namespace CapstoneShoppingList.Migrations
{
    public partial class ProductUpdate1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductID", "ProductName", "ProductPrice" },
                values: new object[] { 2, "Chips", 3.99m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductID", "ProductName", "ProductPrice" },
                values: new object[] { 3, "Pop", 0.99m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductID", "ProductName", "ProductPrice" },
                values: new object[] { 4, "Pizza", 5.00m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 4);
        }
    }
}
