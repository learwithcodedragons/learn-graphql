using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
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

        public Category GetById(int id)
        {
            var category = _dbContext.Find<Category>(id);
            return category;
        }

        public Category GetByQuoteId(int id)
        {
            var category = _dbContext.Quotes.Include(q => q.Category)
                .SingleOrDefault(q => q.Id == id)
                ?.Category;
             return category;
        }
    }
}