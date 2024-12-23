using Models;
using Configuration;
using Seido.Utilities.SeedGenerator;

namespace Services;


public interface IUserService 
{
    // public Task<List<IUser>> GetUsersAsync (int count);
    public Task<List<IUser>> GetAllUsersAsync(int count);
    public Task<IUser> DeleteUserAsync(Guid id);
    public Task Seed(int _count);
}

public interface ICommentService
{
    public Task<List<IComment>> GetCommentsAsync(int _count);
    public Task<IComment> DeleteCommentAsync(Guid id);
    public Task Seed(int _count);

}

public interface IAttractionService
{
    Task<List<IAttraction>> GetAllAttractionsAsync();
    Task<List<IAttraction>> GetFilteredAttractionsAsync(int _count, string _category, string _description, string _name, string _heading, string _city, string _country);
    Task<IAttraction> GetSingleAttractionAsync(Guid id);
    Task<List<IAttraction>> GetAttractionsWithoutCommentsAsync();
    // Task<IAttraction> DeleteAttractionAsync(Guid id);
    Task DeleteAllSeededData(bool seeded);
    Task Seed(int _count);
}

public interface ICityService
{
    public Task<List<ICity>> RandomCity(int _count);
    public Task<ICity> DeleteCity(Guid id);
    public Task Seed(int _count);
}

public interface ICountryService
{
    public Task<List<ICountry>> GetCountriesAsync(int _count);
    public Task Seed(int _count);
}