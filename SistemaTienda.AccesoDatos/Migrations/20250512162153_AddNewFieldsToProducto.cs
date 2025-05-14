using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaTienda.AccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class AddNewFieldsToProducto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Año",
                table: "Producto",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ColorDisponible",
                table: "Producto",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Modelo",
                table: "Producto",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NumeroPlaca",
                table: "Producto",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "Precio",
                table: "Producto",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Año",
                table: "Producto");

            migrationBuilder.DropColumn(
                name: "ColorDisponible",
                table: "Producto");

            migrationBuilder.DropColumn(
                name: "Modelo",
                table: "Producto");

            migrationBuilder.DropColumn(
                name: "NumeroPlaca",
                table: "Producto");

            migrationBuilder.DropColumn(
                name: "Precio",
                table: "Producto");
        }
    }
}
