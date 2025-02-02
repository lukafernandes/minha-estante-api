using System.ComponentModel.DataAnnotations;


namespace MinhaEstante.API.Requests;

public record AutorRequest([Required] string nome, [Required] string bio, string? fotoPerfil);
