using GraphQL.Types;
using QuoteOfTheDay.Data;

namespace QuoteOfTheDay.GraphQL.Types
{
    public class QuoteQuery : ObjectGraphType
    {
        public QuoteQuery(QuoteRepository quoteRepository)
        {
            Field<ListGraphType<QuoteType>>(
                "quotes",
                resolve: context => quoteRepository.GetAll());
        }
    }
}