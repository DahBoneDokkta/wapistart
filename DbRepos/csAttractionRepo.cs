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
    
    public async Task<List<IAttraction>> GetFilteredAttractionsAsync(
        int count,
        string category = null,
        string description = null,
        string name = null,
        string title = null,
        string city = null,
        string country = null)
    {
        try
        {
            using (var db = csMainDbContext.DbContext("sysadmin"))
            {
            
            var query = db.Attractions.AsQueryable();
            // IQueryable<IAttraction> query = db.Attractions.AsNoTracking()
            // .Include(a => a.City)
            // .Include(a => a.CityDbM.Country)
            // .Include(a => a.CommentDbM);

            // Filtrering
            if (!string.IsNullOrEmpty(category))
            {
                query = query.Where(a => a.Category.ToLower().Contains(category.ToLower()));
            }
            if (!string.IsNullOrEmpty(description))
            {
                query = query.Where(a => a.Description.ToLower().Contains(description.ToLower()));
            }
            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(a => a.Name.ToLower().Contains(name.ToLower()));
            }
            if (!string.IsNullOrEmpty(title))
            {
                query = query.Where(a => a.Title.ToLower().Contains(title.ToLower()));
            }
            if (!string.IsNullOrEmpty(country))
            {
                query = query.Where(a => a.City.Name.ToLower().Contains(city.ToLower()));
            }
            if (!string.IsNullOrEmpty(city))
            {
                query = query.Where(a => a.City.Country.CountryName.ToLower().Contains(country.ToLower()));
            }
                
            
            query = query
                .Include(a => a.CityDbM)
                .Include(a => a.CityDbM.CountryDbM)
                .Include(a => a.CommentDbM);

            var filterResult = await query
                .Take(count)
                .ToListAsync();

            return filterResult.Cast<IAttraction>().ToList();
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
                    .Where(a => a.AttractionId == id)  // Filtrera på rätt AttractionId
                    .Include(a => a.CommentDbM)  // Inkludera kommentarer
                    .Include(a => a.CityDbM)  // Inkludera stad
                    .Include(a => a.CityDbM.Country)  // Inkludera land från City
                    .Include(a => a.City.Country);  // Inkludera land direkt från City

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



    // public async Task<IAttraction> GetSingleAttractionAsync(Guid id)
    // {
    //         using (var db = csMainDbContext.DbContext("sysadmin"))
    //         {
    //             return await db.Attractions
    //                 .Include(a => a.City)
    //                 .Include(a => a.CityDbM.Country)
    //                 .Include(a => a.City.Country)
    //                 .Include(a => a.CommentDbM)
    //                 // .Include(a => a.Comment)
    //                 .FirstOrDefaultAsync(a => a.AttractionId == id);
                    
    //         }
    // }

    // public async Task<List<IAttraction>> GetAttractionsWithNoCommentAsync()
    // {
    //         using (var db = csMainDbContext.DbContext("sysadmin"))
    //         {
    //             var attractions = await db.Attractions
    //             // return await db.Attractions
    //                 .Include(a => a.City)
    //                 .Include(a => a.CityDbM.Country)
    //                 .Include(a => a.City.Country)// Inkludera land
    //                 .Include(a => a.CommentDbM)
    //                 .Include(a => a.Comment) // Inkludera kommentarer
    //                 .Where(a => !a.CommentDbM.Any())
    //                 .Select(a => (IAttraction)a)
    //                 .ToListAsync();

    //             return attractions.Select(a => (IAttraction)a).ToList();
    //         }
    // }

    // public async Task<IAttraction> DeleteAttractionAsync(Guid id)
    // {
    //         using (var db = csMainDbContext.DbContext("sysadmin"))
    //         {
    //             var attraction = await db.Attractions.FindAsync(id);
    //             if (attraction != null)
    //             {
    //                 db.Attractions.Remove(attraction);
    //                 await db.SaveChangesAsync();
    //             }
    //             return attraction;
    //         }
    // }

    public async Task<IAttraction> DeleteAttractionAsync(Guid id)
    {
        try
        {
            await using (var db = csMainDbContext.DbContext("sysadmin"))
            {
                // Hitta attraktionen med FindAsync
                var attraction = await db.Attractions.FindAsync(id);

                if (attraction is null)
                {
                    throw new KeyNotFoundException($"The attraction with ID {id} does not exist.");
                }

                // Ta bort attraktionen
                db.Attractions.Remove(attraction);
                await db.SaveChangesAsync();

                return attraction;
            }
        }
        catch (Exception ex)
        {
            throw new Exception("An error occurred while deleting the attraction.", ex);
        }
    }


    public async Task<IAttraction> DeleteAllSeededData(bool seeded) 
    {
        using(var db = csMainDbContext.DbContext("sysadmin")) 
        {
            db.Attractions.RemoveRange(db.Attractions.Where(a => a.Seeded == seeded ));
            db.CommentText.RemoveRange(db.CommentText.Where(c => c.Seeded == seeded ));
            db.Users.RemoveRange(db.Users.Where(u => u.Seeded == seeded ));
            db.Cities.RemoveRange(db.Cities.Where(ci => ci.Seeded == seeded ));
            db.Countries.RemoveRange(db.Countries.Where(co => co.Seeded == seeded ));

            await db.SaveChangesAsync();

            return null;        
        }
    }

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
