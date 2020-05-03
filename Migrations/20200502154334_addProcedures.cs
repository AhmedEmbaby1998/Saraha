using Microsoft.EntityFrameworkCore.Migrations;

namespace Embaby.Migrations
{
    public partial class addProcedures : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messagings_Messeges_MessageId",
                table: "Messagings");

            migrationBuilder.DropIndex(
                name: "IX_Messagings_MessageId",
                table: "Messagings");

            migrationBuilder.AlterColumn<int>(
                name: "NewMessageCount",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "MessageId",
                table: "Messagings",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "BlockingId",
                table: "BlockCause",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Messagings_MessageId",
                table: "Messagings",
                column: "MessageId",
                unique: true,
                filter: "[MessageId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Messagings_Messeges_MessageId",
                table: "Messagings",
                column: "MessageId",
                principalTable: "Messeges",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
       
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messagings_Messeges_MessageId",
                table: "Messagings");

            migrationBuilder.DropIndex(
                name: "IX_Messagings_MessageId",
                table: "Messagings");

            migrationBuilder.AlterColumn<int>(
                name: "NewMessageCount",
                table: "Users",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "MessageId",
                table: "Messagings",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BlockingId",
                table: "BlockCause",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Messagings_MessageId",
                table: "Messagings",
                column: "MessageId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Messagings_Messeges_MessageId",
                table: "Messagings",
                column: "MessageId",
                principalTable: "Messeges",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
