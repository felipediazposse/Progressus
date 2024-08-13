using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProgressusWebApi.Migrations
{
    /// <inheritdoc />
    public partial class PlanesDeEntrenamiento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CantidadDeSemanas",
                table: "PlanesDeEntrenamiento");

            migrationBuilder.AddColumn<int>(
                name: "SemanaDelPlan",
                table: "SeriesDeEjercicio",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "DueñoDePlanId",
                table: "PlanesDeEntrenamiento",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DueñoDelPlanId",
                table: "PlanesDeEntrenamiento",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PlanesDeEntrenamiento_DueñoDelPlanId",
                table: "PlanesDeEntrenamiento",
                column: "DueñoDelPlanId");

            migrationBuilder.AddForeignKey(
                name: "FK_PlanesDeEntrenamiento_AspNetUsers_DueñoDelPlanId",
                table: "PlanesDeEntrenamiento",
                column: "DueñoDelPlanId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlanesDeEntrenamiento_AspNetUsers_DueñoDelPlanId",
                table: "PlanesDeEntrenamiento");

            migrationBuilder.DropIndex(
                name: "IX_PlanesDeEntrenamiento_DueñoDelPlanId",
                table: "PlanesDeEntrenamiento");

            migrationBuilder.DropColumn(
                name: "SemanaDelPlan",
                table: "SeriesDeEjercicio");

            migrationBuilder.DropColumn(
                name: "DueñoDePlanId",
                table: "PlanesDeEntrenamiento");

            migrationBuilder.DropColumn(
                name: "DueñoDelPlanId",
                table: "PlanesDeEntrenamiento");

            migrationBuilder.AddColumn<int>(
                name: "CantidadDeSemanas",
                table: "PlanesDeEntrenamiento",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
