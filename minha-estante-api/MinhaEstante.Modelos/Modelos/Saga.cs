using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinhaEstante.Modelos.Modelos;

public class Saga
{
    public int Id { get; set; }
    public string? Nome { get; set; } = string.Empty;
    public int? AutorId { get; set; }
    public virtual Autor? Autor { get; set; }
    public virtual ICollection<Livro> Livros { get; set; }

    public override string ToString()
    {
        return $"Nome: {Nome}";
    }
}
