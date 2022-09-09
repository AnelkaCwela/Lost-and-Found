using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LostNelsonFound.Migrations
{
    public partial class s : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Foundx_Categoryx_CategoryId",
                table: "Foundx");

            migrationBuilder.DropIndex(
                name: "IX_Foundx_CategoryId",
                table: "Foundx");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Foundx");

            migrationBuilder.CreateIndex(
                name: "IX_Foundx_CategoryLostId",
                table: "Foundx",
                column: "CategoryLostId");

            migrationBuilder.AddForeignKey(
                name: "FK_Foundx_Categoryx_CategoryLostId",
                table: "Foundx",
                column: "CategoryLostId",
                principalTable: "Categoryx",
                principalColumn: "CategoryLostId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Foundx_Categoryx_CategoryLostId",
                table: "Foundx");

            migrationBuilder.DropIndex(
                name: "IX_Foundx_CategoryLostId",
                table: "Foundx");

            migrationBuilder.AddColumn<Guid>(
                name: "CategoryId",
                table: "Foundx",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Foundx_CategoryId",
                table: "Foundx",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Foundx_Categoryx_CategoryId",
                table: "Foundx",
                column: "CategoryId",
                principalTable: "Categoryx",
                principalColumn: "CategoryLostId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
