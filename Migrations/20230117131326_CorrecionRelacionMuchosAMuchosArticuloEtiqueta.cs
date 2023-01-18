using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CursoEntity.Migrations
{
    public partial class CorrecionRelacionMuchosAMuchosArticuloEtiqueta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ArticuloEtiqueta",
                columns: table => new
                {
                    ArticuloID = table.Column<int>(type: "int", nullable: false),
                    Etiqueta_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticuloEtiqueta", x => new { x.Etiqueta_ID, x.ArticuloID });
                    table.ForeignKey(
                        name: "FK_ArticuloEtiqueta_Articulo_ArticuloID",
                        column: x => x.ArticuloID,
                        principalTable: "Articulo",
                        principalColumn: "ArticuloID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArticuloEtiqueta_Etiqueta_Etiqueta_ID",
                        column: x => x.Etiqueta_ID,
                        principalTable: "Etiqueta",
                        principalColumn: "Etiqueta_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArticuloEtiqueta_ArticuloID",
                table: "ArticuloEtiqueta",
                column: "ArticuloID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArticuloEtiqueta");
        }
    }
}
