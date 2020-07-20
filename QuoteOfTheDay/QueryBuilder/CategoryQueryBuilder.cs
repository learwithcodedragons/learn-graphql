
using Dapper.GraphQL;
using GraphQL.Language.AST;
using QuoteOfTheDay.Domain;

namespace QuoteOfTheDay.QueryBuilder
{
    public class CategoryQueryBuilder : IQueryBuilder<Category>
    {
        public SqlQueryContext Build(SqlQueryContext query, IHaveSelectionSet context, string alias)
        {
            query.Select($" {alias}.id");
            query.SplitOn<Category>("Id");

            var fields = context.GetSelectedFields();

            if (fields.ContainsKey("name"))
            {
                query.Select($"{alias}.Name");
            }

            return query;
        }
    }
}