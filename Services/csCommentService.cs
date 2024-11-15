using Models;
using DbRepos;

namespace Services
{
    public class csCommentService : ICommentService
    {
        private readonly ICommentRepo _commentRepo;

        public csCommentService(ICommentRepo commentRepo)
        {
            _commentRepo = commentRepo;
        }

        public async Task<List<IComment>> GetCommentsAsync(int _count)
        {
            return await _commentRepo.GetComments(_count);
        }

        public async Task<IComment> DeleteCommentAsync(Guid id)
        {
            return await _commentRepo.DeleteCommentAsync(id);
        }

        public async Task Seed(int _count)
        {
            await _commentRepo.Seed(_count);
        }
    }
}