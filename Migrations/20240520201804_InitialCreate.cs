using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SiteHairStylist.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Inregistrare",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mobile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inregistrare", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProgramDeLucru",
                columns: table => new
                {
                    WorkScheduleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ZiuaSaptamanii = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OraDeschidere = table.Column<TimeSpan>(type: "time", nullable: false),
                    OraInchidere = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgramDeLucru", x => x.WorkScheduleID);
                });

            migrationBuilder.CreateTable(
                name: "Servicii",
                columns: table => new
                {
                    ServiceID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nume = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descriere = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Durata = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servicii", x => x.ServiceID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeUtilizator = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Parola = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "Pret",
                columns: table => new
                {
                    PriceID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceID = table.Column<int>(type: "int", nullable: true),
                    Suma = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ServiciuServiceID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pret", x => x.PriceID);
                    table.ForeignKey(
                        name: "FK_Pret_Servicii_ServiciuServiceID",
                        column: x => x.ServiciuServiceID,
                        principalTable: "Servicii",
                        principalColumn: "ServiceID");
                });

            migrationBuilder.CreateTable(
                name: "Programari",
                columns: table => new
                {
                    AppointmentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: true),
                    UtilizatorUserID = table.Column<int>(type: "int", nullable: true),
                    ServiceID = table.Column<int>(type: "int", nullable: true),
                    ServiciuServiceID = table.Column<int>(type: "int", nullable: true),
                    DataOraProgramarii = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Stare = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Programari", x => x.AppointmentID);
                    table.ForeignKey(
                        name: "FK_Programari_Servicii_ServiciuServiceID",
                        column: x => x.ServiciuServiceID,
                        principalTable: "Servicii",
                        principalColumn: "ServiceID");
                    table.ForeignKey(
                        name: "FK_Programari_Users_UtilizatorUserID",
                        column: x => x.UtilizatorUserID,
                        principalTable: "Users",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "Recenzii",
                columns: table => new
                {
                    ReviewID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: true),
                    UtilizatorUserID = table.Column<int>(type: "int", nullable: true),
                    ServiceID = table.Column<int>(type: "int", nullable: true),
                    ServiciuServiceID = table.Column<int>(type: "int", nullable: true),
                    Evaluare = table.Column<int>(type: "int", nullable: false),
                    Comentariu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataPostarii = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recenzii", x => x.ReviewID);
                    table.ForeignKey(
                        name: "FK_Recenzii_Servicii_ServiciuServiceID",
                        column: x => x.ServiciuServiceID,
                        principalTable: "Servicii",
                        principalColumn: "ServiceID");
                    table.ForeignKey(
                        name: "FK_Recenzii_Users_UtilizatorUserID",
                        column: x => x.UtilizatorUserID,
                        principalTable: "Users",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pret_ServiciuServiceID",
                table: "Pret",
                column: "ServiciuServiceID");

            migrationBuilder.CreateIndex(
                name: "IX_Programari_ServiciuServiceID",
                table: "Programari",
                column: "ServiciuServiceID");

            migrationBuilder.CreateIndex(
                name: "IX_Programari_UtilizatorUserID",
                table: "Programari",
                column: "UtilizatorUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Recenzii_ServiciuServiceID",
                table: "Recenzii",
                column: "ServiciuServiceID");

            migrationBuilder.CreateIndex(
                name: "IX_Recenzii_UtilizatorUserID",
                table: "Recenzii",
                column: "UtilizatorUserID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Inregistrare");

            migrationBuilder.DropTable(
                name: "Pret");

            migrationBuilder.DropTable(
                name: "Programari");

            migrationBuilder.DropTable(
                name: "ProgramDeLucru");

            migrationBuilder.DropTable(
                name: "Recenzii");

            migrationBuilder.DropTable(
                name: "Servicii");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
