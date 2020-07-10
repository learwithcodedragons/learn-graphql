using System.Collections.Generic;
using QuoteOfTheDay.Domain;

namespace QuoteOfTheDay.Data
{
    public class CategoryRepository
    {
        private readonly QuoteOfTheDayDbContext _dbContext;

        public CategoryRepository(QuoteOfTheDayDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Category> GetAll()
        {
            return _dbContext.Categories;
        }
    }
}