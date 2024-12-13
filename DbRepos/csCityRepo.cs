using Models;
using DbModels;
using DbContext;
using DbRepos;
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

        // Slå ihop Cities och City till en metod för att hämta städer
        public async Task<List<ICity>> GetCities(int count)
        {
            using (var db = csMainDbContext.DbContext("sysadmin"))
            {
                return await db.Cities
                    .Include(c => c.CountryDbM)
                    .Include(c => c.AttractionDbM)
                    .Take(count)
                    .Cast<ICity>()
                    .ToListAsync();
            }
        }

        public async Task<ICity> DeleteCityAsync(Guid id)
        {
            using (var db = csMainDbContext.DbContext("sysadmin"))
            {
                var cityToDelete = await db.Cities.FindAsync(id);
                if (cityToDelete is null)
                {
                    throw new ArgumentException($"The City with ID {id} does not exist.");
                }

                try
                {
                    db.Cities.Remove(cityToDelete);
                    await db.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    throw new InvalidOperationException("An error occurred while trying to delete the city.", ex);
                }

                return cityToDelete;
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
