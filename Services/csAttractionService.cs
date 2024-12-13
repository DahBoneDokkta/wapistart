using Models;
using DbRepos;
using Microsoft.Extensions.Logging;

namespace Services;

public class csAttractionService : IAttractionService
{
    private IAttractionRepo _repo;
    private readonly ILogger<csAttractionService> _logger;

    public csAttractionService(IAttractionRepo repo, ILogger<csAttractionService> logger)
    {
        _repo = repo;
        _logger = logger;
    }

    public async Task<List<IAttraction>> GetAllAttractionsAsync()
    {
        try
        {
            _logger.LogInformation("Service: Fetching all attractions...");
            var result = await _repo.GetAllAttractionsAsync();
            _logger.LogInformation("Service: Successfully fetched {count} attractions", result.Count);

            return result;
        }
        catch (Exception ex)
        {
            _logger.LogError("Service error: {message}", ex.Message);
            throw new Exception("Error! Could not get all attractions.", ex);
        }
    }

    public async Task<List<IAttraction>> GetFilteredAttractionsAsync(int count, string category = null, string description = null, string name = null, string title = null, string city = null, string country = null) 
    {
        try
        {
            return await _repo.GetFilteredAttractionsAsync(count, category, description, name, title, city, country);
        }
        catch (Exception ex)
        {
            throw new Exception("Error! Could not get filtered attractions.", ex);
        }
    }

    public async Task<IAttraction> GetSingleAttractionAsync(Guid id) 
    {
        try
        {
            return await _repo.GetSingleAttractionAsync(id);
        }
        catch (Exception ex)
        {
            throw new Exception($"Error! Could not get attraction with ID: {id}", ex);
        }
    }

    public async Task<List<IAttraction>> GetAttractionsWithoutCommentsAsync() 
    {
        try
        {
            return await _repo.GetAttractionsWithNoCommentAsync();
        }
        catch (Exception ex)
        {
            throw new Exception("Error! Could not get attractions without comments.", ex);
        }
    }

    // public async Task<IAttraction> DeleteAttractionAsync(Guid id) 
    // {
    //     try
    //     {
    //         return await _repo.DeleteAttractionAsync(id);
    //     }
    //     catch (Exception ex)
    //     {
    //         throw new Exception($"Error! Could not delete attraction with ID: {id}", ex);
    //     }
    //     // return await _repo.DeleteAttractionAsync(id);
    // }

    public async Task DeleteAllSeededData(bool seeded)
    {
        try
        {
            _logger.LogInformation("Service: Deleting all seeded attractions...");
            await _repo.DeleteAllSeededData(seeded);
            _logger.LogInformation("Service: Successfully deleted all seeded attractions");
        }
        catch (Exception ex)
        {
            throw new Exception("Error! Could not delete all seeded attractions.", ex);
        }
    }

    public async Task Seed(int count) 
    {
        try
        {
            await _repo.Seed(count);
        }
        catch (Exception ex)
        {
            throw new Exception("Error! Could not seed attractions.", ex);
        }
    }
}
