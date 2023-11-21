using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackendWM.Migrations
{
    /// <inheritdoc />
    public partial class fixes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IngredienteId",
                table: "PlatoIngrediente",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PlatoId",
                table: "PlatoIngrediente",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PlatoIngrediente_IngredienteId",
                table: "PlatoIngrediente",
                column: "IngredienteId");

            migrationBuilder.CreateIndex(
                name: "IX_PlatoIngrediente_PlatoId",
                table: "PlatoIngrediente",
                column: "PlatoId");

            migrationBuilder.AddForeignKey(
                name: "FK_PlatoIngrediente_Ingrediente_IngredienteId",
                table: "PlatoIngrediente",
                column: "IngredienteId",
                principalTable: "Ingrediente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlatoIngrediente_Plato_PlatoId",
                table: "PlatoIngrediente",
                column: "PlatoId",
                principalTable: "Plato",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlatoIngrediente_Ingrediente_IngredienteId",
                table: "PlatoIngrediente");

            migrationBuilder.DropForeignKey(
                name: "FK_PlatoIngrediente_Plato_PlatoId",
                table: "PlatoIngrediente");

            migrationBuilder.DropIndex(
                name: "IX_PlatoIngrediente_IngredienteId",
                table: "PlatoIngrediente");

            migrationBuilder.DropIndex(
                name: "IX_PlatoIngrediente_PlatoId",
                table: "PlatoIngrediente");

            migrationBuilder.DropColumn(
                name: "IngredienteId",
                table: "PlatoIngrediente");

            migrationBuilder.DropColumn(
                name: "PlatoId",
                table: "PlatoIngrediente");
        }
    }
}
