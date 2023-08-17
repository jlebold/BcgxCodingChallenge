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
        modelBuilder.Entity<Watch>().ToTable("Watch");
    }
}
