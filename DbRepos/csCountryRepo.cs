using Configuration;
using Models;
using DbModels;
using DbContext;
using Seido.Utilities.SeedGenerator;
using Microsoft.EntityFrameworkCore;

namespace DbRepos;

public class csCountryRepo : ICountryRepo
{

    private const string seedSource = "./friends-seeds1.json";

    public async Task<List<ICountry>> GetCountries(int _count)
    {
        using (var db = csMainDbContext.DbContext("sysadmin"))
        {
            return await db.Countries
                .Include(c => c.CitiesDbM)
                .Take(_count)
                .Cast<ICountry>()
                .ToListAsync();
        }
    }

    public async Task Seed(int _count)
    {
        var fn = Path.GetFullPath(seedSource);
        var _seeder = new csSeedGenerator(fn);
        using (var db = csMainDbContext.DbContext("sysadmin"))
        {
            var country = _seeder.ItemsToList<csCountryDbM>(5);
            var cities = _seeder.ItemsToList<csCityDbM>(_count);
            var attractions = _seeder.ItemsToList<csAttractionDbM>(_count);

            foreach (var city in cities)
            {
                city.CountryDbM = _seeder.FromList(country);
            }
            
            
            db.Cities.AddRange(cities);
            db.Attractions.AddRange(attractions);
            await db.SaveChangesAsync();
        }
    }
}
