using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MusicPlaylist.WebApi.Models;
using MusicPlaylist.WebApi.Models.DTOs;
using MusicPlaylist.WebApi.Models.Responses;
using MusicPlaylist.WebApi.Repositories;
using MusicPlaylist.WebApi.Services.Interfaces;

namespace MusicPlaylist.WebApi.Services
{
    public class PlaylistService : IPlaylistService
    {
        private readonly IPlaylistRepository _playlistRepository;

        private readonly IMusicRepository _musicRepository;

        private readonly IMusicsPlaylists _musicsPlaylistsRepository;

        private readonly IMapper _mapper;

        public PlaylistService(IPlaylistRepository playlistRepository, IMusicRepository musicRepository, IMusicsPlaylists musicsPlaylistsRepository, IMapper mapper)
        {
            _playlistRepository = playlistRepository;
            _musicRepository = musicRepository;
            _musicsPlaylistsRepository = musicsPlaylistsRepository;
            _mapper = mapper;
        }

        public PlaylistResponse? Create(PlaylistDto playlist)
        {
            Playlist? newPlaylist = _mapper.Map<Playlist>(playlist);

            newPlaylist = _playlistRepository.Create(newPlaylist);

            if (newPlaylist is null)
                return null;

            if (playlist.MusicsIds is not null && playlist.MusicsIds.Any())
            {
                PlaylistMusicDto playlistMusicDto = new()
                {
                    IdsMusics = playlist.MusicsIds,
                    IdPlaylist = newPlaylist.Id
                };

                newPlaylist = _mapper.Map<Playlist>
                (
                    AddMusic(playlistMusicDto)
                );
            }

            return _mapper.Map<PlaylistResponse>(newPlaylist);
        }

        public void Delete(int id)
        {
            Playlist playlist = _playlistRepository.GetById(id) ?? throw new Exception("Playlist não encontrado.");
            _playlistRepository.Delete(playlist);
        }

        public IEnumerable<PlaylistResponse> GetAll()
        {
            return
                _mapper.Map<IEnumerable<PlaylistResponse>>
                (
                    _playlistRepository.GetAll()
                );
        }

        public PlaylistResponse? GetById(int id)
        {
            return
                _mapper.Map<PlaylistResponse>
                (
                    _playlistRepository.GetById(id)
                );
        }

        public IEnumerable<PlaylistResponse> GetByName(string name)
        {
            return
                _mapper.Map<IEnumerable<PlaylistResponse>>
                (
                    _playlistRepository.GetByName(name)
                );
        }

        public PlaylistResponse? Update(int id, PlaylistUpdateDto playlist)
        {
            Playlist playlistUpdate = _mapper.Map<Playlist>(playlist);
            playlistUpdate.Id = id;

            return
                _mapper.Map<PlaylistResponse>
                (
                    _playlistRepository.Update(playlistUpdate)
                );
        }

        public PlaylistResponse? AddMusic(PlaylistMusicDto musics)
        {
            Playlist? playlist = _playlistRepository.GetById(musics.IdPlaylist);

            if (playlist is null)
                return null;

            foreach (int music in musics.IdsMusics)
            {
                try
                {
                    Music? item = _musicRepository.GetById(music);

                    if ( item is not null )
                    {
                        MusicsPlaylists musicsPlaylists = new()
                        {
                            PlaylistId = playlist.Id,
                            MusicId = item.Id
                        };

                        _musicsPlaylistsRepository.Add(musicsPlaylists);
                    }

                } 
                catch {}
            }

            return
                _mapper.Map<PlaylistResponse>
                (
                    _playlistRepository.GetAll()
                );
        }

        public PlaylistResponse? RemoveMusic(PlaylistMusicDto musics)
        {
            Playlist? playlist = _playlistRepository.GetById(musics.IdPlaylist);

            if (playlist is null)
                return null;

            foreach (int music in musics.IdsMusics)
            {
                try
                {
                    Music? item = _musicRepository.GetById(music);

                    if ( item is not null )
                    {
                        MusicsPlaylists musicsPlaylists = new()
                        {
                            PlaylistId = playlist.Id,
                            MusicId = item.Id
                        };

                        _musicsPlaylistsRepository.Remove(musicsPlaylists);
                    }

                } 
                catch {}
            }

            return
                _mapper.Map<PlaylistResponse>
                (
                    _playlistRepository.GetAll()
                );
        }
    }
}