using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuoteOfTheDay.Domain;

namespace QuoteOfTheDay.Data
{
    public class QuoteRepository
    {
        private readonly QuoteOfTheDayDbContext _dbContext;

        public QuoteRepository(QuoteOfTheDayDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Quote> GetAll()
        {
            return _dbContext.Quotes;
        }
    }
}
