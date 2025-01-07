using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDB_V10_07142924 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "AccountId",
                keyValue: new Guid("3c03312e-1a59-47ef-99dd-8375d37a4130"));

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "AccountId",
                keyValue: new Guid("7c464da0-bb4b-4916-91f8-a32de8f709e1"));

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "AccountId",
                keyValue: new Guid("930ee83b-c8eb-42a2-82e9-64b4476b9654"));

            migrationBuilder.AddColumn<string>(
                name: "AvatarUrl",
                table: "PostRequests",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "AccountId", "Address", "AvatarUrl", "Email", "Fullname", "Gender", "Password", "Phone", "RoleId", "Username" },
                values: new object[,]
                {
                    { new Guid("52bab2a1-33f6-4c1b-bd66-4c5b16339271"), "Ho Chi Minh, Viet Name", null, "vana@gmail.com", "Tran Van A", 0, "@123", "0978988768", 4, "parent1" },
                    { new Guid("9aff9596-7a63-4110-9cc7-29ee73a27d96"), "Ho Chi Minh, Viet Name", null, "admin@gmail.com", "ADMIN", 1, "admin123", "0945677876", 1, "admin" },
                    { new Guid("a4d5ee29-6e30-440b-a644-e215eda7e882"), "Ho Chi Minh, Viet Name", null, "staff@gmail.com", "STAFF", 0, "staff123", "0912377890", 2, "staff" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "AccountId",
                keyValue: new Guid("52bab2a1-33f6-4c1b-bd66-4c5b16339271"));

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "AccountId",
                keyValue: new Guid("9aff9596-7a63-4110-9cc7-29ee73a27d96"));

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "AccountId",
                keyValue: new Guid("a4d5ee29-6e30-440b-a644-e215eda7e882"));

            migrationBuilder.DropColumn(
                name: "AvatarUrl",
                table: "PostRequests");

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "AccountId", "Address", "AvatarUrl", "Email", "Fullname", "Gender", "Password", "Phone", "RoleId", "Username" },
                values: new object[,]
                {
                    { new Guid("3c03312e-1a59-47ef-99dd-8375d37a4130"), "Ho Chi Minh, Viet Name", null, "admin@gmail.com", "ADMIN", 1, "admin123", "0945677876", 1, "admin" },
                    { new Guid("7c464da0-bb4b-4916-91f8-a32de8f709e1"), "Ho Chi Minh, Viet Name", null, "staff@gmail.com", "STAFF", 0, "staff123", "0912377890", 2, "staff" },
                    { new Guid("930ee83b-c8eb-42a2-82e9-64b4476b9654"), "Ho Chi Minh, Viet Name", null, "vana@gmail.com", "Tran Van A", 0, "@123", "0978988768", 4, "parent1" }
                });
        }
    }
}
