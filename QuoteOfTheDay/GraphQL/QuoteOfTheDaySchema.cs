using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Types;
using QuoteOfTheDay.Domain;
using QuoteOfTheDay.GraphQL.Types;

namespace QuoteOfTheDay.GraphQL
{
    public class QuoteOfTheDaySchema: Schema
    {
        public QuoteOfTheDaySchema(IDependencyResolver resolver): base(resolver)
        {
            Query = resolver.Resolve<QuoteQuery>();
        }
    }
}
