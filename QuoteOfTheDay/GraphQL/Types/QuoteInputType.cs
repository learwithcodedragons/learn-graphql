using GraphQL.Types;

namespace QuoteOfTheDay.GraphQL.Types
{
    public class QuoteInputType : InputObjectGraphType
    {
        public QuoteInputType()
        {
            Name = "quoteinput";
            Field<NonNullGraphType<StringGraphType>>("author");
            Field<NonNullGraphType<StringGraphType>>("text");
            Field<NonNullGraphType<IntGraphType>>("categoryid");
        }
    }
}