using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace salaodebeleza.Data.Migrations
{
    public partial class NewModel1 : Migration
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

            migrationBuilder.AddColumn<int>(
                name: "Tipo",
                table: "Servicos",
                type: "integer",
                nullable: false,
                defaultValue: 0);
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
