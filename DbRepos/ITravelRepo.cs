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
        // Task<List<IUser>> GetUsersAsync(int count);
        Task<List<IUser>> GetAllUsersAsync(int count);
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
            string category,
            string description,
            string name,
            string title,
            string city,
            string country);

        Task<List<IAttraction>> GetAllAttractionsAsync();
        Task<IAttraction> GetSingleAttractionAsync(Guid id);
        Task<List<IAttraction>> GetAttractionsWithNoCommentAsync();
        // Task<IAttraction> DeleteAttractionAsync(Guid id);
        Task <IAttraction> DeleteAllSeededData(bool seeded);
        Task Seed(int count);
        
    }
}