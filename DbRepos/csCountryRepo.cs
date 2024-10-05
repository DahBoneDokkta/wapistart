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
            return await db.Countries.Include(a => a.CitiesDbM).Take(_count).ToListAsync<ICountry>();
        }
    }

    public Task<List<ICountry>> Country(int _count)
    {
        throw new NotImplementedException();
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
            
            
            db.Countries.AddRange(country);
            await db.SaveChangesAsync();
        }
    }
}
