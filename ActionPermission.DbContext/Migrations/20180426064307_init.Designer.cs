﻿// <auto-generated />
using ActionPermission.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace ActionPermission.Context.Migrations
{
    [DbContext(typeof(ActionPermissionContext))]
    [Migration("20180426064307_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ActionPermission.Domain.ActionPermissionRole", b =>
                {
                    b.Property<string>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50);

                    b.Property<DateTime?>("CreateDate");

                    b.Property<string>("RoleName");

                    b.Property<DateTime?>("UpdateDate");

                    b.HasKey("RoleId");

                    b.ToTable("ActionPermissionRole");
                });

            modelBuilder.Entity("ActionPermission.Domain.ActionPermissionUser", b =>
                {
                    b.Property<string>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50);

                    b.Property<DateTime?>("CreateDate");

                    b.Property<string>("Email")
                        .HasMaxLength(50);

                    b.Property<string>("Password")
                        .HasMaxLength(200);

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(20);

                    b.Property<string>("RoleId");

                    b.Property<DateTime?>("UpdateDate");

                    b.Property<string>("UserName")
                        .HasMaxLength(50)
                        .IsUnicode(true);

                    b.HasKey("UserId");

                    b.HasIndex("RoleId");

                    b.ToTable("ActionPermissionUser");
                });

            modelBuilder.Entity("ActionPermission.Domain.ActionPermissonModel", b =>
                {
                    b.Property<string>("ActionPermissionId")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50);

                    b.Property<string>("ActionName")
                        .HasMaxLength(50);

                    b.Property<string>("ActionNo")
                        .HasMaxLength(50);

                    b.Property<string>("ModuleName")
                        .HasMaxLength(50);

                    b.Property<string>("ModuleNo")
                        .HasMaxLength(50);

                    b.Property<string>("SystemName")
                        .HasMaxLength(50);

                    b.Property<string>("SystemNo")
                        .HasMaxLength(50);

                    b.HasKey("ActionPermissionId");

                    b.ToTable("ActionPermissonModel");
                });

            modelBuilder.Entity("ActionPermission.Domain.RolePermission", b =>
                {
                    b.Property<string>("RolePermissonId")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50);

                    b.Property<DateTime?>("CreateDate");

                    b.Property<string>("CreateUserId");

                    b.Property<bool>("IsEnable");

                    b.Property<string>("PermissionId");

                    b.Property<string>("RoleId");

                    b.Property<DateTime?>("UpdateDate");

                    b.HasKey("RolePermissonId");

                    b.HasIndex("PermissionId");

                    b.HasIndex("RoleId");

                    b.ToTable("RolePermission");
                });

            modelBuilder.Entity("ActionPermission.Domain.RoleUser", b =>
                {
                    b.Property<string>("RoleUserId")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50);

                    b.Property<DateTime?>("CreateDate");

                    b.Property<string>("RoleId");

                    b.Property<DateTime?>("UpdateDate");

                    b.Property<string>("UserId");

                    b.HasKey("RoleUserId");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("RoleUser");
                });

            modelBuilder.Entity("ActionPermission.Domain.UserPermission", b =>
                {
                    b.Property<string>("UserPermissionId")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50);

                    b.Property<DateTime?>("CreateDate");

                    b.Property<bool>("IsEnable");

                    b.Property<string>("PermissionId");

                    b.Property<DateTime?>("UpdateDate");

                    b.Property<string>("UserId");

                    b.HasKey("UserPermissionId");

                    b.HasIndex("PermissionId");

                    b.HasIndex("UserId");

                    b.ToTable("UserPermission");
                });

            modelBuilder.Entity("ActionPermission.Domain.ActionPermissionUser", b =>
                {
                    b.HasOne("ActionPermission.Domain.ActionPermissionRole", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId");
                });

            modelBuilder.Entity("ActionPermission.Domain.RolePermission", b =>
                {
                    b.HasOne("ActionPermission.Domain.ActionPermissonModel", "Permission")
                        .WithMany("Roles")
                        .HasForeignKey("PermissionId");

                    b.HasOne("ActionPermission.Domain.ActionPermissionRole", "Role")
                        .WithMany("Rules")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ActionPermission.Domain.RoleUser", b =>
                {
                    b.HasOne("ActionPermission.Domain.ActionPermissionRole", "Role")
                        .WithMany("Members")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ActionPermission.Domain.ActionPermissionUser", "User")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ActionPermission.Domain.UserPermission", b =>
                {
                    b.HasOne("ActionPermission.Domain.ActionPermissonModel", "Permission")
                        .WithMany("Users")
                        .HasForeignKey("PermissionId");

                    b.HasOne("ActionPermission.Domain.ActionPermissionUser", "User")
                        .WithMany("Permissions")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
