using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Server.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemoveAuthorId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blog_User_BlogCreatedById",
                table: "Blog");

            migrationBuilder.DropIndex(
                name: "IX_Blog_BlogCreatedById",
                table: "Blog");

            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "Blog");

            migrationBuilder.DropColumn(
                name: "BlogCreatedById",
                table: "Blog");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Blog",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Blog_CreatedBy",
                table: "Blog",
                column: "CreatedBy");

            migrationBuilder.AddForeignKey(
                name: "FK_Blog_User_CreatedBy",
                table: "Blog",
                column: "CreatedBy",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blog_User_CreatedBy",
                table: "Blog");

            migrationBuilder.DropIndex(
                name: "IX_Blog_CreatedBy",
                table: "Blog");

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Blog",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<Guid>(
                name: "AuthorId",
                table: "Blog",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "BlogCreatedById",
                table: "Blog",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Blog_BlogCreatedById",
                table: "Blog",
                column: "BlogCreatedById");

            migrationBuilder.AddForeignKey(
                name: "FK_Blog_User_BlogCreatedById",
                table: "Blog",
                column: "BlogCreatedById",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
