using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinhaEstante.Modelos.Modelos;

public class Livro
{
    public Livro()
    {

    }
    public Livro(string nome, string sinopse)
    {
        Nome = nome;
        Sinopse = sinopse;
    }

    public string Nome { get; set; }
    public string Sinopse { get; set; }
    public int Id { get; set; }
    public int? AnoLancamento { get; set; }
    public int? AutorId { get; set; }
    public virtual Autor? Autor { get; set; }
    public virtual ICollection<Genero> Generos { get; set; }
    public virtual Saga? Saga { get; set; }
    public virtual Editora? Editora { get; set; }

    public void ExibirFichaTecnica()
    {
        Console.WriteLine($"{Nome}");
        Console.WriteLine($"{Sinopse}");
    }

    public override string ToString()
    {
        return @$"Id: {Id}
        Nome: {Nome}";
    }
}
