using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PonudeApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ponude",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BrojPonude = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DatumPonude = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ponude", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PonudaStavke",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Artikl = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    JedinicnaCijena = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Kolicina = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    PonudaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PonudaStavke", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PonudaStavke_Ponude_PonudaId",
                        column: x => x.PonudaId,
                        principalTable: "Ponude",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PonudaStavke_PonudaId",
                table: "PonudaStavke",
                column: "PonudaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PonudaStavke");

            migrationBuilder.DropTable(
                name: "Ponude");
        }
    }
}
