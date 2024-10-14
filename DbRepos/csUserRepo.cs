using Configuration;
using Models;
using DbModels;
using DbContext;
using Seido.Utilities.SeedGenerator;
using Microsoft.EntityFrameworkCore;

namespace DbRepos;

public class csUserRepo : IUserRepo
{

    private const string seedSource = "./friends-seeds1.json";

    public async Task<List<IUser>> Users(int _count)
    {
        using (var db = csMainDbContext.DbContext("sysadmin"))
        {
             return await db.Users
                .Include(u => u.Comments)
                .Take(_count)
                .Select(c => (IUser)c)
                .ToListAsync();
        }
    }

    public Task<List<IUser>> User(int _count)
    {
        throw new NotImplementedException();
    }

    public async Task Seed(int _count)
    {
        var fn = Path.GetFullPath(seedSource);
        var _seeder = new csSeedGenerator(fn);
        using (var db = csMainDbContext.DbContext("sysadmin"))
        {
            var users = _seeder.ItemsToList<csUserDbM>(5);
            var comments = _seeder.ItemsToList<csCommentDbM>(_count);

            foreach (var user in users)
            {
                user.CommentText = comments.Cast<IComment>().ToList();;
            }
            
            
            db.Users.AddRange(users);
            await db.SaveChangesAsync();
        }
    }

}
