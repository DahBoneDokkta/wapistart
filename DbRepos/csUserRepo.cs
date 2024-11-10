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

    public async Task<List<IUser>> GetUsers(int _count)
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

    public async Task<IUser> DeleteUserAsync(Guid id) 
    {
        using (var db = csMainDbContext.DbContext("sysadmin")) 
        {
            var _query = db.Users.Where(a => a.UserId == id);
            var _deletedUser = await _query.FirstOrDefaultAsync();

            if (_deletedUser is null) 
            {
                throw new ArgumentException($"The User with ID {id} does not exist.");   
            }
            db.Users.Remove(_deletedUser);
            await db.SaveChangesAsync();
            return _deletedUser;
        }
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
