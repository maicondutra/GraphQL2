using System;
using System.Collections.Generic;
using ApiQL.Models;

namespace ApiQL.Services {
    public class ArtistService {

        private readonly ArtistRepository _ArtistRepository;
        public ArtistService(ArtistRepository repository)
        {
            _ArtistRepository = repository;
        }

        public List<Artist> ListArtists() => _ArtistRepository.AllArtists();    
        public List<Album> ListAlbums() => _ArtistRepository.AllAlbums();
        public List<Album> AlbumForArtist(Guid ArtistId) => _ArtistRepository.AlbumsForArtist(ArtistId);
        public Artist ArtistForId(Guid ArtistId) => _ArtistRepository.ArtistForId(ArtistId);
    }
}