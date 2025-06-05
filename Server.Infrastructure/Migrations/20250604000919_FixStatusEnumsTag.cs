using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Server.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixStatusEnumsTag : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Tag",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Tag_CreatedBy",
                table: "Tag",
                column: "CreatedBy");

            migrationBuilder.AddForeignKey(
                name: "FK_Tag_User_CreatedBy",
                table: "Tag",
                column: "CreatedBy",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tag_User_CreatedBy",
                table: "Tag");

            migrationBuilder.DropIndex(
                name: "IX_Tag_CreatedBy",
                table: "Tag");

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Tag",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
