using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackendWM.Migrations
{
    /// <inheritdoc />
    public partial class LinkFotoIngrediente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LinkFoto",
                table: "Ingrediente",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LinkFoto",
                table: "Ingrediente");
        }
    }
}
