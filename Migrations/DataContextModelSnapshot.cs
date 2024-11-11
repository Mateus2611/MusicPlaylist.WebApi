﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MusicPlaylist.WebApi.Repositories.EntityFramework;

#nullable disable

namespace MusicPlaylist.WebApi.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MusicPlaylist", b =>
                {
                    b.Property<int>("MusicsId")
                        .HasColumnType("int");

                    b.Property<int>("PlaylistsId")
                        .HasColumnType("int");

                    b.HasKey("MusicsId", "PlaylistsId");

                    b.HasIndex("PlaylistsId");

                    b.ToTable("music_playlist", (string)null);
                });

            modelBuilder.Entity("MusicPlaylist.WebApi.Models.Artist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Bio")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("bio");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("artist", (string)null);
                });

            modelBuilder.Entity("MusicPlaylist.WebApi.Models.Music", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("ArtistId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

                    b.Property<DateTime>("Release")
                        .HasColumnType("datetime2")
                        .HasColumnName("release");

                    b.HasKey("Id");

                    b.HasIndex("ArtistId");

                    b.ToTable("music", (string)null);
                });

            modelBuilder.Entity("MusicPlaylist.WebApi.Models.Playlist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("playlist", (string)null);
                });

            modelBuilder.Entity("MusicPlaylist", b =>
                {
                    b.HasOne("MusicPlaylist.WebApi.Models.Music", null)
                        .WithMany()
                        .HasForeignKey("MusicsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MusicPlaylist.WebApi.Models.Playlist", null)
                        .WithMany()
                        .HasForeignKey("PlaylistsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MusicPlaylist.WebApi.Models.Music", b =>
                {
                    b.HasOne("MusicPlaylist.WebApi.Models.Artist", "Artists")
                        .WithMany("Musics")
                        .HasForeignKey("ArtistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Artists");
                });

            modelBuilder.Entity("MusicPlaylist.WebApi.Models.Artist", b =>
                {
                    b.Navigation("Musics");
                });
#pragma warning restore 612, 618
        }
    }
}
