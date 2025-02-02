using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MinhaEstante.Modelos;
using MinhaEstante.Modelos.Modelos;

namespace MinhaEstante.Dados.Banco;

public class MinhaEstanteContext: DbContext
{
    public DbSet<Autor> Autores { get; set; }
    public DbSet<Livro> Livros { get; set; }
    public DbSet<Genero> Generos { get; set; }
    public DbSet<Saga> Sagas { get; set; }
    public DbSet<Editora> Editoras { get; set; }

    private string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MinhaEstanteV0;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
    //Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MinhaEstanteV0;Trusted_Connection=True;

    public MinhaEstanteContext()
    {

    }

    public MinhaEstanteContext(DbContextOptions options)
    {

    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (optionsBuilder.IsConfigured)
        {
            return;
        }
        optionsBuilder
            .UseSqlServer(connectionString)
            .UseLazyLoadingProxies();
    }
}
