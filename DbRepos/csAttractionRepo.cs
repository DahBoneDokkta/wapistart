using Configuration;
using Models;
using DbModels;
using DbContext;
using Microsoft.AspNetCore.Mvc;
using Seido.Utilities.SeedGenerator;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DbRepos;

public class csAttractionRepo : IAttractionRepo
{
    private readonly ILogger<csAttractionRepo> _logger;
    public csAttractionRepo(ILogger<csAttractionRepo> logger)
    {
        _logger = logger;
    }

    private const string seedSource = "./friends-seeds1.json";

    public async Task<List<IAttraction>> GetAllAttractionsAsync()
        {
            try
            {
                using (var db = csMainDbContext.DbContext("sysadmin"))
                {
                    _logger.LogInformation("Fetching all attractions from database");

                var result = await db.Attractions
                    .Include(a => a.CityDbM)
                    .Include(a => a.CityDbM.CountryDbM)
                    .Include(a => a.CommentDbM)
                    .ToListAsync();

                _logger.LogInformation($"Fetched {result.Count} attractions");

                return result.ToList<IAttraction>();
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while getting all attractions");
                throw;
            }
        }

        public async Task<List<IAttraction>> GetFilteredAttractionsAsync(int count, string category, string description, string name, string title, string city, string country) 
        {
            try
            {
                using (var db = csMainDbContext.DbContext("sysadmin"))
                {
                IQueryable<IAttraction> query = db.Attractions.AsNoTracking()
                .Include(co => co.CommentDbM).ThenInclude(u => u.UserDbM)
                .Include(ci => ci.CityDbM)
                .Include(cy => cy.CountryDbM)

                .Where(x => x.Category.ToLower().Contains(category))
                .Where(x => x.Description.ToLower().Contains(description))
                .Where(x => x.Title.ToLower().Contains(title))
                .Where(x => x.Name.ToLower().Contains(name))
                .Where(x => x.Title.ToLower().Contains(title))
                .Where(x => x.CountryDbM.CountryName.ToLower().Contains(country))
                .Where(x => x.CityDbM.Name.ToLower().Contains(city))

                .Take(count);
                var filterResult = await query.ToListAsync();

            return filterResult;
        }

        }
        catch(Exception ex)
        {
            throw new ArgumentException("Something went wrong", ex);
        }
    }

    public async Task<IAttraction> GetSingleAttractionAsync(Guid id)
    {
        try
        {
            using (var db = csMainDbContext.DbContext("sysadmin"))
            {
                // Bygg en query som inkluderar alla relaterade entiteter
                var _query = db.Attractions
                    .Where(a => a.AttractionId == id)
                    .Include(a => a.CommentDbM)
                    .ThenInclude(u => u.UserDbM)
                    .Include(a => a.CityDbM)
                    .Include(a => a.CountryDbM);

                // Utför frågan och hämta listan
                var attractions = await _query.ToListAsync();

                // Kontrollera om vi har något resultat och returnera första
                if (attractions.Any())
                {
                    return attractions.First();  // Returnera första objektet från listan
                }

                // Om inget resultat hittas, kan du kasta ett undantag eller returnera null
                throw new ArgumentException("Attraction not found");
            }
        }
        catch (Exception ex)
        {
            // Hantera eventuella fel
            throw new ArgumentException("Something went wrong", ex.Message);
        }
    }

    public async Task<List<IAttraction>> GetAttractionsWithNoCommentAsync() 
    {
        try
        {
            using (var db = csMainDbContext.DbContext("sysadmin"))
            {
                // Skapa en query med AsNoTracking för bättre prestanda
                IQueryable<IAttraction> query = db.Attractions.AsNoTracking()
                    .Include(a => a.CommentDbM); // Inkludera kommentarer
            
                // Hämta alla attraktioner
                var attractions = await query.ToListAsync();
            
                // Filtrera de attraktioner som inte har några kommentarer
                var result = attractions.Where(a => a.Comment == null || a.Comment.Count == 0).ToList();
            
                return result;
            }
        }
        catch (Exception ex)
        {
            // Hantera eventuella fel
            throw new ArgumentException("Something went wrong", ex.Message);
        }
    }

    public async Task<IAttraction> DeleteAllSeededData(bool seeded) 
    {
        using(var db = csMainDbContext.DbContext("sysadmin")) 
        {
            db.CommentText.RemoveRange(db.CommentText.Where(c => c.Seeded == seeded));
            db.Users.RemoveRange(db.Users.Where(u => u.Seeded == seeded));
            db.Attractions.RemoveRange(db.Attractions.Where(a => a.Seeded == seeded));
            db.Cities.RemoveRange(db.Cities.Where(ci => ci.Seeded == seeded));
            db.Countries.RemoveRange(db.Countries.Where(co => co.Seeded == seeded));

            await db.SaveChangesAsync();

            return null;
        }
    }



// public async Task<IAttraction> DeleteAttractionAsync(Guid id) 
// {
//     using(var db = csMainDbContext.DbContext("sysadmin")) 
//     {
//         var _query = db.Attractions.Where(a => a.AttractionId == id);

//         var _deletedAttractrion = await _query.FirstOrDefaultAsync<csAttractionDbM>();

//         if (_deletedAttractrion is null) {
//             throw new ArgumentException($"The Attraction with {id} does not exist.");
//         }
//         try {
//             db.Attractions.RemoveRange(_deletedAttractrion);
//             await db.SaveChangesAsync();
//         } 
//         catch (Exception ex) {
//             throw new ArgumentException("Something went wrong.", ex.Message);
//         }

//         return _deletedAttractrion;
//     }
// }

    public async Task Seed(int _count)
    {
        var fn = Path.GetFullPath(seedSource);
        var _seeder = new csSeedGenerator(fn);
        using (var db = csMainDbContext.DbContext("sysadmin"))
        {
            var attraction = _seeder.ItemsToList<csAttractionDbM>(5);
            var cities = _seeder.ItemsToList<csCityDbM>(100);
            var users = _seeder.ItemsToList<csUserDbM>(50);
            var countries = _seeder.ItemsToList<csCountryDbM>(4);

                foreach(var city in cities) 
                {
                    city.CountryDbM = _seeder.FromList(countries);
                }

            foreach (var a in attraction)
            {
                a.CountryDbM = _seeder.FromList(countries);
                a.CityDbM = _seeder.FromList(cities);
                var com = _seeder.ItemsToList<csCommentDbM>(_seeder.Next(0, 21));
                a.CommentDbM = com;

                foreach (var c in a.CommentDbM ) 
                {
                    c.UserDbM = _seeder.FromList(users);
                }

            }
            
            db.Attractions.AddRange(attraction);
            await db.SaveChangesAsync();
        }
    }
}
