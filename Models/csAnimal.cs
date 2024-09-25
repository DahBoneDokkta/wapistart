using Configuration;
using Seido.Utilities.SeedGenerator;

namespace Models;

public class csZoo: IZoo, ISeed<csZoo>
{
    public virtual Guid ZooId { get; set;}
    public string Name { get; set; }

    public virtual List<IAnimal> Animals { get; set; }
    public bool Seeded { get; set; } = false;
    public virtual csZoo Seed (csSeedGenerator _seeder)
    {
        ZooId = Guid.NewGuid();
        Name = $"Zoo in the the city {_seeder.City()}";
        return this;
    }
}



public class csAnimal :IAnimal, ISeed<csAnimal>
{
    public virtual Guid AnimalId { get; set; } = Guid.NewGuid();
    public enAnimalKind Kind { get; set; }
    public enAnimalMood Mood { get; set; }

    public int Age { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    public virtual IZoo Zoo { get; set; }

    #region seeder
    public bool Seeded { get; set; } = false;

    public virtual csAnimal Seed (csSeedGenerator _seeder)
    {
        AnimalId = Guid.NewGuid();
        Seeded = true;
        Kind = _seeder.FromEnum<enAnimalKind>();
        Mood = _seeder.FromEnum<enAnimalMood>();
        Age = _seeder.Next(0, 11);
        Name = _seeder.PetName;
        Description = _seeder.LatinSentence;

        return this;
    }
    #endregion
    
}