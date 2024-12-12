using Models;
using DbRepos;

namespace Services;

public class csAttractionService : IAttractionService
{
    private IAttractionRepo _repo;

    public csAttractionService(IAttractionRepo repo)
    {
        _repo = repo;
    }

    public async Task<List<IAttraction>> GetAllAttractionsAsync()
    {
        try
        {
            return await _repo.GetAllAttractionsAsync();
        }
        catch (Exception ex)
        {
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
        // return await _repo.GetFilteredAttractionsAsync(count, category, description, name, title, city, country);
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
        // return await _repo.GetSingleAttractionAsync(id);
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
        // return await _repo.GetAttractionsWithNoCommentAsync();
    }

    public async Task<IAttraction> DeleteAttractionAsync(Guid id) 
    {
        try
        {
            return await _repo.DeleteAttractionAsync(id);
        }
        catch (Exception ex)
        {
            throw new Exception($"Error! Could not delete attraction with ID: {id}", ex);
        }
        // return await _repo.DeleteAttractionAsync(id);
    }

    public async Task DeleteAllSeededAttractionsAsync()
    {
        try
        {
            await _repo.DeleteAllSeededAttractionsAsync();
        }
        catch (Exception ex)
        {
            throw new Exception("Error! Could not delete all seeded attractions.", ex);
        }
        // await _repo.DeleteAllSeededAttractionsAsync();
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
        // await _repo.Seed(count);
    }
}
