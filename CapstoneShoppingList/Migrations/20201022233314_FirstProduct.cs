using Microsoft.EntityFrameworkCore.Migrations;

namespace CapstoneShoppingList.Migrations
{
    public partial class FirstProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductID", "ProductName", "ProductPrice" },
                values: new object[] { 1, "Candy", 1.99m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 1);
        }
    }
}
