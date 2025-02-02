using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MinhaEstante.Dados.Migrations
{
    /// <inheritdoc />
    public partial class RenomearTabela : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GeneroLivro_livros_LivrosId",
                table: "GeneroLivro");

            migrationBuilder.DropForeignKey(
                name: "FK_livros_Autores_AutorId",
                table: "livros");

            migrationBuilder.DropForeignKey(
                name: "FK_livros_Editoras_EditoraId",
                table: "livros");

            migrationBuilder.DropForeignKey(
                name: "FK_livros_Sagas_SagaId",
                table: "livros");

            migrationBuilder.DropPrimaryKey(
                name: "PK_livros",
                table: "livros");

            migrationBuilder.RenameTable(
                name: "livros",
                newName: "Livros");

            migrationBuilder.RenameIndex(
                name: "IX_livros_SagaId",
                table: "Livros",
                newName: "IX_Livros_SagaId");

            migrationBuilder.RenameIndex(
                name: "IX_livros_EditoraId",
                table: "Livros",
                newName: "IX_Livros_EditoraId");

            migrationBuilder.RenameIndex(
                name: "IX_livros_AutorId",
                table: "Livros",
                newName: "IX_Livros_AutorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Livros",
                table: "Livros",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GeneroLivro_Livros_LivrosId",
                table: "GeneroLivro",
                column: "LivrosId",
                principalTable: "Livros",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Livros_Autores_AutorId",
                table: "Livros",
                column: "AutorId",
                principalTable: "Autores",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Livros_Editoras_EditoraId",
                table: "Livros",
                column: "EditoraId",
                principalTable: "Editoras",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Livros_Sagas_SagaId",
                table: "Livros",
                column: "SagaId",
                principalTable: "Sagas",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GeneroLivro_Livros_LivrosId",
                table: "GeneroLivro");

            migrationBuilder.DropForeignKey(
                name: "FK_Livros_Autores_AutorId",
                table: "Livros");

            migrationBuilder.DropForeignKey(
                name: "FK_Livros_Editoras_EditoraId",
                table: "Livros");

            migrationBuilder.DropForeignKey(
                name: "FK_Livros_Sagas_SagaId",
                table: "Livros");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Livros",
                table: "Livros");

            migrationBuilder.RenameTable(
                name: "Livros",
                newName: "livros");

            migrationBuilder.RenameIndex(
                name: "IX_Livros_SagaId",
                table: "livros",
                newName: "IX_livros_SagaId");

            migrationBuilder.RenameIndex(
                name: "IX_Livros_EditoraId",
                table: "livros",
                newName: "IX_livros_EditoraId");

            migrationBuilder.RenameIndex(
                name: "IX_Livros_AutorId",
                table: "livros",
                newName: "IX_livros_AutorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_livros",
                table: "livros",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GeneroLivro_livros_LivrosId",
                table: "GeneroLivro",
                column: "LivrosId",
                principalTable: "livros",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_livros_Autores_AutorId",
                table: "livros",
                column: "AutorId",
                principalTable: "Autores",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_livros_Editoras_EditoraId",
                table: "livros",
                column: "EditoraId",
                principalTable: "Editoras",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_livros_Sagas_SagaId",
                table: "livros",
                column: "SagaId",
                principalTable: "Sagas",
                principalColumn: "Id");
        }
    }
}
