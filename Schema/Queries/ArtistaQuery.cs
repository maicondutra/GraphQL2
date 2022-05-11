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
            Field<ListGraphType<ArtistType>>(name: "Artists", resolve: context => _service.ListarArtists());
            Field<ListGraphType<AlbumType>>(name: "albums", resolve: context => _service.ListartAlbums());
            Field<ArtistType>(name: "Artist", arguments: 
             new QueryArguments(new QueryArgument<GuidGraphType> { Name = "id" }),
             resolve: context => _service.ArtistPorId(context.GetArgument<System.Guid>("id")));
            Field<ListGraphType<AlbumType>>(name: "por_Artist", arguments: 
             new QueryArguments(new QueryArgument<GuidGraphType> { Name = "id" }),
             resolve: context => _service.AlbumPorArtist(context.GetArgument<System.Guid>("id")));            
        }
    }
}