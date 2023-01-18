using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CursoEntity.Migrations
{
    public partial class CreadaTablaDetalleUsuarioBD : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DetalleUsuario",
                columns: table => new
                {
                    DetalleUsuario_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cedula = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Deporte = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Mascota = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalleUsuario", x => x.DetalleUsuario_ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetalleUsuario");
        }
    }
}
