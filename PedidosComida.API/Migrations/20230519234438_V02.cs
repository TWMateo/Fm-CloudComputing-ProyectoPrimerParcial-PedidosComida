using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PedidosComida.API.Migrations
{
    /// <inheritdoc />
    public partial class V02 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PedidoComida_Cliente_ClienteIdCliente",
                table: "PedidoComida");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PedidoComida",
                table: "PedidoComida");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cliente",
                table: "Cliente");

            migrationBuilder.RenameTable(
                name: "PedidoComida",
                newName: "PedidoComidas");

            migrationBuilder.RenameTable(
                name: "Cliente",
                newName: "Clientes");

            migrationBuilder.RenameIndex(
                name: "IX_PedidoComida_ClienteIdCliente",
                table: "PedidoComidas",
                newName: "IX_PedidoComidas_ClienteIdCliente");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PedidoComidas",
                table: "PedidoComidas",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Clientes",
                table: "Clientes",
                column: "IdCliente");

            migrationBuilder.AddForeignKey(
                name: "FK_PedidoComidas_Clientes_ClienteIdCliente",
                table: "PedidoComidas",
                column: "ClienteIdCliente",
                principalTable: "Clientes",
                principalColumn: "IdCliente");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PedidoComidas_Clientes_ClienteIdCliente",
                table: "PedidoComidas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PedidoComidas",
                table: "PedidoComidas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Clientes",
                table: "Clientes");

            migrationBuilder.RenameTable(
                name: "PedidoComidas",
                newName: "PedidoComida");

            migrationBuilder.RenameTable(
                name: "Clientes",
                newName: "Cliente");

            migrationBuilder.RenameIndex(
                name: "IX_PedidoComidas_ClienteIdCliente",
                table: "PedidoComida",
                newName: "IX_PedidoComida_ClienteIdCliente");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PedidoComida",
                table: "PedidoComida",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cliente",
                table: "Cliente",
                column: "IdCliente");

            migrationBuilder.AddForeignKey(
                name: "FK_PedidoComida_Cliente_ClienteIdCliente",
                table: "PedidoComida",
                column: "ClienteIdCliente",
                principalTable: "Cliente",
                principalColumn: "IdCliente");
        }
    }
}
