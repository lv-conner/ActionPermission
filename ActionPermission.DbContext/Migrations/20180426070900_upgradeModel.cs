using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ActionPermission.Context.Migrations
{
    public partial class upgradeModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActionPermissionUser_ActionPermissionRole_RoleId",
                table: "ActionPermissionUser");

            migrationBuilder.DropIndex(
                name: "IX_ActionPermissionUser_RoleId",
                table: "ActionPermissionUser");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "ActionPermissionUser");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RoleId",
                table: "ActionPermissionUser",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ActionPermissionUser_RoleId",
                table: "ActionPermissionUser",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_ActionPermissionUser_ActionPermissionRole_RoleId",
                table: "ActionPermissionUser",
                column: "RoleId",
                principalTable: "ActionPermissionRole",
                principalColumn: "RoleId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
