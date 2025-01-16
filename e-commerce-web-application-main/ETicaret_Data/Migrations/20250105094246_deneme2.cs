using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ETicaret_Data.Migrations
{
    /// <inheritdoc />
    public partial class deneme2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "AppUsers",
                type: "nvarchar(180)",
                maxLength: 180,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(80)",
                oldMaxLength: 80);

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Email", "UserGuid" },
                values: new object[] { new DateTime(2025, 1, 5, 12, 42, 44, 963, DateTimeKind.Local).AddTicks(6344), "it@colpar.com", new Guid("ebdf0fba-9333-4e9b-adf3-20015e95ee28") });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 1, 5, 12, 42, 44, 969, DateTimeKind.Local).AddTicks(3768));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: 1907,
                column: "CreatedDate",
                value: new DateTime(2025, 1, 5, 12, 42, 44, 969, DateTimeKind.Local).AddTicks(5441));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "AppUsers",
                type: "varchar(80)",
                maxLength: 80,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(180)",
                oldMaxLength: 180);

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Email", "UserGuid" },
                values: new object[] { new DateTime(2025, 1, 5, 3, 36, 38, 297, DateTimeKind.Local).AddTicks(2747), "it@eticaret.com", new Guid("87ddc1ac-9787-4ee4-9e9a-075b738eb921") });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 1, 5, 3, 36, 38, 301, DateTimeKind.Local).AddTicks(4645));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: 1907,
                column: "CreatedDate",
                value: new DateTime(2025, 1, 5, 3, 36, 38, 301, DateTimeKind.Local).AddTicks(6330));
        }
    }
}
