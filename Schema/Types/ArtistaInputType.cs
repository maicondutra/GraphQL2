using GraphQL.Types;

namespace ApiQL.Schema.Types
{
    public class ArtistaInputType : InputObjectGraphType
    {
        public ArtistaInputType()
        {
            Field<GuidGraphType>("id");
            Field<StringGraphType>("gender");
            Field<StringGraphType>("name");
        }
    }
}
