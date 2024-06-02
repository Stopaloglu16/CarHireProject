﻿// <auto-generated />
using System;
using CarHireInfrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CarHireInfrastructure.SqliteMigrations.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240602193651_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.1");

            modelBuilder.Entity("CarExtraCarHireLog", b =>
                {
                    b.Property<int>("CarExtrasId")
                        .HasColumnType("INTEGER");

                    b.Property<long>("CarHiresId")
                        .HasColumnType("INTEGER");

                    b.HasKey("CarExtrasId", "CarHiresId");

                    b.HasIndex("CarHiresId");

                    b.ToTable("CarExtraCarHireLog");
                });

            modelBuilder.Entity("CarHireInfrastructure.CommonModel.Audit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AffectedColumns")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("NewValues")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("OldValues")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PrimaryKey")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("TableName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("AuditLogs");
                });

            modelBuilder.Entity("Domain.Entities.Branch", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Address1")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("BranchName")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("TEXT");

                    b.Property<byte>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("TEXT");

                    b.Property<string>("Postcode")
                        .IsRequired()
                        .HasColumnType("varchar(10)");

                    b.HasKey("Id");

                    b.ToTable("Branches");
                });

            modelBuilder.Entity("Domain.Entities.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("BranchId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CarModelId")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Costperday")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("TEXT");

                    b.Property<int>("GearboxId")
                        .HasColumnType("INTEGER");

                    b.Property<byte>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("TEXT");

                    b.Property<int>("Mileage")
                        .HasColumnType("INTEGER");

                    b.Property<string>("NumberPlates")
                        .IsRequired()
                        .HasColumnType("varchar(10)");

                    b.HasKey("Id");

                    b.HasIndex("BranchId");

                    b.HasIndex("CarModelId");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("Domain.Entities.CarBrand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("TEXT");

                    b.Property<byte>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("CarBrands");
                });

            modelBuilder.Entity("Domain.Entities.CarExtra", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Cost")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("TEXT");

                    b.Property<byte>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("CarExtras");
                });

            modelBuilder.Entity("Domain.Entities.CarHireLog", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("BookingCost")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("CarId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("TEXT");

                    b.Property<byte>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("TEXT");

                    b.Property<int>("PickUpBranchId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("PickUpConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("PickUpDate")
                        .HasColumnType("Date");

                    b.Property<DateTime>("PickUpDateTime")
                        .HasColumnType("TEXT");

                    b.Property<int>("PickupMileage")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ReturnBranchId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("ReturnConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("ReturnDate")
                        .HasColumnType("Date");

                    b.Property<DateTime>("ReturnDateTime")
                        .HasColumnType("TEXT");

                    b.Property<int>("ReturnMileage")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("CarId");

                    b.HasIndex("PickUpBranchId");

                    b.HasIndex("ReturnBranchId");

                    b.HasIndex("UserId");

                    b.ToTable("CarHireLogs");
                });

            modelBuilder.Entity("Domain.Entities.CarModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CarBrandId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("CarPhoto")
                        .HasColumnType("TEXT");

                    b.Property<int?>("CarPhotoLenght")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("TEXT");

                    b.Property<byte>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<int>("SeatNumber")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("CarBrandId");

                    b.ToTable("CarModels");
                });

            modelBuilder.Entity("Domain.Entities.UserAggregate.RefreshToken", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("ExpiryDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("RefreshTokens");
                });

            modelBuilder.Entity("Domain.Entities.UserAggregate.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("TEXT");

                    b.Property<byte>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnType("varchar(150)");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Domain.Entities.UserAggregate.RoleGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("TEXT");

                    b.Property<byte>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleGroupName")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<int>("UserTypeId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("RoleGroup");
                });

            modelBuilder.Entity("Domain.Entities.UserAggregate.RoleRoleGroup", b =>
                {
                    b.Property<int>("RoleGroupId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("RoleId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("HaveSkillSince")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasDefaultValueSql("(getdate())");

                    b.HasKey("RoleGroupId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("RoleRoleGroup");
                });

            modelBuilder.Entity("Domain.Entities.UserAggregate.RoleUser", b =>
                {
                    b.Property<int>("RolesId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UsersId")
                        .HasColumnType("INTEGER");

                    b.HasKey("RolesId", "UsersId");

                    b.HasIndex("UsersId");

                    b.ToTable("RoleUser");
                });

            modelBuilder.Entity("Domain.Entities.UserAggregate.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AspId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("BranchId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("TEXT");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<byte>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("TEXT");

                    b.Property<string>("RegisterToken")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("RegisterTokenValid")
                        .HasColumnType("TEXT");

                    b.Property<int>("RoleGroupId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserEmail")
                        .IsRequired()
                        .HasColumnType("varchar(250)");

                    b.Property<int>("UserTypeId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("BranchId");

                    b.HasIndex("RoleGroupId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Domain.Entities.WebMenu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ButtonTypeId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("IconName")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<byte>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<string>("LinkName")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("LinkUrl")
                        .IsRequired()
                        .HasColumnType("varchar(150)");

                    b.Property<string>("MainName")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<int>("MenuOrder")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SubName")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("WebMenus");
                });

            modelBuilder.Entity("CarExtraCarHireLog", b =>
                {
                    b.HasOne("Domain.Entities.CarExtra", null)
                        .WithMany()
                        .HasForeignKey("CarExtrasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.CarHireLog", null)
                        .WithMany()
                        .HasForeignKey("CarHiresId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.Car", b =>
                {
                    b.HasOne("Domain.Entities.Branch", "Branch")
                        .WithMany("Cars")
                        .HasForeignKey("BranchId");

                    b.HasOne("Domain.Entities.CarModel", "CarModel")
                        .WithMany()
                        .HasForeignKey("CarModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Branch");

                    b.Navigation("CarModel");
                });

            modelBuilder.Entity("Domain.Entities.CarHireLog", b =>
                {
                    b.HasOne("Domain.Entities.Car", "Car")
                        .WithMany("CarHires")
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Branch", "PickUpBranch")
                        .WithMany("PickUpBranchs")
                        .HasForeignKey("PickUpBranchId")
                        .IsRequired();

                    b.HasOne("Domain.Entities.Branch", "ReturnBranch")
                        .WithMany("ReturnBranchs")
                        .HasForeignKey("ReturnBranchId")
                        .IsRequired();

                    b.HasOne("Domain.Entities.UserAggregate.User", "User")
                        .WithMany("CarHires")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");

                    b.Navigation("PickUpBranch");

                    b.Navigation("ReturnBranch");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Entities.CarModel", b =>
                {
                    b.HasOne("Domain.Entities.CarBrand", "CarBrand")
                        .WithMany("CarModels")
                        .HasForeignKey("CarBrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CarBrand");
                });

            modelBuilder.Entity("Domain.Entities.UserAggregate.RefreshToken", b =>
                {
                    b.HasOne("Domain.Entities.UserAggregate.User", "User")
                        .WithMany("RefreshTokens")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Entities.UserAggregate.RoleRoleGroup", b =>
                {
                    b.HasOne("Domain.Entities.UserAggregate.RoleGroup", "RoleGroup")
                        .WithMany("RoleRoleGroups")
                        .HasForeignKey("RoleGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.UserAggregate.Role", "Role")
                        .WithMany("RoleRoleGroups")
                        .HasForeignKey("RoleId")
                        .IsRequired()
                        .HasConstraintName("FK_RoleRoleGroup_Roles");

                    b.Navigation("Role");

                    b.Navigation("RoleGroup");
                });

            modelBuilder.Entity("Domain.Entities.UserAggregate.RoleUser", b =>
                {
                    b.HasOne("Domain.Entities.UserAggregate.Role", "Roles")
                        .WithMany("RoleUsers")
                        .HasForeignKey("RolesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_RoleUser_Roles_RolesRoleId");

                    b.HasOne("Domain.Entities.UserAggregate.User", "Users")
                        .WithMany("RoleUsers")
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Roles");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("Domain.Entities.UserAggregate.User", b =>
                {
                    b.HasOne("Domain.Entities.Branch", "Branch")
                        .WithMany("Users")
                        .HasForeignKey("BranchId");

                    b.HasOne("Domain.Entities.UserAggregate.RoleGroup", "RoleGroup")
                        .WithMany("Users")
                        .HasForeignKey("RoleGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Branch");

                    b.Navigation("RoleGroup");
                });

            modelBuilder.Entity("Domain.Entities.Branch", b =>
                {
                    b.Navigation("Cars");

                    b.Navigation("PickUpBranchs");

                    b.Navigation("ReturnBranchs");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("Domain.Entities.Car", b =>
                {
                    b.Navigation("CarHires");
                });

            modelBuilder.Entity("Domain.Entities.CarBrand", b =>
                {
                    b.Navigation("CarModels");
                });

            modelBuilder.Entity("Domain.Entities.UserAggregate.Role", b =>
                {
                    b.Navigation("RoleRoleGroups");

                    b.Navigation("RoleUsers");
                });

            modelBuilder.Entity("Domain.Entities.UserAggregate.RoleGroup", b =>
                {
                    b.Navigation("RoleRoleGroups");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("Domain.Entities.UserAggregate.User", b =>
                {
                    b.Navigation("CarHires");

                    b.Navigation("RefreshTokens");

                    b.Navigation("RoleUsers");
                });
#pragma warning restore 612, 618
        }
    }
}
