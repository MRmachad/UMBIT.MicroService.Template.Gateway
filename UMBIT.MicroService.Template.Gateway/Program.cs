using UMBIT.MicroService.Template.Gateway.Configurate;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddApp();
builder.Services.AddBFF(builder.Configuration, builder.Environment);

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseApp(app.Environment);
app.UseBFF();

app.Run();
