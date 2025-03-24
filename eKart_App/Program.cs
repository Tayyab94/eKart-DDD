using eKart.Infrastructure.Extensions;
using eKart.Persistence.Extensions;
using eKart_App.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.Services.RegisterControllers().RegisterOptions().RegisterDatabase();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
