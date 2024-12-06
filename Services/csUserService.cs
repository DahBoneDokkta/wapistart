using Models;
using DbRepos;
using Microsoft.Extensions.Logging;
using Seido.Utilities.SeedGenerator;
using DbModels;
using DbContext;

namespace Services
{
    public class csUserService : IUserService
    {
        private readonly IUserRepo _repo;
        private readonly ILogger<csUserService> _logger;
        private ILogger<csUserService> logger;
        private const string seedSource = "./friends-seeds1.json";
        public csUserService(IUserRepo repo)
        {
            _repo = repo;
            _logger = logger;
        }

        // public async Task<List<IUser>> GetUsersAsync(int count)
        // {
        //     try
        //     {
        //         return await _repo.GetUsersAsync(count);
        //     }
        //     catch (Exception ex)
        //     {
        //         throw new Exception("Error! Could not get users.", ex);
        //     }
        // }

        public async Task<List<IUser>> GetAllUsersAsync(int count)
        {
            try
            {
                return await _repo.GetAllUsersAsync(count);
            }
            catch (Exception ex)
            {
                throw new Exception("Error! Could not get all users.", ex);
            }
        }

        public async Task<IUser> DeleteUserAsync(Guid id)
        {
            try
            {
                return await _repo.DeleteUserAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error! Could not delete user with ID: {id}", ex);
            }
        }

        // public async Task Seed(int count)
        // {
        //     try
        //     {
        //         await _repo.Seed(count);
        //     }
        //     catch (Exception ex)
        //     {
        //         throw new Exception("Error! Could not create user.", ex);
        //     }
        // }

        public async Task Seed(int _count)
        {
            var fn = Path.GetFullPath(seedSource);
            var _seeder = new csSeedGenerator(fn);

            // Generera användare med hjälp av seedgeneratorn
            var users = _seeder.ItemsToList<csUserDbM>(_count);

            // Logga varje användare som skapats
            foreach (var user in users)
            {
                _logger.LogInformation($"Generated User: {user.Email}, {user.FirstName}");
            }

            // Lägg till användarna i databasen
            using (var db = csMainDbContext.DbContext("sysadmin"))
            {
                db.Users.AddRange(users);
                await db.SaveChangesAsync();
                _logger.LogInformation($"{_count} users seeded successfully.");
            }
        }
    }
}