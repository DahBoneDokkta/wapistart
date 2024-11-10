using Models;
using Configuration;
using Seido.Utilities.SeedGenerator;

namespace Services;


public interface IUserService 
{
    public Task<List<IUser>> GetUsersAsync (int _count);
    public Task Seed(int _count);
}

public interface ICommentService
{
    public Task<List<IComment>> GetCommentsAsync(int _count);
    public Task Seed(int _count);

}

public interface IAttractionService
{
    Task<List<IAttraction>> RetrieveAttractionsAsync(int count);
    Task<IAttraction> GetSingleAttractionAsync(Guid id);
    Task<List<IAttraction>> GetAttractionsWithoutCommentsAsync();
    Task<IAttraction> RemoveAttractionByIdAsync(Guid id);
    Task<IAttraction> RemoveAllSeededAttractionsAsync(bool isSeeded);
    Task Seed(int _count);
}

public interface ICityService
{
    public Task<List<ICity>> GetCitiesAsync(int _count);
    public Task Seed(int _count);
}

public interface ICountryService
{
    public Task<List<ICountry>> GetCountriesAsync(int _count);
    public Task Seed(int _count);
}