using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Belu_Ioana_Web.Migrations
{
    public partial class CategorieAliment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorie",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorie", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CategorieAliment",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JurnalID = table.Column<int>(type: "int", nullable: false),
                    CategorieID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategorieAliment", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CategorieAliment_Categorie_CategorieID",
                        column: x => x.CategorieID,
                        principalTable: "Categorie",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategorieAliment_Jurnal_JurnalID",
                        column: x => x.JurnalID,
                        principalTable: "Jurnal",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategorieAliment_CategorieID",
                table: "CategorieAliment",
                column: "CategorieID");

            migrationBuilder.CreateIndex(
                name: "IX_CategorieAliment_JurnalID",
                table: "CategorieAliment",
                column: "JurnalID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategorieAliment");

            migrationBuilder.DropTable(
                name: "Categorie");
        }
    }
}
