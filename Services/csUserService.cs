using System.Collections.Generic;
using System.Threading.Tasks;
using Models;
using DbModels;
using DbContext;
using Seido.Utilities.SeedGenerator;
using Microsoft.EntityFrameworkCore;

namespace Services
{
    public class csUserService : IUserService
    {
        private readonly csMainDbContext _context;
        private readonly csSeedGenerator _seeder;

        public csUserService(csMainDbContext context, csSeedGenerator seeder)
        {
            _context = context;
            _seeder = seeder;
        }

        public async Task<List<IUser>> GetUsersAsync(int count)
        {
            return await _context.Users.Take(count).ToListAsync<IUser>();
        }

        public async Task SeedUsersAsync(int count)
        {
            var users = _seeder.ItemsToList<csUserDbM>(count);
            foreach (var user in users)
            {
                user.IsTestData = true;
            }
            await _context.Users.AddRangeAsync(users);
            await _context.SaveChangesAsync();
        }

        public async Task ClearTestDataAsync()
        {
            var testUsers = _context.Users.Where(u => u.IsTestData);
            _context.Users.RemoveRange(testUsers);
            await _context.SaveChangesAsync();
        }
    }
}