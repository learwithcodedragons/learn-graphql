using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.Extensions.Configuration;
using QuoteOfTheDay.Domain;

namespace QuoteOfTheDay.Data
{
    public class CategoryRepository : BaseRepository
    {

        public CategoryRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public IEnumerable<Category> GetAll()
        {
            using SqlConnection connection = new SqlConnection(ConnectionString);
            var categories = connection.GetAll<Category>();
            return categories;
        }

        public Category GetById(int id)
        {
            using SqlConnection connection = new SqlConnection(ConnectionString);

            var category = connection.Get<Category>(id);
            return category;
        }

        public Category GetByQuoteId(int id)
        {
            const string sql = @"SELECT c.Id, c.Name FROM Quotes q
                                 JOIN Categories c
                                 ON  q.CategoryId = c.Id
                                 WHERE q.Id = @Id";
            
            using SqlConnection connection = new SqlConnection(ConnectionString);

            var category = connection.QueryFirst<Category>(sql, new { Id = id});
            return category;
        }
    }
}