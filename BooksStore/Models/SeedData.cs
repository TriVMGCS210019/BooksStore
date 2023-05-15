using Microsoft.EntityFrameworkCore;

namespace BooksStore.Models
{
    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            StoreDbContext context = app.ApplicationServices
             .CreateScope().ServiceProvider.GetRequiredService<StoreDbContext>();
            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }
            if (!context.Products.Any())
            {
                context.Products.AddRange(
                    new Product
                    {
                        Name = "Clean Code (A Handbook of Agile Software Craftsmanship",
                        Description = "High quality Book",
                        Category = "IT BOOK",
                        Price = 25
                    },
                    new Product
                    {
                        Name = "Python Crash Course 3rd",
                        Description = "High quality Book",
                        Category = "IT BOOK",
                        Price = 30
                    },
                    new Product
                    {
                        Name = "The Infinite Game by Simon Sinek",
                        Description = "The Infinite Game by Simon Sinek",
                        Category = "BUSINESS BOOK",
                        Price = 30
                    },
                    new Product
                    {
                        Name = "Permission to Screw Up: How I Learned to Lead by Doing (Almost) Everything Wrong by Kristen Hadeed",
                        Description = "Permission to Screw Up: How I Learned to Lead by Doing (Almost) Everything Wrong by Kristen Hadeed",
                        Category = "BUSINESS BOOK",
                        Price = 30
                    },
                    new Product
                    {
                        Name = "Zero to One: Notes on Start Ups, or How to Build the Future by Peter Thiel and Blake Masters",
                        Description = "Zero to One: Notes on Start Ups, or How to Build the Future by Peter Thiel and Blake Masters",
                        Category = "BUSINESS BOOK",
                        Price = 30
                    },
                    new Product
                    {
                        Name = "Profit First: Transform Your Business from a Cash-Eating Monster to a Money-Making Machine by Mike Michalowicz",
                        Description = "Profit First is one of the more practical books on business for beginners. Achieving and maintaining positive cash flow is one of the greatest challenges for emerging businesses.",
                        Category = "BUSINESS BOOK",
                        Price = 30
                    },
                    new Product
                    {
                        Name = "People Skills: How to Assert Yourself, Listen to Others, and Resolve Conflicts by Robert Bolton",
                        Description = "People Skills: How to Assert Yourself, Listen to Others, and Resolve Conflicts by Robert Bolton",
                        Category = "BUSINESS BOOK",
                        Price = 30
                    }
                    );
                    context.SaveChanges();
            }
        }
    }
}
