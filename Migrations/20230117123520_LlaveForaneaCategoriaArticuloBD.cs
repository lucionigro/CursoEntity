using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CursoEntity.Migrations
{
    public partial class LlaveForaneaCategoriaArticuloBD : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TBL_Articulo",
                table: "TBL_Articulo");

            migrationBuilder.RenameTable(
                name: "TBL_Articulo",
                newName: "Articulo");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Categoria",
                newName: "Categoria_Id");

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Articulo",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<int>(
                name: "Categoria_Id",
                table: "Articulo",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Articulo",
                table: "Articulo",
                column: "ArticuloID");

            migrationBuilder.CreateIndex(
                name: "IX_Articulo_Categoria_Id",
                table: "Articulo",
                column: "Categoria_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Articulo_Categoria_Categoria_Id",
                table: "Articulo",
                column: "Categoria_Id",
                principalTable: "Categoria",
                principalColumn: "Categoria_Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articulo_Categoria_Categoria_Id",
                table: "Articulo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Articulo",
                table: "Articulo");

            migrationBuilder.DropIndex(
                name: "IX_Articulo_Categoria_Id",
                table: "Articulo");

            migrationBuilder.DropColumn(
                name: "Categoria_Id",
                table: "Articulo");

            migrationBuilder.RenameTable(
                name: "Articulo",
                newName: "TBL_Articulo");

            migrationBuilder.RenameColumn(
                name: "Categoria_Id",
                table: "Categoria",
                newName: "Id");

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "TBL_Articulo",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TBL_Articulo",
                table: "TBL_Articulo",
                column: "ArticuloID");
        }
    }
}
