using Microsoft.Extensions.Configuration;

namespace QuoteOfTheDay.Data
{
    public class BaseRepository
    {
        protected readonly string  ConnectionString;

        public BaseRepository(IConfiguration configuration)
        {
            ConnectionString = configuration["connectionStrings:DefaultConnection"];
        }

    }
}
