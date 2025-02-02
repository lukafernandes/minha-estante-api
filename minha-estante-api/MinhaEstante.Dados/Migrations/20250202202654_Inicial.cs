using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MinhaEstante.Dados.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Autores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FotoPerfil = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Bio = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Editoras",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Editoras", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Generos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Generos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sagas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AutorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sagas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sagas_Autores_AutorId",
                        column: x => x.AutorId,
                        principalTable: "Autores",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "livros",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sinopse = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnoLancamento = table.Column<int>(type: "int", nullable: true),
                    AutorId = table.Column<int>(type: "int", nullable: true),
                    SagaId = table.Column<int>(type: "int", nullable: true),
                    EditoraId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_livros", x => x.Id);
                    table.ForeignKey(
                        name: "FK_livros_Autores_AutorId",
                        column: x => x.AutorId,
                        principalTable: "Autores",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_livros_Editoras_EditoraId",
                        column: x => x.EditoraId,
                        principalTable: "Editoras",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_livros_Sagas_SagaId",
                        column: x => x.SagaId,
                        principalTable: "Sagas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "GeneroLivro",
                columns: table => new
                {
                    GenerosId = table.Column<int>(type: "int", nullable: false),
                    LivrosId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeneroLivro", x => new { x.GenerosId, x.LivrosId });
                    table.ForeignKey(
                        name: "FK_GeneroLivro_Generos_GenerosId",
                        column: x => x.GenerosId,
                        principalTable: "Generos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GeneroLivro_livros_LivrosId",
                        column: x => x.LivrosId,
                        principalTable: "livros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GeneroLivro_LivrosId",
                table: "GeneroLivro",
                column: "LivrosId");

            migrationBuilder.CreateIndex(
                name: "IX_livros_AutorId",
                table: "livros",
                column: "AutorId");

            migrationBuilder.CreateIndex(
                name: "IX_livros_EditoraId",
                table: "livros",
                column: "EditoraId");

            migrationBuilder.CreateIndex(
                name: "IX_livros_SagaId",
                table: "livros",
                column: "SagaId");

            migrationBuilder.CreateIndex(
                name: "IX_Sagas_AutorId",
                table: "Sagas",
                column: "AutorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GeneroLivro");

            migrationBuilder.DropTable(
                name: "Generos");

            migrationBuilder.DropTable(
                name: "livros");

            migrationBuilder.DropTable(
                name: "Editoras");

            migrationBuilder.DropTable(
                name: "Sagas");

            migrationBuilder.DropTable(
                name: "Autores");
        }
    }
}
