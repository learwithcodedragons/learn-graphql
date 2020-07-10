using System.Collections;
using System.Collections.Generic;

namespace QuoteOfTheDay.Domain
{
    public class Category
    {
        public int Id { get; set; }
        public QuoteCategory QuoteCategory { get; set; }
        public ICollection<Quote> Quotes { get; set; }
    }
}