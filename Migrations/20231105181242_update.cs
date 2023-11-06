using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionAcademica.Migrations
{
    /// <inheritdoc />
    public partial class update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carreras_Estudiantes_EstudianteId",
                table: "Carreras");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Docentes_DocenteId",
                table: "Usuarios");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Estudiantes_EstudianteId",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_DocenteId",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_EstudianteId",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Carreras_EstudianteId",
                table: "Carreras");

            migrationBuilder.DropColumn(
                name: "DocenteId",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "EstudianteId",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "EstudianteId",
                table: "Carreras");

            migrationBuilder.AddColumn<int>(
                name: "CarreraId",
                table: "Estudiantes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "CodigoEstudiante",
                table: "Estudiantes",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Estudiantes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Especialidad",
                table: "Docentes",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Docentes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Estudiantes_CarreraId",
                table: "Estudiantes",
                column: "CarreraId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Estudiantes_UsuarioId",
                table: "Estudiantes",
                column: "UsuarioId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Docentes_UsuarioId",
                table: "Docentes",
                column: "UsuarioId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Docentes_Usuarios_UsuarioId",
                table: "Docentes",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Estudiantes_Carreras_CarreraId",
                table: "Estudiantes",
                column: "CarreraId",
                principalTable: "Carreras",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Estudiantes_Usuarios_UsuarioId",
                table: "Estudiantes",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Docentes_Usuarios_UsuarioId",
                table: "Docentes");

            migrationBuilder.DropForeignKey(
                name: "FK_Estudiantes_Carreras_CarreraId",
                table: "Estudiantes");

            migrationBuilder.DropForeignKey(
                name: "FK_Estudiantes_Usuarios_UsuarioId",
                table: "Estudiantes");

            migrationBuilder.DropIndex(
                name: "IX_Estudiantes_CarreraId",
                table: "Estudiantes");

            migrationBuilder.DropIndex(
                name: "IX_Estudiantes_UsuarioId",
                table: "Estudiantes");

            migrationBuilder.DropIndex(
                name: "IX_Docentes_UsuarioId",
                table: "Docentes");

            migrationBuilder.DropColumn(
                name: "CarreraId",
                table: "Estudiantes");

            migrationBuilder.DropColumn(
                name: "CodigoEstudiante",
                table: "Estudiantes");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Estudiantes");

            migrationBuilder.DropColumn(
                name: "Especialidad",
                table: "Docentes");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Docentes");

            migrationBuilder.AddColumn<int>(
                name: "DocenteId",
                table: "Usuarios",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EstudianteId",
                table: "Usuarios",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EstudianteId",
                table: "Carreras",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_DocenteId",
                table: "Usuarios",
                column: "DocenteId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_EstudianteId",
                table: "Usuarios",
                column: "EstudianteId");

            migrationBuilder.CreateIndex(
                name: "IX_Carreras_EstudianteId",
                table: "Carreras",
                column: "EstudianteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Carreras_Estudiantes_EstudianteId",
                table: "Carreras",
                column: "EstudianteId",
                principalTable: "Estudiantes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Docentes_DocenteId",
                table: "Usuarios",
                column: "DocenteId",
                principalTable: "Docentes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Estudiantes_EstudianteId",
                table: "Usuarios",
                column: "EstudianteId",
                principalTable: "Estudiantes",
                principalColumn: "Id");
        }
    }
}
