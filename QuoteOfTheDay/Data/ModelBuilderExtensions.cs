﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using QuoteOfTheDay.Domain;

namespace QuoteOfTheDay.Data
{
    public static class ModelBuilderExtensions
    {

        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new List<object>
                {
                    new 
                    {
                        Id = 1,
                        QuoteCategory = QuoteCategory.Inspirational
                    },
                    
                    new
                    {
                        Id = 2,
                        QuoteCategory = QuoteCategory.Funny
                    },
                    new
                    {
                        Id = 3,
                        QuoteCategory = QuoteCategory.Dark
                    },
                });
        


        modelBuilder.Entity<Quote>().HasData(
                new List<object>
                {
                    new
                    {
                        Id = 1,
                        Author = "Dr . Seuss",
                        Text = "You’re off to great places, today is your day. Your mountain is waiting, so get on your way.",
                        CategoryId = 1,
                    },
            
                    new
                    {
                        Id = 2,
                        Author = "Groucho Marx",
                        Text = "No one is perfect - that’s why pencils have erasers.",
                        CategoryId = 1,
                    },

                    new
                    {
                        Id = 3,
                        Author = "Wolfgang Riebe",
                        Text = "Marriage is the chief cause of divorce.",
                        CategoryId = 2,
                    }
                });
        }
    }
}