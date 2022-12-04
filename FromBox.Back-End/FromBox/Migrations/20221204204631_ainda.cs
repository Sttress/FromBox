using Microsoft.EntityFrameworkCore.Migrations;

namespace FromBox.Migrations
{
    public partial class ainda : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Produto",
                table: "Produto");

            migrationBuilder.RenameTable(
                name: "Produto",
                newName: "PRODUTO");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "PRODUTO",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdLista",
                table: "PRODUTO",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdTipoLista",
                table: "PRODUTO",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ListaID",
                table: "PRODUTO",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Tipo_ProdutoID",
                table: "PRODUTO",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PRODUTO",
                table: "PRODUTO",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "TIPO_PRODUTO",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TIPO_PRODUTO", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "USUARIO",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(nullable: false),
                    Login = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Senha = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USUARIO", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LISTA",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(nullable: false),
                    Descricao = table.Column<string>(nullable: false),
                    IdUsuario = table.Column<int>(nullable: false),
                    UsuarioId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LISTA", x => x.ID);
                    table.ForeignKey(
                        name: "FK_LISTA_USUARIO_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "USUARIO",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PRODUTO_ListaID",
                table: "PRODUTO",
                column: "ListaID");

            migrationBuilder.CreateIndex(
                name: "IX_PRODUTO_Tipo_ProdutoID",
                table: "PRODUTO",
                column: "Tipo_ProdutoID");

            migrationBuilder.CreateIndex(
                name: "IX_LISTA_UsuarioId",
                table: "LISTA",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_PRODUTO_LISTA_ListaID",
                table: "PRODUTO",
                column: "ListaID",
                principalTable: "LISTA",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PRODUTO_TIPO_PRODUTO_Tipo_ProdutoID",
                table: "PRODUTO",
                column: "Tipo_ProdutoID",
                principalTable: "TIPO_PRODUTO",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PRODUTO_LISTA_ListaID",
                table: "PRODUTO");

            migrationBuilder.DropForeignKey(
                name: "FK_PRODUTO_TIPO_PRODUTO_Tipo_ProdutoID",
                table: "PRODUTO");

            migrationBuilder.DropTable(
                name: "LISTA");

            migrationBuilder.DropTable(
                name: "TIPO_PRODUTO");

            migrationBuilder.DropTable(
                name: "USUARIO");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PRODUTO",
                table: "PRODUTO");

            migrationBuilder.DropIndex(
                name: "IX_PRODUTO_ListaID",
                table: "PRODUTO");

            migrationBuilder.DropIndex(
                name: "IX_PRODUTO_Tipo_ProdutoID",
                table: "PRODUTO");

            migrationBuilder.DropColumn(
                name: "IdLista",
                table: "PRODUTO");

            migrationBuilder.DropColumn(
                name: "IdTipoLista",
                table: "PRODUTO");

            migrationBuilder.DropColumn(
                name: "ListaID",
                table: "PRODUTO");

            migrationBuilder.DropColumn(
                name: "Tipo_ProdutoID",
                table: "PRODUTO");

            migrationBuilder.RenameTable(
                name: "PRODUTO",
                newName: "Produto");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Produto",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Produto",
                table: "Produto",
                column: "Id");
        }
    }
}
