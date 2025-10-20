var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/", () => "API Hyden está rodando 🚀");

app.MapGet("/planta/{id}", (int id) =>
{
    var planta = new { Id = id, Nome = "Tomate", UmidadeIdeal = 60 };
    return Results.Ok(planta);
});

app.MapPost("/planta", (dynamic planta) =>
{

    return Results.Created($"/planta/{planta.id}", planta);
});

app.Run();
