using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Embaby.Migrations
{
    public partial class Intializing : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BlockReasons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlockReasons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Messeges",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messeges", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(25)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(25)", nullable: true),
                    NewMessageCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Blocking",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BlockerId = table.Column<int>(type: "int", nullable: false),
                    BlockedId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blocking", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Blocking_Users_BlockedId",
                        column: x => x.BlockedId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Blocking_Users_BlockerId",
                        column: x => x.BlockerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Messagings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SenderId = table.Column<int>(type: "int", nullable: false),
                    ReceiverId = table.Column<int>(type: "int", nullable: false),
                    MessageId = table.Column<int>(type: "int", nullable: false),
                    DateSending = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsSeen = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messagings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Messagings_Messeges_MessageId",
                        column: x => x.MessageId,
                        principalTable: "Messeges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Messagings_Users_ReceiverId",
                        column: x => x.ReceiverId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Messagings_Users_SenderId",
                        column: x => x.SenderId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BlockCause",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReasonId = table.Column<int>(type: "int", nullable: false),
                    BlockingId = table.Column<int>(type: "int", nullable: false),
                    BlockReasonId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlockCause", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BlockCause_Blocking_BlockingId",
                        column: x => x.BlockingId,
                        principalTable: "Blocking",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BlockCause_BlockReasons_BlockReasonId",
                        column: x => x.BlockReasonId,
                        principalTable: "BlockReasons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BlockCause_BlockingId",
                table: "BlockCause",
                column: "BlockingId");

            migrationBuilder.CreateIndex(
                name: "IX_BlockCause_BlockReasonId",
                table: "BlockCause",
                column: "BlockReasonId");

            migrationBuilder.CreateIndex(
                name: "IX_Blocking_BlockedId",
                table: "Blocking",
                column: "BlockedId");

            migrationBuilder.CreateIndex(
                name: "IX_Blocking_BlockerId",
                table: "Blocking",
                column: "BlockerId");

            migrationBuilder.CreateIndex(
                name: "IX_Messagings_MessageId",
                table: "Messagings",
                column: "MessageId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Messagings_ReceiverId",
                table: "Messagings",
                column: "ReceiverId");

            migrationBuilder.CreateIndex(
                name: "IX_Messagings_SenderId",
                table: "Messagings",
                column: "SenderId");
            migrationBuilder.Sql(@"
CREATE PROCEDURE AddNewUser
    (
    @name nvarchar(50),
    @email nvarchar(25),
    @password nvarchar(25)
    )
AS 
BEGIN;
IF NOT EXISTS(SELECT * FROM Users WHERE Name=@name OR Email=@email)
    BEGIN 
    INSERT INTO Users (Name, Email, Password) 
    VALUES (@name,@email,@password);
    RETURN 1;
    END
    ELSE 
    RETURN 0;
END;");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlockCause");

            migrationBuilder.DropTable(
                name: "Messagings");

            migrationBuilder.DropTable(
                name: "Blocking");

            migrationBuilder.DropTable(
                name: "BlockReasons");

            migrationBuilder.DropTable(
                name: "Messeges");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
