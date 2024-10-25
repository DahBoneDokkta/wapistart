using Configuration;
using Models;
using DbModels;
using DbContext;
using Seido.Utilities.SeedGenerator;
using Microsoft.EntityFrameworkCore;

namespace DbRepos;

public class csCommentRepo : ICommentRepo
{

    private const string seedSource = "./friends-seeds1.json";

    public async Task<List<IComment>> Comments(int _count)
    {
        using (var db = csMainDbContext.DbContext("sysadmin"))
        {
             return await db.CommentText
                .Include(c => c.Attraction)
                .Take(_count)
                .Select(c => (IComment)c)
                .ToListAsync();
        }
    }

    public Task<List<IComment>> Comment(int _count)
    {
        throw new NotImplementedException();
    }

    public async Task Seed(int _count)
    {
        var fn = Path.GetFullPath(seedSource);
        var _seeder = new csSeedGenerator(fn);
        using (var db = csMainDbContext.DbContext("sysadmin"))
        {
            var attraction = _seeder.ItemsToList<csAttractionDbM>(5);
            var comments = _seeder.ItemsToList<csCommentDbM>(_count);

            foreach (var a in attraction)
            {
                a.CommentDbM = comments;
            }
            
            
            db.Attractions.AddRange(attraction);
            await db.SaveChangesAsync();
        }
    }
}
