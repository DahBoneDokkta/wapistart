using Models;
using DbModels;
using DbContext;
using Seido.Utilities.SeedGenerator;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DbRepos
{
    public class csCityRepo : ICityRepo
    {
        private const string seedSource = "./friends-seeds1.json";

        public async Task<List<ICity>> Cities(int _count)
        {
            using (var db = csMainDbContext.DbContext("sysadmin"))
            {
                return await db.Cities
                    .Include(c => c.CountryDbM)
                    .Include(c => c.Attractions)
                    .Take(_count)
                    .Cast<ICity>()
                    .ToListAsync();
            }
        }

        public async Task<List<ICity>> City(int count)
        {
            using (var db = csMainDbContext.DbContext("sysadmin"))
            {
                return await db.Cities
                    .Include(c => c.CountryDbM)
                    .Include(c => c.Attractions)
                    .Take(count)
                    .Cast<ICity>()
                    .ToListAsync();
            }
        }

        public async Task<ICity> DeleteCityAsync(Guid id)
        {
            using (var db = csMainDbContext.DbContext("sysadmin"))
            {
                var query = db.Cities.Where(a => a.CityId == id);
                var deletedCity = await query.FirstOrDefaultAsync<csCityDbM>();

                if (deletedCity is null)
                {
                    throw new ArgumentException($"The City with {id} does not exist.");
                }

                try
                {
                    db.Cities.Remove(deletedCity);
                    await db.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    throw new ArgumentException("Something went wrong.", ex);
                }

                return deletedCity;
            }
        }

        public async Task Seed(int count)
        {
            var fn = Path.GetFullPath(seedSource);
            var seeder = new csSeedGenerator(fn);
            using (var db = csMainDbContext.DbContext("sysadmin"))
            {
                var countries = seeder.ItemsToList<csCountryDbM>(count);
                var cities = seeder.ItemsToList<csCityDbM>(count);
                var attractions = seeder.ItemsToList<csAttractionDbM>(count);

                foreach (var city in cities)
                {
                    city.CountryDbM = seeder.FromList(countries);
                }

                db.Cities.AddRange(cities);
                db.Countries.AddRange(countries);
                await db.SaveChangesAsync();
            }
        }
    }
}