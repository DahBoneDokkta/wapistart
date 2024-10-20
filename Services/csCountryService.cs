using System.Collections.Generic;
using System.Threading.Tasks;
using Models;
using DbModels;
using DbContext;
using Seido.Utilities.SeedGenerator;
using Microsoft.EntityFrameworkCore;

namespace Services
{
    public class csCountryService : ICountryService
    {
        private readonly csMainDbContext _context;
        private readonly csSeedGenerator _seeder;

        public csCountryService(csMainDbContext context, csSeedGenerator seeder)
        {
            _context = context;
            _seeder = seeder;
        }

        public async Task<List<ICountry>> GetCountriesAsync(int count)
        {
            return await _context.Countries.Take(count).ToListAsync<ICountry>();
        }

        public async Task SeedCountriesAsync(int count)
        {
            var countries = _seeder.ItemsToList<csCountryDbM>(count);
            foreach (var country in countries)
            {
                country.IsTestData = true;
            }
            await _context.Countries.AddRangeAsync(countries);
            await _context.SaveChangesAsync();
        }

        public async Task ClearTestDataAsync()
        {
            var testCountries = _context.Countries.Where(u => u.IsTestData);
            _context.Countries.RemoveRange(testCountries);
            await _context.SaveChangesAsync();
        }

    }
}