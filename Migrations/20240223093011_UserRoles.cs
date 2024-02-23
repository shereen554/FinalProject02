using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class UserRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1ad67312-e72b-4cef-9386-c42d147fff0c", "15ef13cb-d033-4846-a7e8-31f0a49a8009", "Customer", "customer" },
                    { "a22d1956-3217-4910-8361-0c519c47e910", "4dc52ba8-d7e8-4e62-86e5-588e63960ade", "Pharmacy", "pharmacy" },
                    { "b52cc945-28bf-47e2-8534-c56a9880a9fa", "c431e8e7-f7a8-4aae-b79e-baf3f957e7d7", "Delivery", "delivery" },
                    { "cf6eac61-881a-4d88-b782-7d49fe2f7565", "fea1e683-02f5-475f-95df-01087101bf43", "Admin", "admin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1ad67312-e72b-4cef-9386-c42d147fff0c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a22d1956-3217-4910-8361-0c519c47e910");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b52cc945-28bf-47e2-8534-c56a9880a9fa");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cf6eac61-881a-4d88-b782-7d49fe2f7565");
        }
    }
}
