using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SiteHairStylist.Migrations
{
    /// <inheritdoc />
    public partial class orice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Programari_Users_UtilizatorUserID",
                table: "Programari");

            migrationBuilder.DropForeignKey(
                name: "FK_Recenzii_Users_UtilizatorUserID",
                table: "Recenzii");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Recenzii_UtilizatorUserID",
                table: "Recenzii");

            migrationBuilder.DropIndex(
                name: "IX_Programari_UtilizatorUserID",
                table: "Programari");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Recenzii");

            migrationBuilder.DropColumn(
                name: "UtilizatorUserID",
                table: "Recenzii");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Programari");

            migrationBuilder.DropColumn(
                name: "UtilizatorUserID",
                table: "Programari");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "Recenzii",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UtilizatorUserID",
                table: "Recenzii",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "Programari",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UtilizatorUserID",
                table: "Programari",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumeUtilizator = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Parola = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Recenzii_UtilizatorUserID",
                table: "Recenzii",
                column: "UtilizatorUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Programari_UtilizatorUserID",
                table: "Programari",
                column: "UtilizatorUserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Programari_Users_UtilizatorUserID",
                table: "Programari",
                column: "UtilizatorUserID",
                principalTable: "Users",
                principalColumn: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Recenzii_Users_UtilizatorUserID",
                table: "Recenzii",
                column: "UtilizatorUserID",
                principalTable: "Users",
                principalColumn: "UserID");
        }
    }
}
