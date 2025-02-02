using MinhaEstante.Dados.Banco;
using Microsoft.AspNetCore.Mvc;
using MinhaEstante.API.Requests;
using MinhaEstante.API.Response;
using MinhaEstante.Modelos.Modelos;
using MinhaEstante.Dados.Banco;
using System.Security.Claims;

namespace MinhaEstante.API.Endpoints;

public static class AutoresExtensions
{
    public static void AddEndPointsAutores(this WebApplication app)
    {
        var groupBuilder = app.MapGroup("autores")
            .RequireAuthorization()
            .WithTags("Autores");

        #region Endpoint Autores
        groupBuilder.MapGet("", ([FromServices] DAL<Autor> dal) =>
        {
            var listaDeAutores = dal.Listar();
            if (listaDeAutores is null)
            {
                return Results.NotFound();
            }
            var listaDeAutoresResponse = EntityListToResponseList(listaDeAutores);
            return Results.Ok(listaDeAutoresResponse);
        });

        groupBuilder.MapGet("{nome}", ([FromServices] DAL<Autor> dal, string nome) =>
        {
            var autor = dal.RecuperarPor(a => a.Nome.ToUpper().Equals(nome.ToUpper()));
            if (autor is null)
            {
                return Results.NotFound();
            }
            return Results.Ok(EntityToResponse(autor));

        });

        groupBuilder.MapPost("", async ([FromServices] IHostEnvironment env, [FromServices] DAL<Autor> dal, [FromBody] AutorRequest autorRequest) =>
        {
            var nome = autorRequest.nome.Trim();
            var imagemAutor = DateTime.Now.ToString("ddMMyyyyhhss") + "." + nome + ".jpeg";

            var path = Path.Combine(env.ContentRootPath, "wwwroot", "FotosPerfil", imagemAutor);

            using MemoryStream ms = new MemoryStream(Convert.FromBase64String(autorRequest.fotoPerfil!));
            using FileStream fs = new(path, FileMode.Create);
            await ms.CopyToAsync(fs);

            var autor = new Autor(autorRequest.nome, autorRequest.bio)
            {
                FotoPerfil = $"/FotosPerfil/{imagemAutor}"
            };

            dal.Adicionar(autor);
            return Results.Ok();
        });

        groupBuilder.MapDelete("{id}", ([FromServices] DAL<Autor> dal, int id) => {
            var autor = dal.RecuperarPor(a => a.Id == id);
            if (autor is null)
            {
                return Results.NotFound();
            }
            dal.Deletar(autor);
            return Results.NoContent();

        });

        groupBuilder.MapPut("", async ([FromServices] IHostEnvironment env, [FromServices] DAL<Autor> dal, [FromBody] AutorRequestEdit autorRequestEdit) => {
            var autorAAtualizar = dal.RecuperarPor(a => a.Id == autorRequestEdit.Id);
            if (autorAAtualizar is null)
            {
                return Results.NotFound();
            }

            var imagemAutor = DateTime.Now.ToString("ddMMyyyyhhss") + "." + autorRequestEdit.nome + ".jpeg";

            var path = Path.Combine(env.ContentRootPath, "wwwroot", "FotosPerfil", imagemAutor);

            using MemoryStream ms = new MemoryStream(Convert.FromBase64String(autorRequestEdit.fotoPerfil!));
            using FileStream fs = new(path, FileMode.Create);
            await ms.CopyToAsync(fs);

            autorAAtualizar.Nome = autorRequestEdit.nome;
            autorAAtualizar.Bio = autorRequestEdit.bio;
            autorAAtualizar.FotoPerfil = $"/FotosPerfil/{imagemAutor}";
            dal.Atualizar(autorAAtualizar);
            return Results.Ok();
        });

        #endregion
    }

    private static ICollection<AutorResponse> EntityListToResponseList(IEnumerable<Autor> listaDeAutores)
    {
        return listaDeAutores.Select(a => EntityToResponse(a)).ToList();
    }

    private static AutorResponse EntityToResponse(Autor autor)
    {
        return new AutorResponse(autor.Id, autor.Nome, autor.Bio, autor.FotoPerfil);
    }
}