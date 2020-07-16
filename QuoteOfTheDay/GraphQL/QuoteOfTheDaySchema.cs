using GraphQL;
using GraphQL.Types;
using QuoteOfTheDay.GraphQL.Types;

namespace QuoteOfTheDay.GraphQL
{
    public class QuoteOfTheDaySchema: Schema
    {
        public QuoteOfTheDaySchema(IDependencyResolver resolver): base(resolver)
        {
            Query = resolver.Resolve<QuoteQuery>();
            Mutation = resolver.Resolve<QuoteMutation>();
        }
    }
}
