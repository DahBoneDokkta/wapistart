using Configuration;
using Models;
using DbModels;
using DbContext;
using Seido.Utilities.SeedGenerator;
using Microsoft.EntityFrameworkCore;

namespace DbRepos;

public class csCityRepo : ICityRepo
{
    private const string seedSource = "./friends-seeds1.json";

    public async Task<List<ICity>> City(int _count)
    {
        await using var db = csMainDbContext.DbContext("sysadmin");
        return await db.Cities
                .Include(c => c.Comments)
                .Include(c => c.Attractions)
                .ThenInclude(a => a.Comments)
                .Take(_count)
                .Select(c => (ICity)c)
                .ToListAsync();
    }

    public async Task Seed(int _count)
    {
        var fn = Path.GetFullPath(seedSource);
        var _seeder = new csSeedGenerator(fn);
        await using var db = csMainDbContext.DbContext("sysadmin");
        var cities = _seeder.ItemsToList<csCityDbM>(_count);
        var attractionDbM = _seeder.ItemsToList<csAttractionDbM>(5);
        var comments = _seeder.ItemsToList<csCommentDbM>(_count);

        foreach (var a in attractionDbM)
        {
            a.CommentDbM = comments.Select(c => new csCommentDbM
            {
                CommentId = c.CommentId,
                CommentText = c.CommentText,
        
            }).ToList();
        }

        foreach (var city in cities)
        {
            city.Attractions = attractionDbM.Select(a => new csAttraction
            {
                AttractionId = a.AttractionId,
                Name = a.Name,
                CommentsText = a.CommentDbM.Select(c => new csComment
                {
                    CommentId = c.CommentId,
                    CommentText = c.CommentText
                }).ToList()
            }).ToList();
        }

        db.Cities.AddRange(cities); 
        await db.SaveChangesAsync();
    }
}








// public class csCityRepo : ICityRepo
// {

//     private const string seedSource = "./friends-seeds1.json";

//     public async Task<List<ICity>> City(int _count)
//     {
        
//         await using var db = csMainDbContext.DbContext("sysadmin");
//         return await db.Cities
//                 .Include(c => c.Comments)
//                 .Include(c => c.Attractions)
//                 .ThenInclude(a => a.Comments)
//                 .Take(_count)
//                 .Select(c => (ICity)c)
//                 .ToListAsync();
        
//     }

//     public async Task Seed(int _count)
//     {
//         var fn = Path.GetFullPath(seedSource);
//         var _seeder = new csSeedGenerator(fn);
//         await using var db = csMainDbContext.DbContext("sysadmin");
//         var cities = _seeder.ItemsToList<csCity>(_count);
//         var attractionDbM = _seeder.ItemsToList<csAttractionDbM>(5);
//         var comments = _seeder.ItemsToList<csCommentDbM>(_count);
//         {
            

//             foreach (var a in attractionDbM)
//             {
//                 a.CommentDbM = comments;
//             }

//                 var attractions = attractionDbM.Select(a => new csAttraction
//                 {
//                     AttractionId = a.AttractionId,
//                     Name = a.Name,
//                     Comments = a.CommentDbM.Cast<IComment>().ToList()
//                 }).ToList();

//             foreach (var city in cities)
//             {
//                 city.Attractions = attractions;
//             }

//             var cityDbMList = cities.Select(c => new csCityDbM
//             {
//                 CityId = c.CityId,
//                 Name = c.Name,
//                 Attractions = c.Attractions.Select(a => new csAttractionDbM
//                 {
//                     AttractionId = a.AttractionId,
//                     Name = a.Name,
//                     CommentDbM = a.Comments.Cast<csCommentDbM>().ToList()
//                 }).ToList()
//             }).ToList();
            
                
            
            
            
//             db.Cities.AddRange(cityDbMList);
//             await db.SaveChangesAsync();
//         }
//     }
// }
