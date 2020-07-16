using GraphQL.DataLoader;
using GraphQL.Types;
using QuoteOfTheDay.Data;
using QuoteOfTheDay.Domain;

namespace QuoteOfTheDay.GraphQL.Types
{
    public class QuoteType : ObjectGraphType<Quote>
    {
        public QuoteType(CategoryRepository categoryRepository)
        {
            Field(t => t.Id);
            Field(t => t.Author).Description("The name of the person that the quote is attributed to");
            Field(t => t.Text).Description("The text of the quote");
            Field<CategoryType>("category", resolve: context => categoryRepository.GetByQuoteId(context.Source.Id));
        }
    }
}