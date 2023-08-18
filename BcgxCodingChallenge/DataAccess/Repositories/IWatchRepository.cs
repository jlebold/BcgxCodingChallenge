using BcgxCodingChallenge.Models.Dtos;

namespace BcgxCodingChallenge.DataAccess.Repositories;

public interface IWatchRepository
{
    public Task<List<WatchDto>> GetAllAsync();
}
