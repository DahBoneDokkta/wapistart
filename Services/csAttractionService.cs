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

    public async Task<List<IAttraction>> RetrieveAttractionsAsync(int count) 
    {
        return await _repo.GetFilteredAttractionsAsync(count);
    }

    public async Task<IAttraction> FetchAttractionByIdAsync(Guid id) 
    {
        return await _repo.GetSingleAttractionAsync(id);
    }

    public async Task<List<IAttraction>> GetAttractionsWithoutCommentsAsync() 
    {
        return await _repo.GetAttractionsWithNoCommentAsync();
    }

    public async Task<IAttraction> RemoveAttractionByIdAsync(Guid id) 
    {
        return await _repo.DeleteAttractionAsync(id);
    }

    public async Task<IAttraction> RemoveAllSeededAttractionsAsync(bool seeded) // Korrigerat typografiskt fel
    {
        return await _repo.DeleteAllSeededData(seeded);
    }

    public async Task Seed(int count) 
    {
        await _repo.Seed(count);
    }
}
