using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace salaodebeleza.Data.Migrations
{
    public partial class NewModel4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataAgendamento",
                table: "Vendas",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataAgendamento",
                table: "Vendas");
        }
    }
}
