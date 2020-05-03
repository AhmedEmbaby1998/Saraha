using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Embaby.Migrations
{
    public partial class addRegisteringDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "LastOnline",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 2, 19, 39, 14, 444, DateTimeKind.Local).AddTicks(2679));

            migrationBuilder.AddColumn<DateTime>(
                name: "RegisteringDateTime",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 2, 19, 39, 14, 442, DateTimeKind.Local).AddTicks(2662));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastOnline",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "RegisteringDateTime",
                table: "Users");
        }
    }
}
