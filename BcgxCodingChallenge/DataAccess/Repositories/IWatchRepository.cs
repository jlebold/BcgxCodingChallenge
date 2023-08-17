using BcgxCodingChallenge.Models.Dtos;

namespace BcgxCodingChallenge.DataAccess.Repositories;

public interface IWatchRepository
{
    public IEnumerable<WatchDto> GetWatchesByCodes(IEnumerable<string> watches);
}
