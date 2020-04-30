using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pizza.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Catalogue_Pizza",
                columns: table => new
                {
                    Num_Pizza = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom_Pizza = table.Column<string>(nullable: true),
                    Taille_Pizza = table.Column<int>(nullable: false),
                    Prix_Pizza = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Catalogue_Pizza", x => x.Num_Pizza);
                });

            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    Num_Cli = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom_Cli = table.Column<string>(nullable: true),
                    Addresse = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.Num_Cli);
                });

            migrationBuilder.CreateTable(
                name: "Quartier",
                columns: table => new
                {
                    Num_Quartier = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom_Quartier = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quartier", x => x.Num_Quartier);
                });

            migrationBuilder.CreateTable(
                name: "Fabrication",
                columns: table => new
                {
                    Num_Fab = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Num_Pizza = table.Column<int>(nullable: false),
                    Quant_Fab = table.Column<int>(nullable: false),
                    Date_Fab = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fabrication", x => x.Num_Fab);
                    table.ForeignKey(
                        name: "FK_Fabrication_Catalogue_Pizza_Num_Pizza",
                        column: x => x.Num_Pizza,
                        principalTable: "Catalogue_Pizza",
                        principalColumn: "Num_Pizza");
                });

            migrationBuilder.CreateTable(
                name: "CdeCli",
                columns: table => new
                {
                    Num_Cde_Cli = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Num_Cli = table.Column<int>(nullable: false),
                    Livre_Emporte = table.Column<bool>(nullable: false),
                    Date_Cde = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CdeCli", x => x.Num_Cde_Cli);
                    table.ForeignKey(
                        name: "FK_CdeCli_Client_Num_Cli",
                        column: x => x.Num_Cli,
                        principalTable: "Client",
                        principalColumn: "Num_Cli");
                });

            migrationBuilder.CreateTable(
                name: "Fact_Cli_BonLiv",
                columns: table => new
                {
                    Num_Fact = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date_Fact_Cli = table.Column<DateTime>(nullable: false),
                    Montant_Total = table.Column<decimal>(nullable: false),
                    Num_Cli = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fact_Cli_BonLiv", x => x.Num_Fact);
                    table.ForeignKey(
                        name: "FK_Fact_Cli_BonLiv_Client_Num_Cli",
                        column: x => x.Num_Cli,
                        principalTable: "Client",
                        principalColumn: "Num_Cli");
                });

            migrationBuilder.CreateTable(
                name: "Adresses",
                columns: table => new
                {
                    Num_Adresse = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adresse = table.Column<string>(nullable: true),
                    Num_Quartier = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adresses", x => x.Num_Adresse);
                    table.ForeignKey(
                        name: "FK_Adresses_Quartier_Num_Quartier",
                        column: x => x.Num_Quartier,
                        principalTable: "Quartier",
                        principalColumn: "Num_Quartier");
                });

            migrationBuilder.CreateTable(
                name: "Livraison",
                columns: table => new
                {
                    Num_Liv = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date_Depart = table.Column<DateTime>(nullable: false),
                    Date_Arrive = table.Column<DateTime>(nullable: false),
                    Num_Quartier = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Livraison", x => x.Num_Liv);
                    table.ForeignKey(
                        name: "FK_Livraison_Quartier_Num_Quartier",
                        column: x => x.Num_Quartier,
                        principalTable: "Quartier",
                        principalColumn: "Num_Quartier");
                });

            migrationBuilder.CreateTable(
                name: "Livreur",
                columns: table => new
                {
                    Num_Liv = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom_Livreur = table.Column<string>(nullable: true),
                    Num_Quartier = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Livreur", x => x.Num_Liv);
                    table.ForeignKey(
                        name: "FK_Livreur_Quartier_Num_Quartier",
                        column: x => x.Num_Quartier,
                        principalTable: "Quartier",
                        principalColumn: "Num_Quartier");
                });

            migrationBuilder.CreateTable(
                name: "Ligne_Cde_Cli",
                columns: table => new
                {
                    Num_Ligne_Cde = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Num_Cde_Cli = table.Column<int>(nullable: false),
                    Num_Pizza = table.Column<int>(nullable: false),
                    Quantite = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ligne_Cde_Cli", x => x.Num_Ligne_Cde);
                    table.ForeignKey(
                        name: "FK_Ligne_Cde_Cli_CdeCli_Num_Cde_Cli",
                        column: x => x.Num_Cde_Cli,
                        principalTable: "CdeCli",
                        principalColumn: "Num_Cde_Cli");
                    table.ForeignKey(
                        name: "FK_Ligne_Cde_Cli_Catalogue_Pizza_Num_Pizza",
                        column: x => x.Num_Pizza,
                        principalTable: "Catalogue_Pizza",
                        principalColumn: "Num_Pizza");
                });

            migrationBuilder.CreateTable(
                name: "BonLiv",
                columns: table => new
                {
                    Num_Bon_Liv = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Num_Cde_Cli = table.Column<int>(nullable: false),
                    Date_Liv = table.Column<DateTime>(nullable: false),
                    Num_Fact = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BonLiv", x => x.Num_Bon_Liv);
                    table.ForeignKey(
                        name: "FK_BonLiv_CdeCli_Num_Cde_Cli",
                        column: x => x.Num_Cde_Cli,
                        principalTable: "CdeCli",
                        principalColumn: "Num_Cde_Cli");
                    table.ForeignKey(
                        name: "FK_BonLiv_Fact_Cli_BonLiv_Num_Fact",
                        column: x => x.Num_Fact,
                        principalTable: "Fact_Cli_BonLiv",
                        principalColumn: "Num_Fact");
                });

            migrationBuilder.CreateTable(
                name: "Paiement_Cli",
                columns: table => new
                {
                    Num_Piece_Compt = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Num_Fact = table.Column<int>(nullable: false),
                    Date_Paiement = table.Column<DateTime>(nullable: false),
                    Montant_Paiement = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paiement_Cli", x => x.Num_Piece_Compt);
                    table.ForeignKey(
                        name: "FK_Paiement_Cli_Fact_Cli_BonLiv_Num_Fact",
                        column: x => x.Num_Fact,
                        principalTable: "Fact_Cli_BonLiv",
                        principalColumn: "Num_Fact");
                });

            migrationBuilder.CreateTable(
                name: "Detail_Liv",
                columns: table => new
                {
                    Num_Detail_Bon_Liv = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Num_Bon_Liv = table.Column<int>(nullable: false),
                    Num_Liv = table.Column<int>(nullable: false),
                    Num_Quartier = table.Column<int>(nullable: false),
                    Addresse_Liv = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Detail_Liv", x => x.Num_Detail_Bon_Liv);
                    table.ForeignKey(
                        name: "FK_Detail_Liv_BonLiv_Num_Bon_Liv",
                        column: x => x.Num_Bon_Liv,
                        principalTable: "BonLiv",
                        principalColumn: "Num_Bon_Liv");
                    table.ForeignKey(
                        name: "FK_Detail_Liv_Livraison_Num_Liv",
                        column: x => x.Num_Liv,
                        principalTable: "Livraison",
                        principalColumn: "Num_Liv");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Adresses_Num_Quartier",
                table: "Adresses",
                column: "Num_Quartier");

            migrationBuilder.CreateIndex(
                name: "IX_BonLiv_Num_Cde_Cli",
                table: "BonLiv",
                column: "Num_Cde_Cli");

            migrationBuilder.CreateIndex(
                name: "IX_BonLiv_Num_Fact",
                table: "BonLiv",
                column: "Num_Fact");

            migrationBuilder.CreateIndex(
                name: "IX_CdeCli_Num_Cli",
                table: "CdeCli",
                column: "Num_Cli");

            migrationBuilder.CreateIndex(
                name: "IX_Detail_Liv_Num_Bon_Liv",
                table: "Detail_Liv",
                column: "Num_Bon_Liv");

            migrationBuilder.CreateIndex(
                name: "IX_Detail_Liv_Num_Liv",
                table: "Detail_Liv",
                column: "Num_Liv");

            migrationBuilder.CreateIndex(
                name: "IX_Fabrication_Num_Pizza",
                table: "Fabrication",
                column: "Num_Pizza");

            migrationBuilder.CreateIndex(
                name: "IX_Fact_Cli_BonLiv_Num_Cli",
                table: "Fact_Cli_BonLiv",
                column: "Num_Cli");

            migrationBuilder.CreateIndex(
                name: "IX_Ligne_Cde_Cli_Num_Cde_Cli",
                table: "Ligne_Cde_Cli",
                column: "Num_Cde_Cli");

            migrationBuilder.CreateIndex(
                name: "IX_Ligne_Cde_Cli_Num_Pizza",
                table: "Ligne_Cde_Cli",
                column: "Num_Pizza");

            migrationBuilder.CreateIndex(
                name: "IX_Livraison_Num_Quartier",
                table: "Livraison",
                column: "Num_Quartier");

            migrationBuilder.CreateIndex(
                name: "IX_Livreur_Num_Quartier",
                table: "Livreur",
                column: "Num_Quartier");

            migrationBuilder.CreateIndex(
                name: "IX_Paiement_Cli_Num_Fact",
                table: "Paiement_Cli",
                column: "Num_Fact");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Adresses");

            migrationBuilder.DropTable(
                name: "Detail_Liv");

            migrationBuilder.DropTable(
                name: "Fabrication");

            migrationBuilder.DropTable(
                name: "Ligne_Cde_Cli");

            migrationBuilder.DropTable(
                name: "Livreur");

            migrationBuilder.DropTable(
                name: "Paiement_Cli");

            migrationBuilder.DropTable(
                name: "BonLiv");

            migrationBuilder.DropTable(
                name: "Livraison");

            migrationBuilder.DropTable(
                name: "Catalogue_Pizza");

            migrationBuilder.DropTable(
                name: "CdeCli");

            migrationBuilder.DropTable(
                name: "Fact_Cli_BonLiv");

            migrationBuilder.DropTable(
                name: "Quartier");

            migrationBuilder.DropTable(
                name: "Client");
        }
    }
}
