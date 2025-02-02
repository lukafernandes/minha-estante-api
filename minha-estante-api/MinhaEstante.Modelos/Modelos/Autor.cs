namespace MinhaEstante.Modelos.Modelos;

public class Autor
{
    public virtual ICollection<Livro> Livros { get; set; } = new List<Livro>();
    public Autor()
    {

    }
    public Autor(string nome, string bio)
    {
        Nome = nome;
        Bio = bio;
    }

    public string Nome { get; set; }
    public string FotoPerfil { get; set; }
    public string Bio { get; set; }
    public int Id { get; set; }

    public void AdicionarLivro(Livro livro)
    {
        Livros.Add(livro);
    }

    public void ExibirLivrosEscritos()
    {
        Console.WriteLine($"Livros escritos por {Nome}");
        foreach (var livro in Livros)
        {
            Console.WriteLine($"{livro.Nome} - Ano de Lançamento: {livro.AnoLancamento}");
        }
    }

    public override string ToString()
    {
        return $@"Id: {Id}
            Nome: {Nome}
            Foto de Perfil: {FotoPerfil}
            Bio: {Bio}";
    }
}


