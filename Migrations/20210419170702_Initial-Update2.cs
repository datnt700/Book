using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LibraryBook.Migrations
{
    public partial class InitialUpdate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "DoB",
                value: new DateTime(2001, 4, 20, 0, 7, 1, 909, DateTimeKind.Local).AddTicks(7465));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "DoB",
                value: new DateTime(1991, 4, 20, 0, 7, 1, 910, DateTimeKind.Local).AddTicks(7662));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "DoB",
                value: new DateTime(2001, 4, 20, 0, 0, 56, 669, DateTimeKind.Local).AddTicks(1769));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "DoB",
                value: new DateTime(1991, 4, 20, 0, 0, 56, 670, DateTimeKind.Local).AddTicks(2537));
        }
    }
}
