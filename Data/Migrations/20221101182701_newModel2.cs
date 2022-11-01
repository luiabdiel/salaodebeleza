using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace salaodebeleza.Data.Migrations
{
    public partial class newModel2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Quantidade",
                table: "VendasItens",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Quantidade",
                table: "Servicos",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<bool>(
                name: "Tipo",
                table: "Servicos",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantidade",
                table: "VendasItens");

            migrationBuilder.DropColumn(
                name: "Quantidade",
                table: "Servicos");

            migrationBuilder.DropColumn(
                name: "Tipo",
                table: "Servicos");
        }
    }
}
