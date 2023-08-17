using BcgxCodingChallenge.Models.Dtos;

namespace BcgxCodingChallenge.Services;

public interface IShoppingService
{
    string? CalculateCost(IEnumerable<string> watchIds);
}
