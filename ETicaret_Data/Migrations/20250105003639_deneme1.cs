using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ETicaret_Data.Migrations
{
    /// <inheritdoc />
    public partial class deneme1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "AppUsers",
                type: "varchar(80)",
                maxLength: 80,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(13)",
                oldMaxLength: 13);

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UserGuid" },
                values: new object[] { new DateTime(2025, 1, 5, 3, 36, 38, 297, DateTimeKind.Local).AddTicks(2747), new Guid("87ddc1ac-9787-4ee4-9e9a-075b738eb921") });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "AppUsers",
                type: "varchar(13)",
                maxLength: 13,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(80)",
                oldMaxLength: 80);

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UserGuid" },
                values: new object[] { new DateTime(2025, 1, 4, 21, 32, 10, 611, DateTimeKind.Local).AddTicks(7550), new Guid("e54db7c5-3d6e-4378-9aec-26260154b201") });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 1, 4, 21, 32, 10, 627, DateTimeKind.Local).AddTicks(7043));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: 1907,
                column: "CreatedDate",
                value: new DateTime(2025, 1, 4, 21, 32, 10, 627, DateTimeKind.Local).AddTicks(8597));
        }
    }
}
