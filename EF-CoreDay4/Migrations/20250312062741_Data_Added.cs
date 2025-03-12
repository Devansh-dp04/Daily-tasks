using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EF_CoreDay4.Migrations
{
    /// <inheritdoc />
    public partial class Data_Added : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "OrderProducts",
                columns: new[] { "OrderId", "ProductId", "Id", "Quantity" },
                values: new object[] { 5, 5, 6, 2 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "OrderProducts",
                keyColumns: new[] { "OrderId", "ProductId" },
                keyValues: new object[] { 5, 5 });
        }
    }
}
