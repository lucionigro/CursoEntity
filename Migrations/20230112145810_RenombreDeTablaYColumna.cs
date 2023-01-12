using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CursoEntity.Migrations
{
    public partial class RenombreDeTablaYColumna : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Articulo",
                table: "Articulo");

            migrationBuilder.RenameTable(
                name: "Articulo",
                newName: "TBL_Articulo");

            migrationBuilder.RenameColumn(
                name: "TituloArticulo",
                table: "TBL_Articulo",
                newName: "Titulo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TBL_Articulo",
                table: "TBL_Articulo",
                column: "ArticuloID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TBL_Articulo",
                table: "TBL_Articulo");

            migrationBuilder.RenameTable(
                name: "TBL_Articulo",
                newName: "Articulo");

            migrationBuilder.RenameColumn(
                name: "Titulo",
                table: "Articulo",
                newName: "TituloArticulo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Articulo",
                table: "Articulo",
                column: "ArticuloID");
        }
    }
}
