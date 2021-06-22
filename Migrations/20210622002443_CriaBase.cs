using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Teste_Paschoalott_Back_End.Migrations
{
    public partial class CriaBase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Titulos",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroTitulo = table.Column<long>(type: "bigint", nullable: false),
                    NomeDevedor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CpfDevedor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PercentualJuros = table.Column<double>(type: "float", nullable: false),
                    PercentualMulta = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Titulos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Parcelas",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroParcela = table.Column<long>(type: "bigint", nullable: false),
                    DataVencimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Valor = table.Column<double>(type: "float", nullable: false),
                    TituloId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parcelas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Parcelas_Titulos_TituloId",
                        column: x => x.TituloId,
                        principalTable: "Titulos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Parcelas_TituloId",
                table: "Parcelas",
                column: "TituloId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Parcelas");

            migrationBuilder.DropTable(
                name: "Titulos");
        }
    }
}
