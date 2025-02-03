using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ETicaret_Data.Migrations
{
    /// <inheritdoc />
    public partial class NewsConfigDESC : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "News",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(680)",
                oldMaxLength: 680,
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UserGuid" },
                values: new object[] { new DateTime(2025, 1, 30, 12, 39, 5, 75, DateTimeKind.Local).AddTicks(7933), new Guid("7442ef81-a429-4540-ab28-e99295152938") });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 1, 30, 12, 39, 5, 84, DateTimeKind.Local).AddTicks(4226));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: 1907,
                column: "CreatedDate",
                value: new DateTime(2025, 1, 30, 12, 39, 5, 84, DateTimeKind.Local).AddTicks(7861));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "News",
                type: "nvarchar(680)",
                maxLength: 680,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UserGuid" },
                values: new object[] { new DateTime(2025, 1, 5, 12, 42, 44, 963, DateTimeKind.Local).AddTicks(6344), new Guid("ebdf0fba-9333-4e9b-adf3-20015e95ee28") });

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
    }
}
