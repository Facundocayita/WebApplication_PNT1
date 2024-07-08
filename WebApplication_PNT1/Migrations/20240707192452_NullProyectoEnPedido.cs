using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication_PNT1.Migrations
{
    /// <inheritdoc />
    public partial class NullProyectoEnPedido : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Pedidos_ProyectoId",
                table: "Pedidos");

            migrationBuilder.AlterColumn<int>(
                name: "ProyectoId",
                table: "Pedidos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_ProyectoId",
                table: "Pedidos",
                column: "ProyectoId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Pedidos_ProyectoId",
                table: "Pedidos");

            migrationBuilder.AlterColumn<int>(
                name: "ProyectoId",
                table: "Pedidos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_ProyectoId",
                table: "Pedidos",
                column: "ProyectoId",
                unique: true,
                filter: "[ProyectoId] IS NOT NULL");
        }
    }
}
