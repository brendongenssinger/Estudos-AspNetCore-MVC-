using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MovimentosManuais.InfraStruture.Migrations
{
    public partial class _migration001 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PRODUTO",
                columns: table => new
                {
                    COD_PRODUTO = table.Column<string>(type:"VARCHAR(450)",nullable: false),
                    DES_PRODUTO = table.Column<string>(type: "VARCHAR(30)", nullable: false),
                    STA_STATUS = table.Column<string>(type: "CHAR(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRODUTO", x => x.COD_PRODUTO);
                });

            migrationBuilder.CreateTable(
                name: "PRODUTO_COSIF",
                columns: table => new
                {
                    COD_PRODUTO = table.Column<string>(type: "VARCHAR(450)", nullable: false),
                    COD_COSIF = table.Column<string>(type: "VARCHAR(450)", nullable: false),
                    COD_CLASSIFICACAO = table.Column<string>(type: "CHAR(6)", nullable: false),
                    STA_STATUS = table.Column<string>(type: "CHAR(1)", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRODUTO_COSIF", x => x.COD_COSIF);
                    table.ForeignKey(
                        name: "FK_PRODUTO_COSIF_PRODUTO_ProdutoCOD_PRODUTO",
                        column: x => x.COD_PRODUTO,
                        principalTable: "PRODUTO",
                        principalColumn: "COD_PRODUTO",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MOVIMENTO_MANUAL",
                columns: table => new
                {
                    COD_COSIF = table.Column<string>(type: "VARCHAR(450)", nullable: false),
                    DAT_MES = table.Column<decimal>(type: "NUMERIC(2,0)", nullable: false),
                    DAT_ANO = table.Column<decimal>(type: "NUMERIC(4,0)", nullable: false),
                    NUM_LANCAMENTO = table.Column<decimal>(type: "NUMERIC(18,0)", nullable: false),
                    COD_PRODUTO = table.Column<string>(type: "VARCHAR(450)",nullable: false),
                    DES_DESCRICAO = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    DAT_MOVIMENTO = table.Column<DateTime>(type: "SMALLDATETIME", nullable: false),
                    COD_USUARIO = table.Column<string>(type: "VARCHAR(15)", nullable: true),
                    VAL_VALOR = table.Column<decimal>(type: "NUMERIC(18,2)", nullable: false),
                },
                constraints: table =>
                {
                    
                    table.UniqueConstraint("AK_MOVIMENTO_MANUAL_DAT_ANO", x =>new { x.DAT_ANO, x.DAT_MES, x.NUM_LANCAMENTO });
                    table.ForeignKey(
                        name: "FK_MOVIMENTO_MANUAL_PRODUTO_ProdutoCOD_PRODUTO",
                        column: x => x.COD_PRODUTO,
                        principalTable: "PRODUTO",
                        principalColumn: "COD_PRODUTO",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MOVIMENTO_MANUAL_PRODUTO_COSIF_Produto_CosifCOD_PRODUTO",
                        column: x => x.COD_COSIF,
                        principalTable: "PRODUTO_COSIF",
                        principalColumn: "COD_COSIF",
                        onDelete: ReferentialAction.Restrict);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MOVIMENTO_MANUAL");

            migrationBuilder.DropTable(
                name: "PRODUTO_COSIF");

            migrationBuilder.DropTable(
                name: "PRODUTO");
        }
    }
}
