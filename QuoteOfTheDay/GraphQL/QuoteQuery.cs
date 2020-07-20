using System.Data.SqlClient;
using System.Linq;
using Dapper.GraphQL;
using GraphQL.Types;
using Microsoft.Extensions.Configuration;
using QuoteOfTheDay.Domain;
using QuoteOfTheDay.GraphQL.Types;
using QuoteOfTheDay.Mapper;

namespace QuoteOfTheDay.GraphQL
{
    public class QuoteQuery : ObjectGraphType
    {
        public QuoteQuery(IQueryBuilder<Quote> quoteQueryBuilder, 
            IConfiguration configuration)
        {
            Field<ListGraphType<QuoteType>>(
                "quotes",
                description: "A list of quotes",
                resolve: context =>
                {
                    // Create an alias for the 'Quotes' table.
                    var alias = "quotes";
                    // Add the 'Quotes' table to the FROM clause in SQL
                    var query = SqlBuilder
                        .From($"Quotes {alias}")
                        .OrderBy($"{alias}.id");

                    // Build the query, using the GraphQL query and SQL table alias.
                    query = quoteQueryBuilder.Build(query, context.FieldAst, alias);

                    // The current SQL query if author and text requested in GraphQL query is:
                    // SELECT quotes.Author, quotes.Text
                    // FROM Quotes quotes
                    var quoteMapper = new QuoteEntityMapper();

                    using var connection = new SqlConnection(configuration["ConnectionStrings:DefaultConnection"]);
                    var results 
                        = query.Execute( connection, context.FieldAst, quoteMapper)
                            .Distinct();
                    return results;
                });

               Field<QuoteType>(
                   "quote",
                   arguments: new QueryArguments(
                       new QueryArgument<NonNullGraphType<IdGraphType>>
                       {
                           Name = "id"
                       }),
                   resolve: context =>
                   {
                       var alias = "quotes";
                       var id = context.GetArgument<int>("id");

                       var query = SqlBuilder
                           .From($"Quotes {alias}")
                           .OrderBy($"{alias}.id")
                           .Where($"{alias}.id = {id}");

                       query = quoteQueryBuilder.Build(query, context.FieldAst, alias);
                       var quoteMapper = new QuoteEntityMapper();

                       using var connection = new SqlConnection(configuration["ConnectionStrings:DefaultConnection"]);
                       var results
                           = query.Execute(connection, context.FieldAst, quoteMapper)
                               .Distinct().FirstOrDefault();
                       return results;
                   });


        }
    }
}