using ApiQL.Models;
using GraphQL.Types;

namespace ApiQL.Schema.Types {

     public class AlbumType : ObjectGraphType<Album> {
         
         public AlbumType()
         {
             this.Name = "album";
             Field(_ => _.Id).Description("Album id");
             Field(_ => _.Name).Description("Title of album");  
             Field(_ => _.Artist, type: typeof(ArtistType)).Description("Artist of album");         
         }

     }

}