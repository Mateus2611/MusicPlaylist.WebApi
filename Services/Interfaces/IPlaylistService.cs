using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MusicPlaylist.WebApi.Models.DTOs;
using MusicPlaylist.WebApi.Models.Responses;

namespace MusicPlaylist.WebApi.Services.Interfaces
{
    public interface IPlaylistService
    {
        PlaylistResponse? Create(PlaylistDto playlist);

        IEnumerable<PlaylistResponse> GetAll();

        PlaylistResponse? Update(int id, PlaylistUpdateDto playlist);

        void Delete(int id);

        IEnumerable<PlaylistResponse> GetByName(string name);

        PlaylistResponse? GetById(int id);

        PlaylistResponse? AddMusic(PlaylistMusicDto musics);

        PlaylistResponse? RemoveMusic(PlaylistMusicDto musics);
    }
}