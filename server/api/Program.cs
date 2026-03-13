using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


//TODO: Primer Roadblock lol
builder.Services.AddDbContext<DbContext>("Host=localhost;Port=5432;Database=todo;Username=postgres;Password=postgres"){
    confs
}

var app = builder.Build();

//agregamos contexto de la base de datos 
//ya que esta madre corre como principal



app.MapGet("/", () => "Hello World!");

app.Run();
