using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using MusicPlaylist.WebApi.Repositories;
using MusicPlaylist.WebApi.Repositories.EntityFramework;
using MusicPlaylist.WebApi.Services;
using MusicPlaylist.WebApi.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
        .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
        .UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole()));
});

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "MusicPlaylist",
        Description = "MusicPlaylist é uma api com três entidades (Artists, Musics e Playlists) que permite a realização das operações de criar, consultar, atualizar e deletar.",
        Version = "v1",
        Contact = new OpenApiContact
        {
            Name = "Mateus Henrique Alves de Souza",
            Email = "mateushas.dev@gmail.com",
            Url = new Uri("https://www.linkedin.com/in/mateushenriqueas/")
        }
    });

    var xmlFile = "MusicPlaylist.WebApi.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    options.IncludeXmlComments(xmlPath);
});

builder.Services.AddControllers();

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddScoped<IArtistRepository, EFArtistRepository>();
builder.Services.AddScoped<IArtistService, ArtistService>();
builder.Services.AddScoped<IMusicRepository, EFMusicRepository>();
builder.Services.AddScoped<IMusicService, MusicService>();
builder.Services.AddScoped<IPlaylistRepository, EFPlaylistRepository>();
builder.Services.AddScoped<IPlaylistService, PlaylistService>();
builder.Services.AddScoped<IMusicsPlaylists, EFMusicsPlaylists>();

var app = builder.Build();

if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "MusicPlaylist API v1");
        c.RoutePrefix = string.Empty;
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
