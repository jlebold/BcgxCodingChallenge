using BcgxCodingChallenge.DataAccess.Contexts;
using BcgxCodingChallenge.Models.Entities;

namespace BcgxCodingChallenge.DataAccess;

public static class DatabaseConstructor
{
    public static void Create(ShoppingContext context)
    {
        context.Database.EnsureCreated();

        if (context.Watch.Any())
        {
            return;
        }

        var watches = new Watch[]
        {
            new () { Name = "Rolex", Code = "001", Price = 100, DiscountPrice = 200, DiscountUnits = 3, },
            new () { Name = "Michael Kors", Code = "002", Price = 80, DiscountPrice = 120, DiscountUnits = 2, },
            new () { Name = "Swatch", Code = "003", Price = 50, DiscountPrice = null, DiscountUnits = null, },
            new () { Name = "Casio", Code = "004", Price = 30, DiscountPrice = null, DiscountUnits = null, },
        };

        foreach (var watch in watches)
        {
            context.Watch.Add(watch);
        }

        context.SaveChanges();
    }
}
