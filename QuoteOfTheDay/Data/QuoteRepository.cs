using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.Extensions.Configuration;
using QuoteOfTheDay.Domain;

namespace QuoteOfTheDay.Data
{
    public class QuoteRepository : BaseRepository
    {

        public QuoteRepository(IConfiguration configuration) : base(configuration)
        {

        }
        public IEnumerable<Quote> GetAll()
        {
            using SqlConnection connection = new SqlConnection(ConnectionString);
            const string sql = "SELECT * FROM Quotes";
            var quotes = connection.Query<Quote>(sql);
            return quotes;
        }

        public Quote GetById(int id)
        {
            using SqlConnection connection = new SqlConnection(ConnectionString);
            const string sql = @"SELECT * FROM Quotes
                        WHERE Id = @Id";
            var quote = connection.QueryFirst(sql, new { Id = id });
            return quote;
        }

        public async Task<Quote> AddQuote(Quote quote)
        {
            await using SqlConnection connection = new SqlConnection(ConnectionString);
            var id = await connection.InsertAsync(quote);

            quote.Id = id;
            return quote;
        }
    }
}
