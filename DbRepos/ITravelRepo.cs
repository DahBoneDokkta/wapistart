using Models;
using DbModels;
using DbContext;
namespace DbRepos;
using Seido.Utilities.SeedGenerator;
using Microsoft.EntityFrameworkCore;

public interface ICityRepo
{
    public Task<List<ICity>> City(int _count);
    public Task Seed(int _count);
}
public interface ICountryRepo
{
    public Task<List<ICountry>> Country(int _count);
    public Task Seed(int _count);
}
public interface IUserRepo
{
    public Task<List<IUser>> User(int _count);
    public Task Seed(int _count);
}
public interface ICommentRepo
{
    public Task<List<IComment>> Comment(int _count);
    public Task Seed(int _count);
}
public interface IAttractionRepo
{
    public Task<List<IAttraction>> Attraction(int _count);
    public Task Seed(int _count);
}