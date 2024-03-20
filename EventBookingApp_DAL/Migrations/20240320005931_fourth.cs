using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EventBookingApp_DAL.Migrations
{
    /// <inheritdoc />
    public partial class fourth : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4a474838-79dd-4a10-955b-f6cacc94b5e3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ed4f232b-c097-49d2-8444-3f891fa0dac5");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "72c576f6-0aea-4aca-a431-011f90fd378d", "2da63578-a161-4a7a-9a64-cfe5630d1bd0", "Admin", "ADMIN" },
                    { "b619624f-d7e1-4299-8e59-c41af661bcc8", "04b0bdc5-138e-44c2-8d3a-a760a914b8cf", "Customer", "CUSTOMER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "72c576f6-0aea-4aca-a431-011f90fd378d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b619624f-d7e1-4299-8e59-c41af661bcc8");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4a474838-79dd-4a10-955b-f6cacc94b5e3", "2c9b7f81-cbd9-4677-8e20-e75d8ba585c4", "Customer", "CUSTOMER" },
                    { "ed4f232b-c097-49d2-8444-3f891fa0dac5", "f680d80a-6058-4491-8256-955fa910aab0", "Admin", "ADMIN" }
                });
        }
    }
}
