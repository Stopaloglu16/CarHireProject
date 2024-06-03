using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarHireInfrastructure.SqliteMigrations.Migrations.WebIdentity
{
    /// <inheritdoc />
    public partial class setup1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "8fd96f80-f483-4c0e-a353-5a86ffbad757", 0, "36792d73-62ab-4846-a0a1-ed660f14ae18", "carhireadmin@hotmail.co.uk", true, false, null, "CARHIREADMIN@HOTMAIL.CO.UK", "CARHIREADMIN@HOTMAIL.CO.UK", "AQAAAAIAAYagAAAAEFZHhGNfe++GGyOLiGLKUed2QjlsVgI0/pj97ev4n7VIlHRZ399ujlGdSH/rD5qiag==", null, false, "b10b0e61-5f85-4868-b30a-0f5f5976cef5", false, "carhireadmin@hotmail.co.uk" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8fd96f80-f483-4c0e-a353-5a86ffbad757");
        }
    }
}
