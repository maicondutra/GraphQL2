using ApiQL.Models;
using ApiQL.Schema.Types;
using ApiQL.Services;
using GraphQL;
using GraphQL.Types;

namespace ApiQL.Schema.Queries
{
    public class ArtistQuery : ObjectGraphType
    {
        public ArtistQuery(ArtistService _service)
        {
            //busca todos os artistas
            Field<ListGraphType<ArtistType>>(name: "Artists", resolve: context => _service.ListArtists());
            
            //busca todos os albuns
            Field<ListGraphType<AlbumType>>(name: "albums", resolve: context => _service.ListAlbums());

            //lista artistas por id
            Field<ArtistType>(name: "Artist", arguments: 
             new QueryArguments(new QueryArgument<GuidGraphType> { Name = "id" }),
             resolve: context => _service.ArtistForId(context.GetArgument<System.Guid>("id")));

            //lista albus por artistas pelo id do artista
            Field<ListGraphType<AlbumType>>(name: "por_Artist", arguments: 
             new QueryArguments(new QueryArgument<GuidGraphType> { Name = "id" }),
             resolve: context => _service.AlbumForArtist(context.GetArgument<System.Guid>("id")));

            //teste de ADD Artista
            Field<ArtistType>(name: "ADDArtist", arguments:
            new QueryArguments(new QueryArgument<ArtistaInputType> { Name = "artist" }),
            resolve: context =>
            {
                 return _service.ADDArt(context.GetArgument<Artist>("artist"));
            });

            //Teste de delete Artist
            Field<StringGraphType>(name: "deleteArtist", arguments:
            new QueryArguments(new QueryArgument<GuidGraphType> { Name = "id" }),
            resolve: context =>
            {
                _service.DeleteArt(context.GetArgument<System.Guid>("id"));
                return "deletado";
            });

            //teste de update do artista
            Field<ArtistType>(name: "UpdateArtist", arguments:
            new QueryArguments(new QueryArgument<GuidGraphType> { Name = "id" }, new QueryArgument<ArtistaInputType> { Name = "artist"}),
            resolve: context => _service.UpdateArt(context.GetArgument<System.Guid>("id"), context.GetArgument<Artist>("artist")));
 

        }
    }
}