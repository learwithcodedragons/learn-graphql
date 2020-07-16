using GraphQL.Types;
using QuoteOfTheDay.Data;
using QuoteOfTheDay.Domain;

namespace QuoteOfTheDay.GraphQL.Types
{
    public class QuoteMutation : ObjectGraphType
    {
        public QuoteMutation(QuoteRepository quoteRepository)
        {
            FieldAsync<QuoteType>(
                "createQuote",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<QuoteInputType>> {Name = "quote"}),
                resolve: async context =>
                {
                    var quote = context.GetArgument<Quote>("quote");
                    return await context.TryAsyncResolve(
                        async c => await quoteRepository.AddQuote(quote));
                });
        }
    }
}