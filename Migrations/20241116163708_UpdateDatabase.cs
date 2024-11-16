using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MusicPlaylist.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_music_playlist",
                table: "music_playlist");

            migrationBuilder.DropIndex(
                name: "IX_music_playlist_PlaylistsId",
                table: "music_playlist");

            migrationBuilder.AddPrimaryKey(
                name: "PK_music_playlist",
                table: "music_playlist",
                columns: new[] { "PlaylistsId", "MusicsId" });

            migrationBuilder.CreateIndex(
                name: "IX_music_playlist_MusicsId",
                table: "music_playlist",
                column: "MusicsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_music_playlist",
                table: "music_playlist");

            migrationBuilder.DropIndex(
                name: "IX_music_playlist_MusicsId",
                table: "music_playlist");

            migrationBuilder.AddPrimaryKey(
                name: "PK_music_playlist",
                table: "music_playlist",
                columns: new[] { "MusicsId", "PlaylistsId" });

            migrationBuilder.CreateIndex(
                name: "IX_music_playlist_PlaylistsId",
                table: "music_playlist",
                column: "PlaylistsId");
        }
    }
}
