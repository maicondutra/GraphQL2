using ApiQL.Models;
using GraphQL.Types;

namespace ApiQL.Schema.Types {
    
    public class ArtistType : ObjectGraphType<Artist> {
    
        public ArtistType()
        {
            this.Name = "Artist";
            Field(_ => _.Id).Description("Id del autor");
            Field(_ => _.Gender).Description("Genero musical de autor");
            Field(_ => _.Name).Description("Nombre del autor");
        }
    
    }
    
}