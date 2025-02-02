using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MinhaEstante.API.Endpoints;
using MinhaEstante.Dados.Banco;
using MinhaEstante.Modelos;
using MinhaEstante.Modelos.Modelos;
using System.Data.SqlTypes;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<MinhaEstanteContext>((options) => {
    options
            .UseSqlServer(builder.Configuration["ConnectionStrings:MinhaEstanteDB"])
            .UseLazyLoadingProxies();
});

builder.Services.AddTransient<DAL<Autor>>();
builder.Services.AddTransient<DAL<Livro>>();
builder.Services.AddTransient<DAL<Genero>>();
builder.Services.AddTransient<DAL<Editora>>();
builder.Services.AddTransient<DAL<Saga>>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options => options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

var app = builder.Build();

app.UseStaticFiles();

app.AddEndPointsAutores();

app.UseSwagger();
app.UseSwaggerUI();

app.Run();