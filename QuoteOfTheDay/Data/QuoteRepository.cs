using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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

        public Quote GetById(int id)
        {
            return _dbContext.Find<Quote>(id);
        }

        public async Task<Quote> AddQuote(Quote quote)
        { 
             _dbContext.Add<Quote>(quote);
            await _dbContext.SaveChangesAsync();
            return quote;
        }
    }
}
