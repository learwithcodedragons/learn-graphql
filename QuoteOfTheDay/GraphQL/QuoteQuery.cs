using GraphQL.Types;
using QuoteOfTheDay.Data;
using QuoteOfTheDay.GraphQL.Types;

namespace QuoteOfTheDay.GraphQL
{
    public class QuoteQuery : ObjectGraphType
    {
        public QuoteQuery(QuoteRepository quoteRepository)
        {
            Field<ListGraphType<QuoteType>>(
                "quotes",
                resolve: context => quoteRepository.GetAll());

            Field<QuoteType>(
                "quote",
                arguments: new QueryArguments( 
                    new QueryArgument<NonNullGraphType<IdGraphType>>
                    {
                        Name = "id"
                    }),
            resolve: context =>
                {
                    var id = context.GetArgument<int>("id");
                    return quoteRepository.GetById(id);
                });
        }
    }
}