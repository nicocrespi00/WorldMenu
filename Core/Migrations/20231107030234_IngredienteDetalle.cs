using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackendWM.Migrations
{
    /// <inheritdoc />
    public partial class IngredienteDetalle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdPais",
                table: "Plato",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PaisId",
                table: "Plato",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Ingrediente",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<decimal>(
                name: "CaloriasX100mg",
                table: "Ingrediente",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "FibraX100mg",
                table: "Ingrediente",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "PotasioX100mg",
                table: "Ingrediente",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<bool>(
                name: "TieneCalcio",
                table: "Ingrediente",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "TieneYodo",
                table: "Ingrediente",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Plato_PaisId",
                table: "Plato",
                column: "PaisId");

            migrationBuilder.AddForeignKey(
                name: "FK_Plato_Pais_PaisId",
                table: "Plato",
                column: "PaisId",
                principalTable: "Pais",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Plato_Pais_PaisId",
                table: "Plato");

            migrationBuilder.DropIndex(
                name: "IX_Plato_PaisId",
                table: "Plato");

            migrationBuilder.DropColumn(
                name: "IdPais",
                table: "Plato");

            migrationBuilder.DropColumn(
                name: "PaisId",
                table: "Plato");

            migrationBuilder.DropColumn(
                name: "CaloriasX100mg",
                table: "Ingrediente");

            migrationBuilder.DropColumn(
                name: "FibraX100mg",
                table: "Ingrediente");

            migrationBuilder.DropColumn(
                name: "PotasioX100mg",
                table: "Ingrediente");

            migrationBuilder.DropColumn(
                name: "TieneCalcio",
                table: "Ingrediente");

            migrationBuilder.DropColumn(
                name: "TieneYodo",
                table: "Ingrediente");

            migrationBuilder.AlterColumn<int>(
                name: "Nombre",
                table: "Ingrediente",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
