using Dapper.GraphQL;
using GraphQL.Language.AST;
using QuoteOfTheDay.Domain;

namespace QuoteOfTheDay.QueryBuilder
{
    public class QuoteQueryBuilder : IQueryBuilder<Quote>
    {
        private readonly IQueryBuilder<Category> _categoryQueryBuilder;

        public QuoteQueryBuilder(
            IQueryBuilder<Category> categoryQueryBuilder)
        {
            _categoryQueryBuilder = categoryQueryBuilder;
        }
        public SqlQueryContext Build(SqlQueryContext query, IHaveSelectionSet context, string alias)
        {
            query.Select($" {alias}.id");
            query.SplitOn<Quote>("Id");

            var fields = context.GetSelectedFields();

            if (fields.ContainsKey("author"))
            {
                query.Select($"{alias}.Author");
            }

            if (fields.ContainsKey("text"))
            {
                query.Select($"{alias}.Text");
            }

            if (fields.ContainsKey("category"))
            {
                // select category.id, category.name 
                // from Quote quote 
                // join Category category
                // on quote.categoryId = categoryId 
                
                var categoryAlias = $"category";
                query.LeftJoin($"Categories {categoryAlias} on {alias}.categoryId = {categoryAlias}.Id");
                query = _categoryQueryBuilder.Build(query, fields["category"], categoryAlias);
            }

            return query;
        }

        
    }
}