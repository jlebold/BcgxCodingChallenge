using BcgxCodingChallenge.Models.Dtos;

namespace BcgxCodingChallenge.Services;

public interface IShoppingService
{
    Task<string?> CalculateCost(IEnumerable<string> watchIds);
}
