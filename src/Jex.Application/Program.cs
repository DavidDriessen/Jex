using FastEndpoints;
using FastEndpoints.Swagger;
using Jex.Persistence.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddPersistence();
builder.Services.AddFastEndpoints().SwaggerDocument();

var app = builder.Build();

app.InitPersistence();

app.UseFastEndpoints();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwaggerGen();
}

app.UseHttpsRedirection();

app.Run();