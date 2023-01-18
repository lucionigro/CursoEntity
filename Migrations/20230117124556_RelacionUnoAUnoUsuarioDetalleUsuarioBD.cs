using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CursoEntity.Migrations
{
    public partial class RelacionUnoAUnoUsuarioDetalleUsuarioBD : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DetalleUsuario_ID",
                table: "Usuario",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_DetalleUsuario_ID",
                table: "Usuario",
                column: "DetalleUsuario_ID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_DetalleUsuario_DetalleUsuario_ID",
                table: "Usuario",
                column: "DetalleUsuario_ID",
                principalTable: "DetalleUsuario",
                principalColumn: "DetalleUsuario_ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_DetalleUsuario_DetalleUsuario_ID",
                table: "Usuario");

            migrationBuilder.DropIndex(
                name: "IX_Usuario_DetalleUsuario_ID",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "DetalleUsuario_ID",
                table: "Usuario");
        }
    }
}
