using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MusicPlaylist.WebApi.Models;

namespace MusicPlaylist.WebApi.Repositories.EntityFramework
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Artist> Artists { get; set; }

        public DbSet<Music> Musics { get; set; }

        public DbSet<Playlist> Playlists { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Artist>().ToTable("artist");
            modelBuilder.Entity<Artist>().HasKey(artist => new { artist.Id });
            modelBuilder.Entity<Artist>().Property(artist => artist.Id).HasColumnName("id");
            modelBuilder.Entity<Artist>().Property(artist => artist.Name).HasColumnName("name");
            modelBuilder.Entity<Artist>().Property(artist => artist.Bio).HasColumnName("bio");

            modelBuilder.Entity<Music>().ToTable("music");
            modelBuilder.Entity<Music>().HasKey(music => new { music.Id });
            modelBuilder.Entity<Music>().Property(music => music.Id).HasColumnName("id");
            modelBuilder.Entity<Music>().Property(music => music.Name).HasColumnName("name");
            modelBuilder.Entity<Music>().Property(music => music.Release).HasColumnName("release");

            modelBuilder.Entity<Playlist>().ToTable("playlist");
            modelBuilder.Entity<Playlist>().HasKey(playlist => new { playlist.Id });
            modelBuilder.Entity<Playlist>().Property(playlist => playlist.Id).HasColumnName("id");
            modelBuilder.Entity<Playlist>().Property(playlist => playlist.Name).HasColumnName("name");


            modelBuilder.Entity<Music>()
                .HasOne(m => m.Artists)
                .WithMany(a => a.Musics);

            modelBuilder.Entity<Music>()
                .HasMany(p => p.Playlists)
                .WithMany(m => m.Musics)
                .UsingEntity(mp => mp.ToTable("music_playlist"));
        }
    }
}