using GraphQL.Types;
using QuoteOfTheDay.Domain;

namespace QuoteOfTheDay.GraphQL.Types
{
    public class QuoteType : ObjectGraphType<Quote>
    {
        public QuoteType()
        {
            Field(quote => quote.Id);
            Field(quote => quote.Author).Description("The name of the person that the quote is attributed to");
            Field(quote => quote.Text).Description("The text of the quote");
            Field<CategoryType>(
                "category",
                "The type of quote",
                resolve: context => context.Source?.Category);
        }

    }
}