using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaTienda.AccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class AddPasswordToClientes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Contraseña",
                table: "Clientes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

       
    }
}
