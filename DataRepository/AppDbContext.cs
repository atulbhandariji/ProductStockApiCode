using DataRepository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Model;

namespace DataRepository
{
    public class AppDbContext: DbContext, IAppDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Product> Products { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .Property(p => p.ProductId)
                .UseIdentityColumn(1, 1);
        }
    }
}