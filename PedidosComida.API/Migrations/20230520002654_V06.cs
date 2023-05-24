using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PedidosComida.API.Migrations
{
    /// <inheritdoc />
    public partial class V06 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IdCliente",
                table: "PedidoComidas",
                newName: "IdClienteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IdClienteId",
                table: "PedidoComidas",
                newName: "IdCliente");
        }
    }
}
