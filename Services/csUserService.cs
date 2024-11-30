using Models;
using DbRepos;

namespace Services
{
    public class csUserService : IUserService
    {
        private readonly IUserRepo _repo;

        public csUserService(IUserRepo repo)
        {
            _repo = repo;
        }

        public async Task<List<IUser>> GetUsersAsync(int count)
        {
            try
            {
                return await _repo.GetUsersAsync(count);
            }
            catch (Exception ex)
            {
                throw new Exception("Error! Could not get users.", ex);
            }
        }

        public async Task<List<IUser>> GetAllUsersAsync(int count)
        {
            try
            {
                return await _repo.GetAllUsersAsync(count);
            }
            catch (Exception ex)
            {
                throw new Exception("Error! Could not get all users.", ex);
            }
        }

        public async Task<IUser> DeleteUserAsync(Guid id)
        {
            try
            {
                return await _repo.DeleteUserAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error! Could not delete user with ID: {id}", ex);
            }
        }

        public async Task Seed(int count)
        {
            try
            {
                await _repo.Seed(count);
            }
            catch (Exception ex)
            {
                throw new Exception("Error! Could not create user.", ex);
            }
        }
    }
}