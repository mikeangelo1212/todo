using System.ComponentModel;
using efscaffold.Entities;
using Infrastructure.Postgres.Scaffolding;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DotNetEnv;

var builder = WebApplication.CreateBuilder(args);
Env.Load("../efscaffold/.env");
var connectionString = Environment.GetEnvironmentVariable("CONN_STR");


//TODO: Primer Roadblock lol
builder.Services.AddDbContext<MyDbContext>(options => options.UseNpgsql(connectionString));

builder.Services.AddCors();

if (string.IsNullOrEmpty(connectionString))
{
    throw new Exception("CONN_STR environment variable is not set!");
}

builder.Services.AddControllers();

var app = builder.Build();

app.UseCors(config=>config.
                    AllowAnyHeader().
                    AllowAnyMethod().
                    AllowAnyOrigin().
                    SetIsOriginAllowed(x=>true));

app.MapControllers();

//agregamos contexto de la base de datos 
//ya que esta madre corre como principal


app.MapGet("/", ([FromServices]MyDbContext dbContext) => {
    
    var objects = dbContext.Todos.ToList();
    return objects;

});

app.Run();
