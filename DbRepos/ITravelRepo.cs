using Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DbRepos
{
    public interface ICityRepo
    {
        Task<List<ICity>> GetCities(int count);
        Task<ICity> DeleteCityAsync(Guid id);
        Task Seed(int count);
    }

    public interface ICountryRepo
    {
        Task<List<ICountry>> GetCountries(int count);
        Task Seed(int count);
    }

    public interface IUserRepo
    {
        Task<List<IUser>> GetUsers(int count);
        Task<IUser> DeleteUserAsync(Guid id);
        Task Seed(int count);
    }

    public interface ICommentRepo
    {
        Task<List<IComment>> GetComments(int count);
        Task<IComment> DeleteCommentAsync(Guid id);
        Task Seed(int count);
    }

    public interface IAttractionRepo
    {
        Task<List<IAttraction>> GetFilteredAttractionsAsync(
            int count,
            string category = null,
            string description = null,
            string name = null,
            string title = null,
            string city = null,
            string country = null);
        Task Seed(int count);
    }
}