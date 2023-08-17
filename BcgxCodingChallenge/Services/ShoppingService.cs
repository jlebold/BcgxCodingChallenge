using BcgxCodingChallenge.DataAccess.Repositories;

namespace BcgxCodingChallenge.Services;

public class ShoppingService : IShoppingService
{
    private readonly IWatchRepository _watchRepository;

    public ShoppingService(IWatchRepository watchRepository) 
    {
        _watchRepository = watchRepository;
    }

    public string? CalculateCost(IEnumerable<string> watchCodes)
    {
        if (IsValidInput(watchCodes) == false)
        {
            return null;
        }

        var watches = _watchRepository.GetWatchesByCodes(watchCodes);

        CalculateDiscounts(watchCodes);
        return null;

    }

    private bool IsValidInput(IEnumerable<string> watchIds)
    {
        throw new NotImplementedException();
    }

    private int CalculateDiscounts(IEnumerable<string> watchIds) 
    {
        throw new NotImplementedException();
    }
}
