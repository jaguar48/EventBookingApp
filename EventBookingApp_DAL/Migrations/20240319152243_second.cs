using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EventBookingApp_DAL.Migrations
{
    /// <inheritdoc />
    public partial class second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Booking_Customer_CustomerId",
                table: "Booking");

            migrationBuilder.DropForeignKey(
                name: "FK_Booking_Events_EventId",
                table: "Booking");

            migrationBuilder.DropForeignKey(
                name: "FK_Customer_AspNetUsers_UserId",
                table: "Customer");

            migrationBuilder.DropForeignKey(
                name: "FK_Wallet_Customer_CustomerId",
                table: "Wallet");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Wallet",
                table: "Wallet");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customer",
                table: "Customer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Booking",
                table: "Booking");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5a563c4c-9cd3-477e-83ae-f7c567ca8881");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d085fa82-f9ad-4f64-b1c8-6f5686d9786b");

            migrationBuilder.RenameTable(
                name: "Wallet",
                newName: "Wallets");

            migrationBuilder.RenameTable(
                name: "Customer",
                newName: "Customers");

            migrationBuilder.RenameTable(
                name: "Booking",
                newName: "Bookings");

            migrationBuilder.RenameIndex(
                name: "IX_Wallet_CustomerId",
                table: "Wallets",
                newName: "IX_Wallets_CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_Customer_UserId",
                table: "Customers",
                newName: "IX_Customers_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Booking_EventId",
                table: "Bookings",
                newName: "IX_Bookings_EventId");

            migrationBuilder.RenameIndex(
                name: "IX_Booking_CustomerId",
                table: "Bookings",
                newName: "IX_Bookings_CustomerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Wallets",
                table: "Wallets",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customers",
                table: "Customers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bookings",
                table: "Bookings",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "25197ec9-dfcb-4040-9526-b7d6a402c5a8", "ecabfe36-d5d7-4102-aa78-91f7bdee4142", "Admin", "ADMIN" },
                    { "78400dd4-43fc-437e-a512-31adbfb2f409", "839be240-f5c5-4ea2-b95a-26346acaec60", "Customer", "CUSTOMER" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Customers_CustomerId",
                table: "Bookings",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Events_EventId",
                table: "Bookings",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_AspNetUsers_UserId",
                table: "Customers",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Wallets_Customers_CustomerId",
                table: "Wallets",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Customers_CustomerId",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Events_EventId",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Customers_AspNetUsers_UserId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Wallets_Customers_CustomerId",
                table: "Wallets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Wallets",
                table: "Wallets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customers",
                table: "Customers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Bookings",
                table: "Bookings");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "25197ec9-dfcb-4040-9526-b7d6a402c5a8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "78400dd4-43fc-437e-a512-31adbfb2f409");

            migrationBuilder.RenameTable(
                name: "Wallets",
                newName: "Wallet");

            migrationBuilder.RenameTable(
                name: "Customers",
                newName: "Customer");

            migrationBuilder.RenameTable(
                name: "Bookings",
                newName: "Booking");

            migrationBuilder.RenameIndex(
                name: "IX_Wallets_CustomerId",
                table: "Wallet",
                newName: "IX_Wallet_CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_Customers_UserId",
                table: "Customer",
                newName: "IX_Customer_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Bookings_EventId",
                table: "Booking",
                newName: "IX_Booking_EventId");

            migrationBuilder.RenameIndex(
                name: "IX_Bookings_CustomerId",
                table: "Booking",
                newName: "IX_Booking_CustomerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Wallet",
                table: "Wallet",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customer",
                table: "Customer",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Booking",
                table: "Booking",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5a563c4c-9cd3-477e-83ae-f7c567ca8881", "8a5071c6-2404-49cc-be08-925ec0119d1d", "Admin", "ADMIN" },
                    { "d085fa82-f9ad-4f64-b1c8-6f5686d9786b", "ec45ba5a-9432-4488-bb94-f4d9876c9348", "Customer", "CUSTOMER" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_Customer_CustomerId",
                table: "Booking",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_Events_EventId",
                table: "Booking",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Customer_AspNetUsers_UserId",
                table: "Customer",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Wallet_Customer_CustomerId",
                table: "Wallet",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
