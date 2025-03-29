using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Benner.DeveloperEvaluation.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProgramaMicroondas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Alimento = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Tempo = table.Column<double>(type: "float", nullable: false),
                    Potencia = table.Column<int>(type: "int", nullable: false),
                    Aquecimento = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Instrucoes = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgramaMicroondas", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProgramaMicroondas");
        }
    }
}
