using System.ComponentModel;
using System.Runtime.InteropServices;
using Microsoft.EntityFrameworkCore;

namespace SimpleSaraha.Models.Entities
{
    public static class StoredProcedures
    {
        public static bool InsertNewUser(this SarahaContext context,string name ,string email,string password)
        {
            var row = context.Database.ExecuteSqlInterpolated(
                $"EXEC AddNewUser @name={name},@email={email},@password={password}");
            return row != 0;
        }

        public static bool DeleteUser(this SarahaContext context, int id)
        {
            var row = context.Database.ExecuteSqlInterpolated(
                $"EXEC DeleteUserById @id={id}");
            return row != 0;
        }
        public static bool DeleteUser(this SarahaContext context, string email)
        {
            var row = context.Database.ExecuteSqlInterpolated(
                $"EXEC DeleteUserByEmail @email={email}");
            return row != 0;
        }
    }
}