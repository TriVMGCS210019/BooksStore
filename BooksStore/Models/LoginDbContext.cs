using Microsoft.EntityFrameworkCore;

namespace BooksStore.Models
{
    public class LoginDbContext : DbContext
    {
        public LoginDbContext(DbContextOptions<LoginDbContext> options)
            : base(options)
        {

        }

        public DbSet<UserLogin> UserLogin { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<UserLogin>(entity => {
                entity.HasKey(k => k.id);
            });
        }
    }
}