using eKart.Infrastructure.Extensions;
using eKart.Presentation.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.Services.RegisterOptions().RegisterDatabase();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
