using ApiQL.Models;
using GraphQL.Types;

namespace ApiQL.Schema.Types {
    
    public class ArtistType : ObjectGraphType<Artist> {
    
        public ArtistType()
        {
            this.Name = "Artist";
            Field(_ => _.Id).Description("Id of author");
            Field(_ => _.Gender).Description("Gender musical of author");
            Field(_ => _.Name).Description("Name of author");
        }
    
    }
    
}