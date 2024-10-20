using System.Collections.Generic;
using System.Threading.Tasks;
using Models;
using DbModels;
using DbContext;
using Seido.Utilities.SeedGenerator;
using Microsoft.EntityFrameworkCore;

namespace Services
{
    public class csCommentService : ICommentService
    {
        private readonly csMainDbContext _context;
        private readonly csSeedGenerator _seeder;

        public csCommentService(csMainDbContext context, csSeedGenerator seeder)
        {
            _context = context;
            _seeder = seeder;
        }

        public async Task<List<IComment>> GetCommentsAsync(int count)
        {
            return await _context.Comments
            .Take(count)
            .Select(c => (IComment)c)
            .ToListAsync();
        }

        public async Task SeedCommentsAsync(int count)
        {
            var comments = _seeder.ItemsToList<csCommentDbM>(count);
            foreach (var comment in comments)
            {
                comment.IsTestData = true;
            }
            await _context.Comments.AddRangeAsync(comments);
            await _context.SaveChangesAsync();
        }

        public async Task ClearTestDataAsync()
        {
            var testComments = _context.Comments.Where(u => u.IsTestData);
            _context.Comments.RemoveRange(testComments);
            await _context.SaveChangesAsync();
        }

    }
}