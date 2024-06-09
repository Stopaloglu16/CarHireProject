using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarHireInfrastructure.SqlServerMigrations.Migrations.ApplicationDb
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AuditLogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TableName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OldValues = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NewValues = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AffectedColumns = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrimaryKey = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditLogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Branches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BranchName = table.Column<string>(type: "varchar(50)", nullable: false),
                    Address1 = table.Column<string>(type: "varchar(50)", nullable: false),
                    City = table.Column<string>(type: "varchar(50)", nullable: false),
                    Postcode = table.Column<string>(type: "varchar(10)", nullable: false),
                    IsDeleted = table.Column<byte>(type: "tinyint", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branches", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CarBrands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", nullable: false),
                    IsDeleted = table.Column<byte>(type: "tinyint", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarBrands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CarExtras",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", nullable: false),
                    Cost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsDeleted = table.Column<byte>(type: "tinyint", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarExtras", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoleGroups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleGroupName = table.Column<string>(type: "varchar(50)", nullable: false),
                    UserTypeId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<byte>(type: "tinyint", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "varchar(150)", nullable: false),
                    IsDeleted = table.Column<byte>(type: "tinyint", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WebMenus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MainName = table.Column<string>(type: "varchar(50)", nullable: false),
                    SubName = table.Column<string>(type: "varchar(50)", nullable: false),
                    LinkName = table.Column<string>(type: "varchar(50)", nullable: false),
                    LinkUrl = table.Column<string>(type: "varchar(150)", nullable: false),
                    MenuOrder = table.Column<int>(type: "int", nullable: false),
                    IconName = table.Column<string>(type: "varchar(50)", nullable: false),
                    ButtonTypeId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WebMenus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CarModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", nullable: false),
                    CarPhoto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CarPhotoLenght = table.Column<int>(type: "int", nullable: true),
                    SeatNumber = table.Column<int>(type: "int", nullable: false),
                    CarBrandId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<byte>(type: "tinyint", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarModels_CarBrands_CarBrandId",
                        column: x => x.CarBrandId,
                        principalTable: "CarBrands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "varchar(100)", nullable: false),
                    UserEmail = table.Column<string>(type: "varchar(250)", nullable: false),
                    UserTypeId = table.Column<int>(type: "int", nullable: false),
                    RoleGroupId = table.Column<int>(type: "int", nullable: false),
                    AspId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegisterToken = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RegisterTokenValid = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BranchId = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<byte>(type: "tinyint", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Users_RoleGroups_RoleGroupId",
                        column: x => x.RoleGroupId,
                        principalTable: "RoleGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoleRoleGroup",
                columns: table => new
                {
                    RoleGroupId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    HaveSkillSince = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleRoleGroup", x => new { x.RoleGroupId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_RoleRoleGroup_RoleGroups_RoleGroupId",
                        column: x => x.RoleGroupId,
                        principalTable: "RoleGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoleRoleGroup_Roles",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumberPlates = table.Column<string>(type: "varchar(10)", nullable: false),
                    BranchId = table.Column<int>(type: "int", nullable: true),
                    CarModelId = table.Column<int>(type: "int", nullable: false),
                    GearboxId = table.Column<int>(type: "int", nullable: false),
                    Mileage = table.Column<int>(type: "int", nullable: false),
                    Costperday = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsDeleted = table.Column<byte>(type: "tinyint", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cars_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Cars_CarModels_CarModelId",
                        column: x => x.CarModelId,
                        principalTable: "CarModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RefreshTokens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefreshTokens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoleUser",
                columns: table => new
                {
                    RolesId = table.Column<int>(type: "int", nullable: false),
                    UsersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleUser", x => new { x.RolesId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_RoleUser_Roles_RolesRoleId",
                        column: x => x.RolesId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoleUser_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CarHireLogs",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    PickUpBranchId = table.Column<int>(type: "int", nullable: false),
                    PickUpDate = table.Column<DateTime>(type: "Date", nullable: false),
                    PickUpDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PickUpConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PickupMileage = table.Column<int>(type: "int", nullable: false),
                    ReturnBranchId = table.Column<int>(type: "int", nullable: false),
                    ReturnDate = table.Column<DateTime>(type: "Date", nullable: false),
                    ReturnDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReturnConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    ReturnMileage = table.Column<int>(type: "int", nullable: false),
                    BookingCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsDeleted = table.Column<byte>(type: "tinyint", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarHireLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarHireLogs_Branches_PickUpBranchId",
                        column: x => x.PickUpBranchId,
                        principalTable: "Branches",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CarHireLogs_Branches_ReturnBranchId",
                        column: x => x.ReturnBranchId,
                        principalTable: "Branches",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CarHireLogs_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarHireLogs_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CarExtraCarHireLog",
                columns: table => new
                {
                    CarExtrasId = table.Column<int>(type: "int", nullable: false),
                    CarHiresId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarExtraCarHireLog", x => new { x.CarExtrasId, x.CarHiresId });
                    table.ForeignKey(
                        name: "FK_CarExtraCarHireLog_CarExtras_CarExtrasId",
                        column: x => x.CarExtrasId,
                        principalTable: "CarExtras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarExtraCarHireLog_CarHireLogs_CarHiresId",
                        column: x => x.CarHiresId,
                        principalTable: "CarHireLogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarExtraCarHireLog_CarHiresId",
                table: "CarExtraCarHireLog",
                column: "CarHiresId");

            migrationBuilder.CreateIndex(
                name: "IX_CarHireLogs_CarId",
                table: "CarHireLogs",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_CarHireLogs_PickUpBranchId",
                table: "CarHireLogs",
                column: "PickUpBranchId");

            migrationBuilder.CreateIndex(
                name: "IX_CarHireLogs_ReturnBranchId",
                table: "CarHireLogs",
                column: "ReturnBranchId");

            migrationBuilder.CreateIndex(
                name: "IX_CarHireLogs_UserId",
                table: "CarHireLogs",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CarModels_CarBrandId",
                table: "CarModels",
                column: "CarBrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_BranchId",
                table: "Cars",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_CarModelId",
                table: "Cars",
                column: "CarModelId");

            migrationBuilder.CreateIndex(
                name: "IX_RefreshTokens_UserId",
                table: "RefreshTokens",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleRoleGroup_RoleId",
                table: "RoleRoleGroup",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleUser_UsersId",
                table: "RoleUser",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_BranchId",
                table: "Users",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleGroupId",
                table: "Users",
                column: "RoleGroupId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuditLogs");

            migrationBuilder.DropTable(
                name: "CarExtraCarHireLog");

            migrationBuilder.DropTable(
                name: "RefreshTokens");

            migrationBuilder.DropTable(
                name: "RoleRoleGroup");

            migrationBuilder.DropTable(
                name: "RoleUser");

            migrationBuilder.DropTable(
                name: "WebMenus");

            migrationBuilder.DropTable(
                name: "CarExtras");

            migrationBuilder.DropTable(
                name: "CarHireLogs");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "CarModels");

            migrationBuilder.DropTable(
                name: "Branches");

            migrationBuilder.DropTable(
                name: "RoleGroups");

            migrationBuilder.DropTable(
                name: "CarBrands");
        }
    }
}
