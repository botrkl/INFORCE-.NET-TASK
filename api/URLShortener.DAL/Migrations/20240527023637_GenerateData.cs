using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace URLShortener.DAL.Migrations
{
    /// <inheritdoc />
    public partial class GenerateData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "HashPassword", "Username" },
                values: new object[] { new Guid("539ad3f7-7478-4b34-8a09-9509b6f4adfd"), "r4A/IOyfd//CftSMJ0/HYQ==:57hdC+TEJMp1K0tT8g9idzFKhJShQa+s0kDt7EVaoMQ=", "test2" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "HashPassword", "IsAdmin", "Username" },
                values: new object[] { new Guid("747a1720-4ca3-43e2-93fa-becc860589dc"), "r4A/IOyfd//CftSMJ0/HYQ==:57hdC+TEJMp1K0tT8g9idzFKhJShQa+s0kDt7EVaoMQ=", true, "admin" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "HashPassword", "Username" },
                values: new object[] { new Guid("9b4673fb-20c2-4341-9a36-a3cfaa22878b"), "r4A/IOyfd//CftSMJ0/HYQ==:57hdC+TEJMp1K0tT8g9idzFKhJShQa+s0kDt7EVaoMQ=", "test1" });

            migrationBuilder.InsertData(
                table: "UrlAdresses",
                columns: new[] { "Id", "CreatedDate", "OriginalUrl", "ShortenedUrl", "UserId" },
                values: new object[,]
                {
                    { new Guid("50a89e67-967e-4d98-916e-c53378a48a6b"), new DateTime(2024, 5, 27, 5, 36, 35, 992, DateTimeKind.Local).AddTicks(5105), "OriginalUrl/justForTest", "ShortenedUrl/justForTest", new Guid("539ad3f7-7478-4b34-8a09-9509b6f4adfd") },
                    { new Guid("70c755bd-f96b-4a82-8a0a-a29fbba009f4"), new DateTime(2024, 5, 27, 5, 36, 35, 988, DateTimeKind.Local).AddTicks(7008), "OriginalUrl/justForTest", "ShortenedUrl/justForTest", new Guid("9b4673fb-20c2-4341-9a36-a3cfaa22878b") },
                    { new Guid("78f30a41-a1da-4c73-b237-7879864d854b"), new DateTime(2024, 5, 27, 5, 36, 35, 992, DateTimeKind.Local).AddTicks(5062), "OriginalUrl/justForTest", "ShortenedUrl/justForTest", new Guid("9b4673fb-20c2-4341-9a36-a3cfaa22878b") },
                    { new Guid("8a7e0782-8fb7-4371-986d-b3110255bc59"), new DateTime(2024, 5, 27, 5, 36, 35, 992, DateTimeKind.Local).AddTicks(5100), "OriginalUrl/justForTest", "ShortenedUrl/justForTest", new Guid("747a1720-4ca3-43e2-93fa-becc860589dc") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UrlAdresses",
                keyColumn: "Id",
                keyValue: new Guid("50a89e67-967e-4d98-916e-c53378a48a6b"));

            migrationBuilder.DeleteData(
                table: "UrlAdresses",
                keyColumn: "Id",
                keyValue: new Guid("70c755bd-f96b-4a82-8a0a-a29fbba009f4"));

            migrationBuilder.DeleteData(
                table: "UrlAdresses",
                keyColumn: "Id",
                keyValue: new Guid("78f30a41-a1da-4c73-b237-7879864d854b"));

            migrationBuilder.DeleteData(
                table: "UrlAdresses",
                keyColumn: "Id",
                keyValue: new Guid("8a7e0782-8fb7-4371-986d-b3110255bc59"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("539ad3f7-7478-4b34-8a09-9509b6f4adfd"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("747a1720-4ca3-43e2-93fa-becc860589dc"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("9b4673fb-20c2-4341-9a36-a3cfaa22878b"));
        }
    }
}
