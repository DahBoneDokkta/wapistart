using Models;
using DbModels;
namespace DbRepos;

public interface IAnimalRepo
{
    public Task<List<IAnimal>> AfricanAnimals(int _count);
    public Task Seed(int _count);
}