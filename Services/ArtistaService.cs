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

        public List<Artist> ListarArtists() => _ArtistRepository.TodosLosArtists();    
        public List<Album> ListartAlbums() => _ArtistRepository.TodosLosAlbums();
        public List<Album> AlbumPorArtist(Guid ArtistId) => _ArtistRepository.AlbumsPorArtist(ArtistId);
        public Artist ArtistPorId(Guid ArtistId) => _ArtistRepository.ArtistPorId(ArtistId);
    }
}