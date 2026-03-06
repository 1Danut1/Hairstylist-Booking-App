using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SiteHairStylist.Migrations
{
    /// <inheritdoc />
    public partial class AddUserIdProgramari : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Programari",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Programari_UserId",
                table: "Programari",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Programari_AspNetUsers_UserId",
                table: "Programari",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Programari_AspNetUsers_UserId",
                table: "Programari");

            migrationBuilder.DropIndex(
                name: "IX_Programari_UserId",
                table: "Programari");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Programari");
        }
    }
}
