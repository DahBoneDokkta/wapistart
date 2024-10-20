using Models;
using Configuration;
using Seido.Utilities.SeedGenerator;

namespace Services;


public interface IUserService 
{
    Task<List<IUser>> GetUsersAsync (int _count);
    Task SeedUsersAsync(int _count);
    Task ClearTestDataAsync();
}

public interface ICommentService
{
    Task<List<IComment>> GetCommentsAsync(int _count);
    Task SeedCommentsAsync(int _count);
    Task ClearTestDataAsync();
}

public interface IAttractionService
{
    Task<List<IAttraction>> GetAttractionsAsync(int _count);
    Task SeedAttractionsAsync(int _count);
    Task ClearTestDataAsync();
}

public interface ICityService
{
    Task<List<ICity>> GetCitiesAsync(int _count);
    Task SeedCitiesAsync(int _count);
    Task ClearTestDataAsync();
}

public interface ICountryService
{
    Task<List<ICountry>> GetCountriesAsync(int _count);
    Task SeedCountriesAsync(int _count);
    Task ClearTestDataAsync();
}