using Models;
using Configuration;
using Seido.Utilities.SeedGenerator;

namespace Services;


public interface IUserService {

    public Task<List<IUserService>> Users(int _count);
    public Task Seed(int _count);
}

public interface ICommentService
{
    public Task<List<ICommentService>> Comments(int _count);
    public Task Seed(int _count);
}

public interface IAttractionService
{
    public Task<List<IAttractionService>> Attractions(int _count);
    public Task Seed(int _count);
}

public interface ICityService
{
    public Task<List<ICityService>> Cities(int _count);
    public Task Seed(int _count);
}

public interface ICountryService
{
    public Task<List<ICountryService>> Countries(int _count);
    public Task Seed(int _count);
}