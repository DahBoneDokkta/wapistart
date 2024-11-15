using Models;
using DbRepos;

namespace Services
{
    public class csCityService : ICityService
    {
        private readonly ICityRepo _repo;

        public csCityService(ICityRepo repo)
        {
            _repo = repo;
        }

        // Hämtar en lista med slumpmässiga städer
        public async Task<List<ICity>> RandomCity(int count)
        {
            return await _repo.GetCities(count);
        }

        // Tar bort en stad baserat på ID
        public async Task<ICity> DeleteCity(Guid id)
        {
            return await _repo.DeleteCityAsync(id);
        }

        // Seedar städer med hjälp av SeedGenerator
        public async Task Seed(int count)
        {
            await _repo.Seed(count);
        }
    }
}



