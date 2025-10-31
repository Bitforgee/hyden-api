using Hyden.Api.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddDbContext<HydenDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference(
        "/docs",
        options =>
        {
            options
                .WithTitle("Hyden API")
                .AddDocument("v1", "Hyden API")
                .WithDefaultHttpClient(ScalarTarget.CSharp, ScalarClient.HttpClient)
                .WithClassicLayout()
                .ForceDarkMode()
                .HideSearch()
                .ShowOperationId()
                .ExpandAllTags()
                .SortTagsAlphabetically()
                .SortOperationsByMethod()
                .PreserveSchemaPropertyOrder();
        }
    );
}

//app.UseHttpsRedirection();

app.Run();
