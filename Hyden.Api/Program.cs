using Hyden.Api;
using Hyden.Api.Common.Api;
using Hyden.Api.Endpoints;

var builder = WebApplication.CreateBuilder(args);
builder.AddConfiguration();
builder.AddSecurity();
builder.AddDataContexts();
builder.AddCrossOrigin();
builder.AddDocumentation();
builder.AddServices();

var app = builder.Build();

if (app.Environment.IsDevelopment())
    app.ConfigureDevEnvironment();

app.UseSecurity();
app.UseCors(ApiConfiguration.CorsPolicyName);
app.MapEndpoints();

app.Run();
