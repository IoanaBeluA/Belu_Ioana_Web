using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Belu_Ioana_Web.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Jurnal",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Zi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Aliment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Calorii = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jurnal", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Jurnal");
        }
    }
}
