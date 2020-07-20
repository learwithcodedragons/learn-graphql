using Dapper.GraphQL;
using QuoteOfTheDay.Domain;

namespace QuoteOfTheDay.Mapper
{
    public class QuoteEntityMapper : DeduplicatingEntityMapper<Quote>
    {
        public QuoteEntityMapper()
        {
            PrimaryKey = quote => quote.Id;
        }

        public override Quote Map(EntityMapContext context)
        {
            var quote = Deduplicate(context.Start<Quote>());

            var category = context.Next<Category>("category");
            
            quote.Category = quote.Category ?? category;

             return quote;
        }
    }
}