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

    public async Task<List<IComment>> GetComments(int _count)
    {
        using (var db = csMainDbContext.DbContext("sysadmin"))
        {
             return await db.CommentText
                .Include(c => c.Attraction)
                .Take(_count)
                .Cast<IComment>()
                .ToListAsync();
        }
    }

    public async Task<IComment> DeleteCommentAsync(Guid id)
    {
        using (var db = csMainDbContext.DbContext("sysadmin"))
        {
            var comment = await db.CommentText.FindAsync(id);
            if (comment == null)
            {
                throw new ArgumentException($"Comment with ID {id} not found.");
            }

            db.CommentText.Remove(comment);
            await db.SaveChangesAsync();

            return (IComment)comment;
         }
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
