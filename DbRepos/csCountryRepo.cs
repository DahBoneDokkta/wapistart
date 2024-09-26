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

    public async Task<List<ICountry>> Countries(int _count)
    {
        using (var db = csMainDbContext.DbContext("sysadmin"))
        {
            return await db.Country.Include(a => a.CityDbM).Take(_count).ToListAsync<ICountry>();
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

            foreach (var a in cities)
            {
                a.CountryDbM = _seeder.FromList(country);
            }
            
            
            db.Country.AddRange(country);
            await db.SaveChangesAsync();
        }
    }
}
