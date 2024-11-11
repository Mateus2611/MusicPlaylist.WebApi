using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MusicPlaylist.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class AddFieldArtistIdToTableMusic : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_music_artist_ArtistsId",
                table: "music");

            migrationBuilder.RenameColumn(
                name: "ArtistsId",
                table: "music",
                newName: "ArtistId");

            migrationBuilder.RenameIndex(
                name: "IX_music_ArtistsId",
                table: "music",
                newName: "IX_music_ArtistId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "release",
                table: "music",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.AddForeignKey(
                name: "FK_music_artist_ArtistId",
                table: "music",
                column: "ArtistId",
                principalTable: "artist",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_music_artist_ArtistId",
                table: "music");

            migrationBuilder.RenameColumn(
                name: "ArtistId",
                table: "music",
                newName: "ArtistsId");

            migrationBuilder.RenameIndex(
                name: "IX_music_ArtistId",
                table: "music",
                newName: "IX_music_ArtistsId");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "release",
                table: "music",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddForeignKey(
                name: "FK_music_artist_ArtistsId",
                table: "music",
                column: "ArtistsId",
                principalTable: "artist",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
