using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EventBookingApp_DAL.Migrations
{
    /// <inheritdoc />
    public partial class third : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "25197ec9-dfcb-4040-9526-b7d6a402c5a8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "78400dd4-43fc-437e-a512-31adbfb2f409");

            migrationBuilder.AddColumn<decimal>(
                name: "AmountPaid",
                table: "Bookings",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<bool>(
                name: "IsCancelled",
                table: "Bookings",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4a474838-79dd-4a10-955b-f6cacc94b5e3", "2c9b7f81-cbd9-4677-8e20-e75d8ba585c4", "Customer", "CUSTOMER" },
                    { "ed4f232b-c097-49d2-8444-3f891fa0dac5", "f680d80a-6058-4491-8256-955fa910aab0", "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4a474838-79dd-4a10-955b-f6cacc94b5e3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ed4f232b-c097-49d2-8444-3f891fa0dac5");

            migrationBuilder.DropColumn(
                name: "AmountPaid",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "IsCancelled",
                table: "Bookings");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "25197ec9-dfcb-4040-9526-b7d6a402c5a8", "ecabfe36-d5d7-4102-aa78-91f7bdee4142", "Admin", "ADMIN" },
                    { "78400dd4-43fc-437e-a512-31adbfb2f409", "839be240-f5c5-4ea2-b95a-26346acaec60", "Customer", "CUSTOMER" }
                });
        }
    }
}
