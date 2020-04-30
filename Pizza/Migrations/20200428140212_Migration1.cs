using Microsoft.EntityFrameworkCore.Migrations;

namespace Pizza.Migrations
{
    public partial class Migration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Livreur_Num_Quartier",
                table: "Livreur");

            migrationBuilder.CreateIndex(
                name: "IX_Livreur_Num_Quartier",
                table: "Livreur",
                column: "Num_Quartier",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Livreur_Num_Quartier",
                table: "Livreur");

            migrationBuilder.CreateIndex(
                name: "IX_Livreur_Num_Quartier",
                table: "Livreur",
                column: "Num_Quartier");
        }
    }
}
