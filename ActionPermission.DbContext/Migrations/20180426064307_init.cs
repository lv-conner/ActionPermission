using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ActionPermission.Context.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ActionPermissionRole",
                columns: table => new
                {
                    RoleId = table.Column<string>(maxLength: 50, nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: true),
                    RoleName = table.Column<string>(nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActionPermissionRole", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "ActionPermissonModel",
                columns: table => new
                {
                    ActionPermissionId = table.Column<string>(maxLength: 50, nullable: false),
                    ActionName = table.Column<string>(maxLength: 50, nullable: true),
                    ActionNo = table.Column<string>(maxLength: 50, nullable: true),
                    ModuleName = table.Column<string>(maxLength: 50, nullable: true),
                    ModuleNo = table.Column<string>(maxLength: 50, nullable: true),
                    SystemName = table.Column<string>(maxLength: 50, nullable: true),
                    SystemNo = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActionPermissonModel", x => x.ActionPermissionId);
                });

            migrationBuilder.CreateTable(
                name: "ActionPermissionUser",
                columns: table => new
                {
                    UserId = table.Column<string>(maxLength: 50, nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: true),
                    Email = table.Column<string>(maxLength: 50, nullable: true),
                    Password = table.Column<string>(maxLength: 200, nullable: true),
                    PhoneNumber = table.Column<string>(maxLength: 20, nullable: true),
                    RoleId = table.Column<string>(nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    UserName = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActionPermissionUser", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_ActionPermissionUser_ActionPermissionRole_RoleId",
                        column: x => x.RoleId,
                        principalTable: "ActionPermissionRole",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RolePermission",
                columns: table => new
                {
                    RolePermissonId = table.Column<string>(maxLength: 50, nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: true),
                    CreateUserId = table.Column<string>(nullable: true),
                    IsEnable = table.Column<bool>(nullable: false),
                    PermissionId = table.Column<string>(nullable: true),
                    RoleId = table.Column<string>(nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolePermission", x => x.RolePermissonId);
                    table.ForeignKey(
                        name: "FK_RolePermission_ActionPermissonModel_PermissionId",
                        column: x => x.PermissionId,
                        principalTable: "ActionPermissonModel",
                        principalColumn: "ActionPermissionId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RolePermission_ActionPermissionRole_RoleId",
                        column: x => x.RoleId,
                        principalTable: "ActionPermissionRole",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoleUser",
                columns: table => new
                {
                    RoleUserId = table.Column<string>(maxLength: 50, nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: true),
                    RoleId = table.Column<string>(nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleUser", x => x.RoleUserId);
                    table.ForeignKey(
                        name: "FK_RoleUser_ActionPermissionRole_RoleId",
                        column: x => x.RoleId,
                        principalTable: "ActionPermissionRole",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoleUser_ActionPermissionUser_UserId",
                        column: x => x.UserId,
                        principalTable: "ActionPermissionUser",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserPermission",
                columns: table => new
                {
                    UserPermissionId = table.Column<string>(maxLength: 50, nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: true),
                    IsEnable = table.Column<bool>(nullable: false),
                    PermissionId = table.Column<string>(nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPermission", x => x.UserPermissionId);
                    table.ForeignKey(
                        name: "FK_UserPermission_ActionPermissonModel_PermissionId",
                        column: x => x.PermissionId,
                        principalTable: "ActionPermissonModel",
                        principalColumn: "ActionPermissionId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserPermission_ActionPermissionUser_UserId",
                        column: x => x.UserId,
                        principalTable: "ActionPermissionUser",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActionPermissionUser_RoleId",
                table: "ActionPermissionUser",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_RolePermission_PermissionId",
                table: "RolePermission",
                column: "PermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_RolePermission_RoleId",
                table: "RolePermission",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleUser_RoleId",
                table: "RoleUser",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleUser_UserId",
                table: "RoleUser",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPermission_PermissionId",
                table: "UserPermission",
                column: "PermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPermission_UserId",
                table: "UserPermission",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RolePermission");

            migrationBuilder.DropTable(
                name: "RoleUser");

            migrationBuilder.DropTable(
                name: "UserPermission");

            migrationBuilder.DropTable(
                name: "ActionPermissonModel");

            migrationBuilder.DropTable(
                name: "ActionPermissionUser");

            migrationBuilder.DropTable(
                name: "ActionPermissionRole");
        }
    }
}
