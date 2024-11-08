using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using MusicPlaylist.WebApi.Repositories;
using MusicPlaylist.WebApi.Repositories.EntityFramework;
using MusicPlaylist.WebApi.Services;
using MusicPlaylist.WebApi.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataContext>( options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
        .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
        .UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole()));
});

builder.Services.AddSwaggerGen( options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "MusicPlaylist",
        Description = "Documentação da API MusicPlaylist.WebApi",
        Version = "v1"
    });
});

var app = builder.Build();

builder.Services.AddScoped<IArtistRepository, EFArtistRepository>();
builder.Services.AddScoped<IArtistService, ArtistService>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(opttions =>
    {
        opttions.SwaggerEndpoint("/swagger/v1/swagger.json", "MusicPlaylist.WebApi v1");
    });
}

app.Use(async (context, next) =>
{
    if (context.Request.Path == "/")
    {
        context.Response.Redirect("/swagger");
        return;
    }
    await next();
});

app.Run();
