using Microsoft.EntityFrameworkCore.Migrations;

namespace Embaby.Migrations
{
    public partial class sddeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
CREATE PROCEDURE AddNewUser
(
    @name nvarchar(max),
    @email nvarchar(max),
    @password nvarchar(max)
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
            migrationBuilder.Sql(@"
 CREATE PROC DeleteUserById(
   @id int 
   )
   AS 
       BEGIN 
           DELETE FROM Users WHERE Id=@id;
       END;
");
            migrationBuilder.Sql(@"
CREATE PROC DeleteUserByEmail(
    @email nvarchar(50)
)
AS
BEGIN
    DELETE FROM Users WHERE Email=@email;
END;
");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
