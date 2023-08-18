using BcgxCodingChallenge.DataAccess.Repositories;

namespace BcgxCodingChallenge.Services;

public class ShoppingService : IShoppingService
{
    private readonly IWatchRepository _watchRepository;
    private readonly ILogger<ShoppingService> _logger;

    public ShoppingService(IWatchRepository watchRepository, ILogger<ShoppingService> logger) 
    {
        _watchRepository = watchRepository;
        _logger = logger;
    }

    public async Task<string?> CalculateCost(IEnumerable<string> watchCodes)
    {
        if (IsValidInput(watchCodes) == false)
        {
            return null;
        }

        var watchModelsInCart = (await _watchRepository.GetAllAsync()).Where(x => watchCodes.Contains(x.Code));
        var totalCost = 0;

        foreach (var modelOfWatch in watchModelsInCart)
        {
            if (modelOfWatch.DiscountPrice != null && modelOfWatch.DiscountUnits != null)
            {
                var countOfWatchModel = watchCodes.Count(x => x.Equals(modelOfWatch.Code));
                var numberOfFullPriceWatches = countOfWatchModel % modelOfWatch.DiscountUnits.Value;
                var costOfFullPriceWatches = numberOfFullPriceWatches * modelOfWatch.Price;
                var costOfDiscountedWatches = ((countOfWatchModel - numberOfFullPriceWatches) / modelOfWatch.DiscountUnits.Value) * modelOfWatch.DiscountPrice.Value;
                totalCost += costOfFullPriceWatches + costOfDiscountedWatches;
            }
            else
            {
                totalCost += watchCodes.Count(x => x.Equals(modelOfWatch.Code)) * modelOfWatch.Price;
            }
        }

        return $"{{ \"price\": {totalCost} }}";
    }

    private bool IsValidInput(IEnumerable<string> watchCodes)
    {
        foreach (var watchCode in watchCodes) 
        {
            if (watchCode.All(char.IsDigit) == false)
            {
                _logger.LogError($"Invalid user input, non-numeric character detected: {watchCode}");
                return false;
            }
            else if (watchCode.Length != 3)
            {
                _logger.LogError($"Invalid user input, each code must be three digits: {watchCode}");
                return false;
            }
        }

        return true;
    }
}
