using Microsoft.EntityFrameworkCore.Migrations;

namespace CleanArch.Infra.Data.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Category_Category_ParentId",
                table: "Category");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoryTranslation_Category_CategoryId",
                table: "CategoryTranslation");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoryTranslation_Languages_LanguageId",
                table: "CategoryTranslation");

            migrationBuilder.DropForeignKey(
                name: "FK_PermissionRole_Permissions_PermissionId",
                table: "PermissionRole");

            migrationBuilder.DropForeignKey(
                name: "FK_PermissionRole_AspNetRoles_RoleId",
                table: "PermissionRole");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Category_CategoryId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PermissionRole",
                table: "PermissionRole");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CategoryTranslation",
                table: "CategoryTranslation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Category",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "PictureUri",
                table: "Products");

            migrationBuilder.RenameTable(
                name: "PermissionRole",
                newName: "PermissionRoles");

            migrationBuilder.RenameTable(
                name: "CategoryTranslation",
                newName: "CategoryTranslations");

            migrationBuilder.RenameTable(
                name: "Category",
                newName: "Categories");

            migrationBuilder.RenameIndex(
                name: "IX_PermissionRole_RoleId",
                table: "PermissionRoles",
                newName: "IX_PermissionRoles_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_PermissionRole_PermissionId",
                table: "PermissionRoles",
                newName: "IX_PermissionRoles_PermissionId");

            migrationBuilder.RenameIndex(
                name: "IX_CategoryTranslation_PropertyValue",
                table: "CategoryTranslations",
                newName: "IX_CategoryTranslations_PropertyValue");

            migrationBuilder.RenameIndex(
                name: "IX_CategoryTranslation_PropertyKey",
                table: "CategoryTranslations",
                newName: "IX_CategoryTranslations_PropertyKey");

            migrationBuilder.RenameIndex(
                name: "IX_CategoryTranslation_LanguageId",
                table: "CategoryTranslations",
                newName: "IX_CategoryTranslations_LanguageId");

            migrationBuilder.RenameIndex(
                name: "IX_CategoryTranslation_CategoryId",
                table: "CategoryTranslations",
                newName: "IX_CategoryTranslations_CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Category_ParentId",
                table: "Categories",
                newName: "IX_Categories_ParentId");

            migrationBuilder.RenameIndex(
                name: "IX_Category_Name",
                table: "Categories",
                newName: "IX_Categories_Name");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PermissionRoles",
                table: "PermissionRoles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CategoryTranslations",
                table: "CategoryTranslations",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                table: "Categories",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Categories_ParentId",
                table: "Categories",
                column: "ParentId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryTranslations_Categories_CategoryId",
                table: "CategoryTranslations",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryTranslations_Languages_LanguageId",
                table: "CategoryTranslations",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PermissionRoles_Permissions_PermissionId",
                table: "PermissionRoles",
                column: "PermissionId",
                principalTable: "Permissions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PermissionRoles_AspNetRoles_RoleId",
                table: "PermissionRoles",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Categories_ParentId",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoryTranslations_Categories_CategoryId",
                table: "CategoryTranslations");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoryTranslations_Languages_LanguageId",
                table: "CategoryTranslations");

            migrationBuilder.DropForeignKey(
                name: "FK_PermissionRoles_Permissions_PermissionId",
                table: "PermissionRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_PermissionRoles_AspNetRoles_RoleId",
                table: "PermissionRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PermissionRoles",
                table: "PermissionRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CategoryTranslations",
                table: "CategoryTranslations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                table: "Categories");

            migrationBuilder.RenameTable(
                name: "PermissionRoles",
                newName: "PermissionRole");

            migrationBuilder.RenameTable(
                name: "CategoryTranslations",
                newName: "CategoryTranslation");

            migrationBuilder.RenameTable(
                name: "Categories",
                newName: "Category");

            migrationBuilder.RenameIndex(
                name: "IX_PermissionRoles_RoleId",
                table: "PermissionRole",
                newName: "IX_PermissionRole_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_PermissionRoles_PermissionId",
                table: "PermissionRole",
                newName: "IX_PermissionRole_PermissionId");

            migrationBuilder.RenameIndex(
                name: "IX_CategoryTranslations_PropertyValue",
                table: "CategoryTranslation",
                newName: "IX_CategoryTranslation_PropertyValue");

            migrationBuilder.RenameIndex(
                name: "IX_CategoryTranslations_PropertyKey",
                table: "CategoryTranslation",
                newName: "IX_CategoryTranslation_PropertyKey");

            migrationBuilder.RenameIndex(
                name: "IX_CategoryTranslations_LanguageId",
                table: "CategoryTranslation",
                newName: "IX_CategoryTranslation_LanguageId");

            migrationBuilder.RenameIndex(
                name: "IX_CategoryTranslations_CategoryId",
                table: "CategoryTranslation",
                newName: "IX_CategoryTranslation_CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Categories_ParentId",
                table: "Category",
                newName: "IX_Category_ParentId");

            migrationBuilder.RenameIndex(
                name: "IX_Categories_Name",
                table: "Category",
                newName: "IX_Category_Name");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PictureUri",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PermissionRole",
                table: "PermissionRole",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CategoryTranslation",
                table: "CategoryTranslation",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Category",
                table: "Category",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Category_Category_ParentId",
                table: "Category",
                column: "ParentId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryTranslation_Category_CategoryId",
                table: "CategoryTranslation",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryTranslation_Languages_LanguageId",
                table: "CategoryTranslation",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PermissionRole_Permissions_PermissionId",
                table: "PermissionRole",
                column: "PermissionId",
                principalTable: "Permissions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PermissionRole_AspNetRoles_RoleId",
                table: "PermissionRole",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Category_CategoryId",
                table: "Products",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
