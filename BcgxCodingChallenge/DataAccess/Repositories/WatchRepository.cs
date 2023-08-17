using BcgxCodingChallenge.DataAccess.Contexts;
using BcgxCodingChallenge.Models.Dtos;
using BcgxCodingChallenge.Models.Entities;

namespace BcgxCodingChallenge.DataAccess.Repositories;

public class WatchRepository : IWatchRepository
{
    private readonly ShoppingContext _context;

    public WatchRepository(ShoppingContext context)
    {
        _context = context;
    }

    public IEnumerable<WatchDto> GetWatchesByCodes(IEnumerable<string> watchCodes)
    {
        throw new NotImplementedException();
    }
}
