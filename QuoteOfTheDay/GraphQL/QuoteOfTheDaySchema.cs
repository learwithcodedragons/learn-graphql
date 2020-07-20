using GraphQL;
using GraphQL.Types;
using QuoteOfTheDay.GraphQL.Types;

namespace QuoteOfTheDay.GraphQL
{
    public class QuoteOfTheDaySchema: Schema
    {
        public QuoteOfTheDaySchema(QuoteQuery query, QuoteMutation mutation)
        {
            Query = query;
            Mutation = mutation;
        }
    }
}
