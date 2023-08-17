using BcgxCodingChallenge.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace BcgxCodingChallenge.DataAccess.Contexts;

public partial class ShoppingContext : DbContext
{
    public virtual DbSet<Watch> Watch { get; set; }

    public ShoppingContext(DbContextOptions<ShoppingContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //SeedData(modelBuilder);
        modelBuilder.Entity<Watch>().ToTable("Watch");
    }

    public void SeedData(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Watch>().HasData(
            new Watch
            {
                Id = 1,
                Name = "Rolex",
                DiscountPrice = 200
            });
    }
}
