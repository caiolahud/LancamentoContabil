using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LancamentoContabil.Migrations
{
    /// <inheritdoc />
    public partial class PrimeiraMigracao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Lancamento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    CodEmpresa = table.Column<string>(type: "VARCHAR2(3)", nullable: false),
                    Lote = table.Column<string>(type: "VARCHAR2(6)", nullable: false),
                    Documento = table.Column<string>(type: "VARCHAR2(6)", nullable: false),
                    DataLancamento = table.Column<DateTime>(type: "DATE", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lancamento", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContasContabeis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    ContaContabil = table.Column<string>(type: "VARCHAR2(15)", nullable: false),
                    TipoLancamento = table.Column<string>(type: "VARCHAR2(2)", nullable: false),
                    Valor = table.Column<decimal>(type: "NUMBER(19,2)", nullable: false),
                    Historico = table.Column<string>(type: "VARCHAR2(100)", nullable: false),
                    LancamentoContabilId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContasContabeis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContasContabeis_Lancamento_LancamentoContabilId",
                        column: x => x.LancamentoContabilId,
                        principalTable: "Lancamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContasContabeis_LancamentoContabilId",
                table: "ContasContabeis",
                column: "LancamentoContabilId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContasContabeis");

            migrationBuilder.DropTable(
                name: "Lancamento");
        }
    }
}
