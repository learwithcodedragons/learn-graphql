using System.Collections.Generic;

namespace QuoteOfTheDay.Domain
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Quote> Quotes { get; set; }
    }
}