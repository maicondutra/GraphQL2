using System;
using System.Collections.Generic;
using System.Linq;
using ApiQL.Models;

namespace ApiQL.Services
{

    public class ArtistRepository
    {

        private readonly List<Artist> _Artists;
        private readonly List<Album> _albums;
        public ArtistRepository()
        {
            _Artists = new List<Artist>();
            _albums = new List<Album>();

            //Artists
            _Artists.Add(new Artist
            {
                Name = "Diomedes Diaz",
                Gender = "Vallenato",
                Id = Guid.NewGuid()
            });

            _Artists.Add(new Artist
            {
                Name = "Freddie Mercury",
                Gender = "Rock",
                Id = Guid.NewGuid()
            });

            //Albums
            _albums.Add(new Album{
                Name = "Mi vida musical",
                Id = Guid.NewGuid(),
                Artist = _Artists.Where(a => a.Name.Equals("Diomedes Diaz")).FirstOrDefault()
            });
          
            _albums.Add(new Album{
                Name = "Tres Canciones",
                Id = Guid.NewGuid(),
                Artist = _Artists.Where(a => a.Name.Equals("Diomedes Diaz")).FirstOrDefault()
            });

            _albums.Add(new Album{
                Name = "Mr bad guy",
                Id = Guid.NewGuid(),
                Artist = _Artists.Where(a => a.Name.Equals("Freddie Mercury")).FirstOrDefault()
            });

            _albums.Add(new Album{
                Name = "Barcelona",
                Id = Guid.NewGuid(),
                Artist = _Artists.Where(a => a.Name.Equals("Freddie Mercury")).FirstOrDefault()
            });
        }

        public List<Artist> TodosLosArtists() => this._Artists;

        public List<Album> TodosLosAlbums() => this._albums;

        public Artist ArtistPorId(Guid id) => this._Artists.Where(a => a.Id.Equals(id)).FirstOrDefault();

        public List<Album> AlbumsPorArtist(Guid id) => this._albums.Where(a => a.Artist.Id.Equals(id)).ToList();

    }
}