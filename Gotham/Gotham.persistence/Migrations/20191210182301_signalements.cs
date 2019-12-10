using Microsoft.EntityFrameworkCore.Migrations;

namespace Gotham.persistence.Migrations
{
    public partial class signalements : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Alerte",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nature = table.Column<string>(nullable: true),
                    Secteur = table.Column<string>(nullable: true),
                    Risque = table.Column<string>(nullable: true),
                    Ressource = table.Column<string>(nullable: true),
                    Conseil = table.Column<string>(nullable: true),
                    Publié = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alerte", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alerte");
        }
    }
}
