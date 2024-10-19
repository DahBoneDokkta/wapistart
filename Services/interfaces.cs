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
    Task<List<ICommentService>> GetCommentsAsync(int _count);
    Task SeedCommentsAsync(int _count);
    Task ClearTestDataAsync();
}

public interface IAttractionService
{
    Task<List<IAttractionService>> GetAttractionsAsync(int _count);
    Task SeedAttractionsAsync(int _count);
    Task ClearTestDataAsync();
}

public interface ICityService
{
    Task<List<ICityService>> GetCitiesAsync(int _count);
    Task SeedCitiesAsync(int _count);
    Task ClearTestDataAsync();
}

public interface ICountryService
{
    Task<List<ICountryService>> GetCountriesAsync(int _count);
    Task SeedCountriesAsync(int _count);
    Task ClearTestDataAsync();
}