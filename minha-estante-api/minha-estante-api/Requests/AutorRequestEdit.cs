namespace MinhaEstante.API.Requests;

public record AutorRequestEdit(int Id, string nome, string bio, string? fotoPerfil)
    : AutorRequest(nome, bio, fotoPerfil);
