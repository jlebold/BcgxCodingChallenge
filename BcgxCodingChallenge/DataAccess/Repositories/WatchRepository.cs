using BcgxCodingChallenge.DataAccess.Contexts;
using BcgxCodingChallenge.Models.Dtos;
using Microsoft.EntityFrameworkCore;

namespace BcgxCodingChallenge.DataAccess.Repositories;

public class WatchRepository : IWatchRepository
{
    private readonly ShoppingContext _context;

    public WatchRepository(ShoppingContext context)
    {
        _context = context;
    }

    public async Task<List<WatchDto>> GetAllAsync()
    {
        var watches = await _context.Watch.AsNoTracking().Select(x => new WatchDto
        {
            Id = x.Id,
            Code = x.Code,
            DiscountPrice = x.DiscountPrice,
            DiscountUnits = x.DiscountUnits,
            Name = x.Name,
            Price = x.Price,
        })
        .ToListAsync();

        return watches;
    }
}
