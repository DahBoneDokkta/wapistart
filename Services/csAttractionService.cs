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

    public async Task<List<IAttraction>> GetFilteredAttractionsAsync(int count, string category = null, string description = null, string name = null, string title = null, string city = null, string country = null) 
    {
        return await _repo.GetFilteredAttractionsAsync(count, category, description, name, title, city, country);
    }

    public async Task<IAttraction> GetSingleAttractionAsync(Guid id) 
    {
        return await _repo.GetSingleAttractionAsync(id);
    }

    public async Task<List<IAttraction>> GetAttractionsWithoutCommentsAsync() 
    {
        return await _repo.GetAttractionsWithNoCommentAsync();
    }

    public async Task<IAttraction> DeleteAttractionAsync(Guid id) 
    {
        return await _repo.DeleteAttractionAsync(id);
    }

    public async Task DeleteAllSeededAttractionsAsync()
    {
        await _repo.DeleteAllSeededAttractionsAsync();
    }

    public async Task Seed(int count) 
    {
        await _repo.Seed(count);
    }
}
