using System.Collections.Generic;
using System.Threading.Tasks;
using Models;
using DbModels;
using DbContext;
using Seido.Utilities.SeedGenerator;
using Microsoft.EntityFrameworkCore;

namespace Services
{
    public class csCityService : ICityService
    {
        private readonly csMainDbContext _context;
        private readonly csSeedGenerator _seeder;

        public csCityService(csMainDbContext context, csSeedGenerator seeder)
        {
            _context = context;
            _seeder = seeder;
        }

        public async Task<List<ICity>> GetCitiesAsync(int count)
        {
            return await _context.Cities.Take(count).ToListAsync<ICity>();
        }

        public async Task SeedCitiesAsync(int count)
        {
            var cities = _seeder.ItemsToList<csCityDbM>(count);
            foreach (var city in cities)
            {
                city.IsTestData = true;
            }
            await _context.Cities.AddRangeAsync(cities);
            await _context.SaveChangesAsync();
        }

        public async Task ClearTestDataAsync()
        {
            var testCities = _context.Cities.Where(u => u.IsTestData);
            _context.Cities.RemoveRange(testCities);
            await _context.SaveChangesAsync();
        }

    }
}