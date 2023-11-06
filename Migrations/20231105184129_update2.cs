using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionAcademica.Migrations
{
    /// <inheritdoc />
    public partial class update2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AsignaturaCarrera1");

            migrationBuilder.DropTable(
                name: "AsignaturaDocente1");

            migrationBuilder.DropTable(
                name: "AsignaturaEvaluacion");

            migrationBuilder.CreateIndex(
                name: "IX_Evaluaciones_AsignaturaId",
                table: "Evaluaciones",
                column: "AsignaturaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Evaluaciones_Asignaturas_AsignaturaId",
                table: "Evaluaciones",
                column: "AsignaturaId",
                principalTable: "Asignaturas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Evaluaciones_Asignaturas_AsignaturaId",
                table: "Evaluaciones");

            migrationBuilder.DropIndex(
                name: "IX_Evaluaciones_AsignaturaId",
                table: "Evaluaciones");

            migrationBuilder.CreateTable(
                name: "AsignaturaCarrera1",
                columns: table => new
                {
                    AsignaturasId = table.Column<int>(type: "int", nullable: false),
                    CarrerasId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AsignaturaCarrera1", x => new { x.AsignaturasId, x.CarrerasId });
                    table.ForeignKey(
                        name: "FK_AsignaturaCarrera1_Asignaturas_AsignaturasId",
                        column: x => x.AsignaturasId,
                        principalTable: "Asignaturas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AsignaturaCarrera1_Carreras_CarrerasId",
                        column: x => x.CarrerasId,
                        principalTable: "Carreras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AsignaturaDocente1",
                columns: table => new
                {
                    AsignaturasId = table.Column<int>(type: "int", nullable: false),
                    DocentesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AsignaturaDocente1", x => new { x.AsignaturasId, x.DocentesId });
                    table.ForeignKey(
                        name: "FK_AsignaturaDocente1_Asignaturas_AsignaturasId",
                        column: x => x.AsignaturasId,
                        principalTable: "Asignaturas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AsignaturaDocente1_Docentes_DocentesId",
                        column: x => x.DocentesId,
                        principalTable: "Docentes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AsignaturaEvaluacion",
                columns: table => new
                {
                    AsignaturasId = table.Column<int>(type: "int", nullable: false),
                    EvaluacionesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AsignaturaEvaluacion", x => new { x.AsignaturasId, x.EvaluacionesId });
                    table.ForeignKey(
                        name: "FK_AsignaturaEvaluacion_Asignaturas_AsignaturasId",
                        column: x => x.AsignaturasId,
                        principalTable: "Asignaturas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AsignaturaEvaluacion_Evaluaciones_EvaluacionesId",
                        column: x => x.EvaluacionesId,
                        principalTable: "Evaluaciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_AsignaturaCarrera1_CarrerasId",
                table: "AsignaturaCarrera1",
                column: "CarrerasId");

            migrationBuilder.CreateIndex(
                name: "IX_AsignaturaDocente1_DocentesId",
                table: "AsignaturaDocente1",
                column: "DocentesId");

            migrationBuilder.CreateIndex(
                name: "IX_AsignaturaEvaluacion_EvaluacionesId",
                table: "AsignaturaEvaluacion",
                column: "EvaluacionesId");
        }
    }
}
