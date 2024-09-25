using Configuration;
using Models;
using DbRepos;

using Seido.Utilities.SeedGenerator;

namespace Services;


public class csAnimalServiceDb: IAnimalsService {

    private IAnimalRepo _repo = null;


    public async Task<List<IAnimal>> AfricanAnimals(int _count) => await _repo.AfricanAnimals(_count);
    public async Task Seed(int _count) => await _repo.Seed(_count);
    
    
    public csAnimalServiceDb(IAnimalRepo repo)
    {
        _repo = repo;
    }
}