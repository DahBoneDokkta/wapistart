using System.Collections.Generic;
using System.Threading.Tasks;
using Models;
using DbModels;
using DbContext;
using Seido.Utilities.SeedGenerator;
using Microsoft.EntityFrameworkCore;

namespace Services
{
    public class csAttractionService : IAttractionService
    {
        private readonly csMainDbContext _context;
        private readonly csSeedGenerator _seeder;

        public csAttractionService(csMainDbContext context, csSeedGenerator seeder)
        {
            _context = context;
            _seeder = seeder;
        }

        public async Task<List<IAttraction>> GetAttractionsAsync(int count)
        {
            return await _context.Attractions.Take(count).ToListAsync<IAttraction>();
        }

        public async Task SeedAttractionsAsync(int count)
        {
            var attractions = _seeder.ItemsToList<csAttractionDbM>(count);
            foreach (var attraction in attractions)
            {
                attraction.IsTestData = true;
            }
            await _context.Attractions.AddRangeAsync(attractions);
            await _context.SaveChangesAsync();
        }

        public async Task ClearTestDataAsync()
        {
            var testAttractions = _context.Attractions.Where(u => u.IsTestData);
            _context.Attractions.RemoveRange(testAttractions);
            await _context.SaveChangesAsync();
        }

    }
}