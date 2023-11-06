using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionAcademica.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AsignaturasDocente_AsignaturasCarrera_AsignaturaCarreraId",
                table: "AsignaturasDocente");

            migrationBuilder.DropForeignKey(
                name: "FK_AsignaturasDocente_Asignaturas_AsignaturaId",
                table: "AsignaturasDocente");

            migrationBuilder.DropIndex(
                name: "IX_AsignaturasDocente_AsignaturaCarreraId",
                table: "AsignaturasDocente");

            migrationBuilder.DropColumn(
                name: "AsignaturaCarreraId",
                table: "AsignaturasDocente");

            migrationBuilder.AlterColumn<int>(
                name: "AsignaturaId",
                table: "AsignaturasDocente",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AsignaturasDocente_Asignaturas_AsignaturaId",
                table: "AsignaturasDocente",
                column: "AsignaturaId",
                principalTable: "Asignaturas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AsignaturasDocente_Asignaturas_AsignaturaId",
                table: "AsignaturasDocente");

            migrationBuilder.AlterColumn<int>(
                name: "AsignaturaId",
                table: "AsignaturasDocente",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "AsignaturaCarreraId",
                table: "AsignaturasDocente",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_AsignaturasDocente_AsignaturaCarreraId",
                table: "AsignaturasDocente",
                column: "AsignaturaCarreraId");

            migrationBuilder.AddForeignKey(
                name: "FK_AsignaturasDocente_AsignaturasCarrera_AsignaturaCarreraId",
                table: "AsignaturasDocente",
                column: "AsignaturaCarreraId",
                principalTable: "AsignaturasCarrera",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AsignaturasDocente_Asignaturas_AsignaturaId",
                table: "AsignaturasDocente",
                column: "AsignaturaId",
                principalTable: "Asignaturas",
                principalColumn: "Id");
        }
    }
}
