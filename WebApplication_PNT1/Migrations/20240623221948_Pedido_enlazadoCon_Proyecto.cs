using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication_PNT1.Migrations
{
    /// <inheritdoc />
    public partial class Pedido_enlazadoCon_Proyecto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PedidoId",
                table: "Proyectos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Pedidos",
                columns: table => new
                {
                    IdPedido = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedidos", x => x.IdPedido);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Proyectos_PedidoId",
                table: "Proyectos",
                column: "PedidoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Proyectos_Pedidos_PedidoId",
                table: "Proyectos",
                column: "PedidoId",
                principalTable: "Pedidos",
                principalColumn: "IdPedido");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Proyectos_Pedidos_PedidoId",
                table: "Proyectos");

            migrationBuilder.DropTable(
                name: "Pedidos");

            migrationBuilder.DropIndex(
                name: "IX_Proyectos_PedidoId",
                table: "Proyectos");

            migrationBuilder.DropColumn(
                name: "PedidoId",
                table: "Proyectos");
        }
    }
}
