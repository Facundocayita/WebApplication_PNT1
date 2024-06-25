using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication_PNT1.Migrations
{
    /// <inheritdoc />
    public partial class ProyectoCOnAtributos_CostoUni_CostoTotal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "CostoTotal",
                table: "Proyectos",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "CostoUnitario",
                table: "Proyectos",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CostoTotal",
                table: "Proyectos");

            migrationBuilder.DropColumn(
                name: "CostoUnitario",
                table: "Proyectos");
        }
    }
}
