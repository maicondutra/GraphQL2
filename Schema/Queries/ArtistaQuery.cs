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
            Field<ListGraphType<ArtistType>>(name: "Artists", resolve: context => _service.ListArtists());
            Field<ListGraphType<AlbumType>>(name: "albums", resolve: context => _service.ListAlbums());

            Field<ArtistType>(name: "Artist", arguments: 
             new QueryArguments(new QueryArgument<GuidGraphType> { Name = "id" }),
             resolve: context => _service.ArtistForId(context.GetArgument<System.Guid>("id")));

            Field<ListGraphType<AlbumType>>(name: "por_Artist", arguments: 
             new QueryArguments(new QueryArgument<GuidGraphType> { Name = "id" }),
             resolve: context => _service.AlbumForArtist(context.GetArgument<System.Guid>("id")));            
        }
    }
}