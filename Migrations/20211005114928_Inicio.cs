using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Fiap.Aula03.Web.Migrations
{
    public partial class Inicio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tbl_Endereco",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Logradouro = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Cep = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Endereco", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Produto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", maxLength: 255, nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Disponivel = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Produto", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Cliente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EnderecoId = table.Column<int>(type: "int", nullable: true),
                    Nome = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Dt_nascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Genero = table.Column<int>(type: "int", nullable: true),
                    Especial = table.Column<bool>(type: "bit", nullable: false),
                    Cpf = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Cliente", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tbl_Cliente_Tbl_Endereco_EnderecoId",
                        column: x => x.EnderecoId,
                        principalTable: "Tbl_Endereco",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Pedido",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dt_Pedido = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Desconto = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Forma_Pagamento = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Pedido", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tbl_Pedido_Tbl_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Tbl_Cliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Item_Pedido",
                columns: table => new
                {
                    ProdutoId = table.Column<int>(type: "int", nullable: false),
                    PedidoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Item_Pedido", x => new { x.PedidoId, x.ProdutoId });
                    table.ForeignKey(
                        name: "FK_Tbl_Item_Pedido_Tbl_Pedido_PedidoId",
                        column: x => x.PedidoId,
                        principalTable: "Tbl_Pedido",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tbl_Item_Pedido_Tbl_Produto_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Tbl_Produto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Cliente_EnderecoId",
                table: "Tbl_Cliente",
                column: "EnderecoId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Item_Pedido_ProdutoId",
                table: "Tbl_Item_Pedido",
                column: "ProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Pedido_ClienteId",
                table: "Tbl_Pedido",
                column: "ClienteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tbl_Item_Pedido");

            migrationBuilder.DropTable(
                name: "Tbl_Pedido");

            migrationBuilder.DropTable(
                name: "Tbl_Produto");

            migrationBuilder.DropTable(
                name: "Tbl_Cliente");

            migrationBuilder.DropTable(
                name: "Tbl_Endereco");
        }
    }
}
