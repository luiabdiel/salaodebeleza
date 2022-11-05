using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace salaodebeleza.Data.Migrations
{
    public partial class NewModel6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TempoEstimado",
                table: "Vendas",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TempoEstimado",
                table: "Vendas");
        }
    }
}
