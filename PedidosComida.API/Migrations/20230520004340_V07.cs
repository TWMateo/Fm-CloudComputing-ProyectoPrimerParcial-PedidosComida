using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PedidosComida.API.Migrations
{
    /// <inheritdoc />
    public partial class V07 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PedidoComidas_Clientes_ClienteIdCliente",
                table: "PedidoComidas");

            migrationBuilder.DropColumn(
                name: "IdClienteId",
                table: "PedidoComidas");

            migrationBuilder.AlterColumn<int>(
                name: "ClienteIdCliente",
                table: "PedidoComidas",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PedidoComidas_Clientes_ClienteIdCliente",
                table: "PedidoComidas",
                column: "ClienteIdCliente",
                principalTable: "Clientes",
                principalColumn: "IdCliente",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PedidoComidas_Clientes_ClienteIdCliente",
                table: "PedidoComidas");

            migrationBuilder.AlterColumn<int>(
                name: "ClienteIdCliente",
                table: "PedidoComidas",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<int>(
                name: "IdClienteId",
                table: "PedidoComidas",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_PedidoComidas_Clientes_ClienteIdCliente",
                table: "PedidoComidas",
                column: "ClienteIdCliente",
                principalTable: "Clientes",
                principalColumn: "IdCliente");
        }
    }
}
