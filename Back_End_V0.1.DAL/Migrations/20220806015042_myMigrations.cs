using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackEnd.Api.DAL.Migrations
{
    public partial class myMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    id_admin = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    log = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    pass = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.id_admin);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    id_client = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.id_client);
                });

            migrationBuilder.CreateTable(
                name: "Voitures",
                columns: table => new
                {
                    Id_Voiture = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    matricule = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    modele = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    carburant = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Voitures", x => x.Id_Voiture);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    Id_Reservation = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    date_reservation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    voitureId_Voiture = table.Column<int>(type: "int", nullable: false),
                    clientid_client = table.Column<int>(type: "int", nullable: false),
                    montant = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.Id_Reservation);
                    table.ForeignKey(
                        name: "FK_Reservations_Clients_clientid_client",
                        column: x => x.clientid_client,
                        principalTable: "Clients",
                        principalColumn: "id_client",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservations_Voitures_voitureId_Voiture",
                        column: x => x.voitureId_Voiture,
                        principalTable: "Voitures",
                        principalColumn: "Id_Voiture",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Recus",
                columns: table => new
                {
                    Id_recu = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    reservationId_Reservation = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recus", x => x.Id_recu);
                    table.ForeignKey(
                        name: "FK_Recus_Reservations_reservationId_Reservation",
                        column: x => x.reservationId_Reservation,
                        principalTable: "Reservations",
                        principalColumn: "Id_Reservation",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Recus_reservationId_Reservation",
                table: "Recus",
                column: "reservationId_Reservation");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_clientid_client",
                table: "Reservations",
                column: "clientid_client");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_voitureId_Voiture",
                table: "Reservations",
                column: "voitureId_Voiture");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "Recus");

            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Voitures");
        }
    }
}
