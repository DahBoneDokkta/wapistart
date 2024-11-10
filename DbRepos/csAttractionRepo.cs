using Configuration;
using Models;
using DbModels;
using DbContext;
using Seido.Utilities.SeedGenerator;
using Microsoft.EntityFrameworkCore;

namespace DbRepos;

public class csAttractionRepo : IAttractionRepo
{

    private const string seedSource = "./friends-seeds1.json";

    public async Task<List<IAttraction>> GetFilteredAttractionsAsync(
        int count,
        string category = null,
        string description = null,
        string name = null,
        string title = null,
        string city = null,
        string country = null)
    {
        try
        {
            using (var db = csMainDbContext.DbContext("sysadmin"))
            {
            IQueryable<IAttraction> query = db.Attractions.AsNoTracking()
            .Include(a => a.City)
            .Include(a => a.CityDbM.Country)
            .Include(a => a.CommentDbM);

            // Filtrering
            if (!string.IsNullOrEmpty(category))
                query = query.Where(a => a.Category.ToLower().Contains(category.ToLower()));
            if (!string.IsNullOrEmpty(description))
                query = query.Where(a => a.Description.ToLower().Contains(description.ToLower()));
            if (!string.IsNullOrEmpty(name))
                query = query.Where(a => a.Name.ToLower().Contains(name.ToLower()));
            if (!string.IsNullOrEmpty(title))
                query = query.Where(a => a.Title.ToLower().Contains(title.ToLower()));
            if (!string.IsNullOrEmpty(country))
                query = query.Where(a => a.City.Name.ToLower().Contains(city.ToLower()));
            if (!string.IsNullOrEmpty(city))
                query = query.Where(a => a.City.Country.CountryName.ToLower().Contains(country.ToLower()));

            var filterResult = await query.Take(count).ToListAsync();

            return filterResult;
        }
        }
        catch(Exception ex)
        {
            throw new ArgumentException("Something went wrong", ex);
        }
    }

    public Task<List<IAttraction>> GetFilteredAttractionsAsync(int _count)
    {
        throw new NotImplementedException();
    }

    public async Task Seed(int _count)
    {
        var fn = Path.GetFullPath(seedSource);
        var _seeder = new csSeedGenerator(fn);
        using (var db = csMainDbContext.DbContext("sysadmin"))
        {
            var attraction = _seeder.ItemsToList<csAttractionDbM>(5);
            var cities = _seeder.ItemsToList<csCityDbM>(100);
            var users = _seeder.ItemsToList<csUserDbM>(50);
            var countries = _seeder.ItemsToList<csCountryDbM>(4);

            foreach (var a in attraction)
            {
                a.CountryDbM = _seeder.FromList(countries);
                a.CityDbM = _seeder.FromList(cities);
                a.CommentDbM = _seeder.ItemsToList<csCommentDbM>(_seeder.Next(0, 21));

                foreach (var c in a.CommentDbM ) 
                {
                c.User = _seeder.FromList(users);
                }
                foreach(var x in cities) 
                {
                x.CountryDbM = _seeder.FromList(countries);
                }

            }
            
            
            db.Attractions.AddRange(attraction);
            await db.SaveChangesAsync();
        }
    }
}
