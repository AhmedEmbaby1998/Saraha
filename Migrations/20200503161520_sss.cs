using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Embaby.Migrations
{
    public partial class sss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlockCause_Blocking_BlockingId",
                table: "BlockCause");

            migrationBuilder.DropForeignKey(
                name: "FK_BlockCause_BlockReasons_BlockReasonId",
                table: "BlockCause");

            migrationBuilder.DropForeignKey(
                name: "FK_Blocking_Users_BlockedId",
                table: "Blocking");

            migrationBuilder.DropForeignKey(
                name: "FK_Blocking_Users_BlockerId",
                table: "Blocking");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Blocking",
                table: "Blocking");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BlockCause",
                table: "BlockCause");

            migrationBuilder.RenameTable(
                name: "Blocking",
                newName: "Blockings");

            migrationBuilder.RenameTable(
                name: "BlockCause",
                newName: "BlockCauses");

            migrationBuilder.RenameIndex(
                name: "IX_Blocking_BlockerId",
                table: "Blockings",
                newName: "IX_Blockings_BlockerId");

            migrationBuilder.RenameIndex(
                name: "IX_Blocking_BlockedId",
                table: "Blockings",
                newName: "IX_Blockings_BlockedId");

            migrationBuilder.RenameIndex(
                name: "IX_BlockCause_BlockReasonId",
                table: "BlockCauses",
                newName: "IX_BlockCauses_BlockReasonId");

            migrationBuilder.RenameIndex(
                name: "IX_BlockCause_BlockingId",
                table: "BlockCauses",
                newName: "IX_BlockCauses_BlockingId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "RegisteringDateTime",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 3, 18, 15, 19, 830, DateTimeKind.Local).AddTicks(2028),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 5, 2, 19, 39, 14, 442, DateTimeKind.Local).AddTicks(2662));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastOnline",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 3, 18, 15, 19, 832, DateTimeKind.Local).AddTicks(1018),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 5, 2, 19, 39, 14, 444, DateTimeKind.Local).AddTicks(2679));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Blockings",
                table: "Blockings",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BlockCauses",
                table: "BlockCauses",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BlockCauses_Blockings_BlockingId",
                table: "BlockCauses",
                column: "BlockingId",
                principalTable: "Blockings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BlockCauses_BlockReasons_BlockReasonId",
                table: "BlockCauses",
                column: "BlockReasonId",
                principalTable: "BlockReasons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Blockings_Users_BlockedId",
                table: "Blockings",
                column: "BlockedId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Blockings_Users_BlockerId",
                table: "Blockings",
                column: "BlockerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlockCauses_Blockings_BlockingId",
                table: "BlockCauses");

            migrationBuilder.DropForeignKey(
                name: "FK_BlockCauses_BlockReasons_BlockReasonId",
                table: "BlockCauses");

            migrationBuilder.DropForeignKey(
                name: "FK_Blockings_Users_BlockedId",
                table: "Blockings");

            migrationBuilder.DropForeignKey(
                name: "FK_Blockings_Users_BlockerId",
                table: "Blockings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Blockings",
                table: "Blockings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BlockCauses",
                table: "BlockCauses");

            migrationBuilder.RenameTable(
                name: "Blockings",
                newName: "Blocking");

            migrationBuilder.RenameTable(
                name: "BlockCauses",
                newName: "BlockCause");

            migrationBuilder.RenameIndex(
                name: "IX_Blockings_BlockerId",
                table: "Blocking",
                newName: "IX_Blocking_BlockerId");

            migrationBuilder.RenameIndex(
                name: "IX_Blockings_BlockedId",
                table: "Blocking",
                newName: "IX_Blocking_BlockedId");

            migrationBuilder.RenameIndex(
                name: "IX_BlockCauses_BlockReasonId",
                table: "BlockCause",
                newName: "IX_BlockCause_BlockReasonId");

            migrationBuilder.RenameIndex(
                name: "IX_BlockCauses_BlockingId",
                table: "BlockCause",
                newName: "IX_BlockCause_BlockingId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "RegisteringDateTime",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 2, 19, 39, 14, 442, DateTimeKind.Local).AddTicks(2662),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 5, 3, 18, 15, 19, 830, DateTimeKind.Local).AddTicks(2028));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastOnline",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 2, 19, 39, 14, 444, DateTimeKind.Local).AddTicks(2679),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 5, 3, 18, 15, 19, 832, DateTimeKind.Local).AddTicks(1018));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Blocking",
                table: "Blocking",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BlockCause",
                table: "BlockCause",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BlockCause_Blocking_BlockingId",
                table: "BlockCause",
                column: "BlockingId",
                principalTable: "Blocking",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BlockCause_BlockReasons_BlockReasonId",
                table: "BlockCause",
                column: "BlockReasonId",
                principalTable: "BlockReasons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Blocking_Users_BlockedId",
                table: "Blocking",
                column: "BlockedId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Blocking_Users_BlockerId",
                table: "Blocking",
                column: "BlockerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
