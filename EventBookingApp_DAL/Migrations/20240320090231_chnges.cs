using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EventBookingApp_DAL.Migrations
{
    /// <inheritdoc />
    public partial class chnges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "72c576f6-0aea-4aca-a431-011f90fd378d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b619624f-d7e1-4299-8e59-c41af661bcc8");

            migrationBuilder.AddColumn<int>(
                name: "AvailableTickets",
                table: "Events",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NoOfTicket",
                table: "Bookings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "43690f4b-e405-4f52-830c-860d514a1718", "e126488a-d151-4d77-90e5-4cd38ec0df64", "Admin", "ADMIN" },
                    { "45b84e7b-3296-40bd-93ed-bcba2f01ca5e", "b8324c87-e76b-4f3b-814f-ee11858822bb", "Customer", "CUSTOMER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "43690f4b-e405-4f52-830c-860d514a1718");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "45b84e7b-3296-40bd-93ed-bcba2f01ca5e");

            migrationBuilder.DropColumn(
                name: "AvailableTickets",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "NoOfTicket",
                table: "Bookings");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "72c576f6-0aea-4aca-a431-011f90fd378d", "2da63578-a161-4a7a-9a64-cfe5630d1bd0", "Admin", "ADMIN" },
                    { "b619624f-d7e1-4299-8e59-c41af661bcc8", "04b0bdc5-138e-44c2-8d3a-a760a914b8cf", "Customer", "CUSTOMER" }
                });
        }
    }
}
