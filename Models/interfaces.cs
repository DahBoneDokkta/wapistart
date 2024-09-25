using Configuration;
using Seido.Utilities.SeedGenerator;


namespace Models;
public enum enAnimalKind {Zebra, Elephant, Lion, Leopard, Gasell}
public enum enAnimalMood { Happy, Hungry, Lazy, Sulky, Buzy, Sleepy };

public interface IAnimal
{
    public Guid AnimalId { get; set; }
    public enAnimalKind Kind { get; set; }
    public enAnimalMood Mood { get; set; }
    
    public int Age { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public IZoo Zoo { get; set; }
}

public interface IZoo
{
    public Guid ZooId { get; set;}
    public string Name { get; set; }
    public List<IAnimal> Animals { get; set; }
}

public interface ICountry
{
    Guid CountryId { get; set; }
    string CountryName { get; set; }
}
public interface ICity
{
    Guid CityId {get; set;}
    public string Name {get; set;}
    public int ZipCode {get; set;}
    public string Address {get; set;}
    public ICountry Country {get; set;}
}
public interface IUser
{
    Guid UserId { get; set; }
    public string FirstName {get; set;}
    public string LastName {get; set;}
    public string Email {get; set;}
}

public interface IComment
{
    Guid CommentId { get; set; }
    public string CommentText { get; set; }
}

public interface IAttraction
{
    Guid AttractionId { get; set; }
    public string Name {get; set;}
}