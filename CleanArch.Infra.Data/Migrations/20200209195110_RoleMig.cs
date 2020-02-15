using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CleanArch.Infra.Data.Migrations
{
    public partial class RoleMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetRoles_Permissions_PermissionId",
                table: "AspNetRoles");

            migrationBuilder.DropIndex(
                name: "IX_AspNetRoles_PermissionId",
                table: "AspNetRoles");

            migrationBuilder.DropColumn(
                name: "Photo",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PermissionId",
                table: "AspNetRoles");

            migrationBuilder.AlterColumn<string>(
                name: "Surname",
                table: "AspNetUsers",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUsers",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "PictureUri",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "AspNetRoles",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PermissionRole",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDt = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    UpdatedDt = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    PermissionId = table.Column<long>(nullable: false),
                    RoleId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissionRole", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PermissionRole_Permissions_PermissionId",
                        column: x => x.PermissionId,
                        principalTable: "Permissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PermissionRole_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_Name",
                table: "AspNetUsers",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_Surname",
                table: "AspNetUsers",
                column: "Surname");

            migrationBuilder.CreateIndex(
                name: "IX_PermissionRole_PermissionId",
                table: "PermissionRole",
                column: "PermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_PermissionRole_RoleId",
                table: "PermissionRole",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PermissionRole");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_Name",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_Surname",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PictureUri",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "AspNetRoles");

            migrationBuilder.AlterColumn<string>(
                name: "Surname",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AddColumn<string>(
                name: "Photo",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "PermissionId",
                table: "AspNetRoles",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoles_PermissionId",
                table: "AspNetRoles",
                column: "PermissionId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetRoles_Permissions_PermissionId",
                table: "AspNetRoles",
                column: "PermissionId",
                principalTable: "Permissions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
