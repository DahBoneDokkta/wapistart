using Models;
using DbRepos;

namespace Services
{
    public class csCountryService : ICountryService
    {
        private readonly ICountryRepo _repo;

        // Konstruktor för att injicera DI av repo
        public csCountryService(ICountryRepo repo)
        {
            _repo = repo;
        }

        // Hämtar ett antal länder baserat på count
        public async Task<List<ICountry>> GetCountriesAsync(int count)
        {
            try
            {
                return await _repo.GetCountries(count);
            }
            catch (Exception ex)
            {
                throw new Exception("Error! Could not get countries", ex);
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
                throw new Exception("Error! Could not seed countries", ex);
            }
        }
    }
}