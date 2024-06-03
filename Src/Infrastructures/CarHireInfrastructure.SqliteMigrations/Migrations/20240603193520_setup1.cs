using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarHireInfrastructure.SqliteMigrations.Migrations
{
    /// <inheritdoc />
    public partial class setup1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoleRoleGroup_RoleGroup_RoleGroupId",
                table: "RoleRoleGroup");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_RoleGroup_RoleGroupId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RoleGroup",
                table: "RoleGroup");

            migrationBuilder.RenameTable(
                name: "RoleGroup",
                newName: "RoleGroups");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoleGroups",
                table: "RoleGroups",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RoleRoleGroup_RoleGroups_RoleGroupId",
                table: "RoleRoleGroup",
                column: "RoleGroupId",
                principalTable: "RoleGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_RoleGroups_RoleGroupId",
                table: "Users",
                column: "RoleGroupId",
                principalTable: "RoleGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoleRoleGroup_RoleGroups_RoleGroupId",
                table: "RoleRoleGroup");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_RoleGroups_RoleGroupId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RoleGroups",
                table: "RoleGroups");

            migrationBuilder.RenameTable(
                name: "RoleGroups",
                newName: "RoleGroup");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoleGroup",
                table: "RoleGroup",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RoleRoleGroup_RoleGroup_RoleGroupId",
                table: "RoleRoleGroup",
                column: "RoleGroupId",
                principalTable: "RoleGroup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_RoleGroup_RoleGroupId",
                table: "Users",
                column: "RoleGroupId",
                principalTable: "RoleGroup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
