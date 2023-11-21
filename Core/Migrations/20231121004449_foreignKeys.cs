using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackendWM.Migrations
{
    /// <inheritdoc />
    public partial class foreignKeys : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdIngrediente",
                table: "PlatoIngrediente");

            migrationBuilder.DropColumn(
                name: "IdPlato",
                table: "PlatoIngrediente");

            migrationBuilder.DropColumn(
                name: "IdPais",
                table: "Plato");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdIngrediente",
                table: "PlatoIngrediente",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdPlato",
                table: "PlatoIngrediente",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdPais",
                table: "Plato",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
