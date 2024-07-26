using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProgressusWebApi.Migrations
{
    /// <inheritdoc />
    public partial class PlanesDeEntrenamientoModule : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ejercicios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImagenMaquina = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VideoEjercicio = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ejercicios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GruposMusculares",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImagenGrupoMuscular = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GruposMusculares", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ObjetivosDePlanes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ObjetivosDePlanes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Musculos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GrupoMuscularId = table.Column<int>(type: "int", nullable: false),
                    ImagenMusculo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Musculos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Musculos_GruposMusculares_GrupoMuscularId",
                        column: x => x.GrupoMuscularId,
                        principalTable: "GruposMusculares",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlanesDeEntrenamiento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ObjetivoDelPlanId = table.Column<int>(type: "int", nullable: false),
                    DiasPorSemana = table.Column<int>(type: "int", nullable: false),
                    FechaDeCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CantidadDeSemanas = table.Column<int>(type: "int", nullable: false),
                    EsPlantilla = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanesDeEntrenamiento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlanesDeEntrenamiento_ObjetivosDePlanes_ObjetivoDelPlanId",
                        column: x => x.ObjetivoDelPlanId,
                        principalTable: "ObjetivosDePlanes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MusculosDeEjercicios",
                columns: table => new
                {
                    EjercicioId = table.Column<int>(type: "int", nullable: false),
                    MusculoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MusculosDeEjercicios", x => new { x.EjercicioId, x.MusculoId });
                    table.ForeignKey(
                        name: "FK_MusculosDeEjercicios_Ejercicios_EjercicioId",
                        column: x => x.EjercicioId,
                        principalTable: "Ejercicios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MusculosDeEjercicios_Musculos_MusculoId",
                        column: x => x.MusculoId,
                        principalTable: "Musculos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AsignacionesDePlanes",
                columns: table => new
                {
                    SocioId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PlanDeEntrenamientoId = table.Column<int>(type: "int", nullable: false),
                    fechaDeAsginacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    esVigente = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AsignacionesDePlanes", x => new { x.PlanDeEntrenamientoId, x.SocioId });
                    table.ForeignKey(
                        name: "FK_AsignacionesDePlanes_AspNetUsers_SocioId",
                        column: x => x.SocioId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AsignacionesDePlanes_PlanesDeEntrenamiento_PlanDeEntrenamientoId",
                        column: x => x.PlanDeEntrenamientoId,
                        principalTable: "PlanesDeEntrenamiento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DiasDePlan",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlanDeEntrenamientoId = table.Column<int>(type: "int", nullable: false),
                    NumeroDeDia = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiasDePlan", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DiasDePlan_PlanesDeEntrenamiento_PlanDeEntrenamientoId",
                        column: x => x.PlanDeEntrenamientoId,
                        principalTable: "PlanesDeEntrenamiento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EjerciciosDelDia",
                columns: table => new
                {
                    DiaDePlanId = table.Column<int>(type: "int", nullable: false),
                    EjercicioId = table.Column<int>(type: "int", nullable: false),
                    OrdenDeEjercicio = table.Column<int>(type: "int", nullable: false),
                    Series = table.Column<int>(type: "int", nullable: false),
                    Repeticiones = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EjerciciosDelDia", x => new { x.EjercicioId, x.DiaDePlanId });
                    table.ForeignKey(
                        name: "FK_EjerciciosDelDia_DiasDePlan_DiaDePlanId",
                        column: x => x.DiaDePlanId,
                        principalTable: "DiasDePlan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EjerciciosDelDia_Ejercicios_EjercicioId",
                        column: x => x.EjercicioId,
                        principalTable: "Ejercicios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SeriesDeEjercicio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    DiaDePlanId = table.Column<int>(type: "int", nullable: false),
                    EjercicioId = table.Column<int>(type: "int", nullable: false),
                    NumeroDeSerie = table.Column<int>(type: "int", nullable: false),
                    RepeticionesConcretadas = table.Column<int>(type: "int", nullable: false),
                    fechaDeRealizacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeriesDeEjercicio", x => new { x.Id, x.DiaDePlanId, x.EjercicioId });
                    table.ForeignKey(
                        name: "FK_SeriesDeEjercicio_EjerciciosDelDia_EjercicioId_DiaDePlanId",
                        columns: x => new { x.EjercicioId, x.DiaDePlanId },
                        principalTable: "EjerciciosDelDia",
                        principalColumns: new[] { "EjercicioId", "DiaDePlanId" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AsignacionesDePlanes_SocioId",
                table: "AsignacionesDePlanes",
                column: "SocioId");

            migrationBuilder.CreateIndex(
                name: "IX_DiasDePlan_PlanDeEntrenamientoId",
                table: "DiasDePlan",
                column: "PlanDeEntrenamientoId");

            migrationBuilder.CreateIndex(
                name: "IX_EjerciciosDelDia_DiaDePlanId",
                table: "EjerciciosDelDia",
                column: "DiaDePlanId");

            migrationBuilder.CreateIndex(
                name: "IX_Musculos_GrupoMuscularId",
                table: "Musculos",
                column: "GrupoMuscularId");

            migrationBuilder.CreateIndex(
                name: "IX_MusculosDeEjercicios_MusculoId",
                table: "MusculosDeEjercicios",
                column: "MusculoId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanesDeEntrenamiento_ObjetivoDelPlanId",
                table: "PlanesDeEntrenamiento",
                column: "ObjetivoDelPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_SeriesDeEjercicio_EjercicioId_DiaDePlanId",
                table: "SeriesDeEjercicio",
                columns: new[] { "EjercicioId", "DiaDePlanId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AsignacionesDePlanes");

            migrationBuilder.DropTable(
                name: "MusculosDeEjercicios");

            migrationBuilder.DropTable(
                name: "SeriesDeEjercicio");

            migrationBuilder.DropTable(
                name: "Musculos");

            migrationBuilder.DropTable(
                name: "EjerciciosDelDia");

            migrationBuilder.DropTable(
                name: "GruposMusculares");

            migrationBuilder.DropTable(
                name: "DiasDePlan");

            migrationBuilder.DropTable(
                name: "Ejercicios");

            migrationBuilder.DropTable(
                name: "PlanesDeEntrenamiento");

            migrationBuilder.DropTable(
                name: "ObjetivosDePlanes");
        }
    }
}
