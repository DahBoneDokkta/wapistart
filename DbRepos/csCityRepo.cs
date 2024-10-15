using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;
using DbModels;
using DbContext;
using Seido.Utilities.SeedGenerator;

public class csCityRepo
{
    private const string seedSource = "./friends-seeds1.json";

    public async Task<List<IAttraction>> GetAttractions(int _count)
    {
        using (var db = csMainDbContext.DbContext("sysadmin"))
        {
            return await db.AttractionName.Include(a => a.CommentDbM).Take(_count).ToListAsync<IAttraction>();
        }
    }

    public async Task Seed(int _count)
    {
        var fn = Path.GetFullPath(seedSource);
        var _seeder = new csSeedGenerator(fn);
        using (var db = csMainDbContext.DbContext("sysadmin"))
        {
            var cities = _seeder.ItemsToList<csCityDbM>(_count);
            var attractionDbM = _seeder.ItemsToList<csAttractionDbM>(5);
            var comments = _seeder.ItemsToList<csCommentDbM>(_count);

            foreach (var a in attractionDbM)
            {
                a.CommentDbM = comments;
            }

            foreach (var city in cities)
            {
                city.Attractions = attractionDbM.Select(a => new csAttraction
                {
                    AttractionId = a.AttractionId,
                    Name = a.Name,
                    CommentText = a.CommentDbM.Select(c => new csComment
                    {
                        CommentId = c.CommentId,
                        CommentText = c.CommentText
                    }).Cast<IComment>().ToList() // Konvertera till List<IComment>
                }).ToList();
            }

            db.Cities.AddRange(cities);
            await db.SaveChangesAsync();
        }
    }
}