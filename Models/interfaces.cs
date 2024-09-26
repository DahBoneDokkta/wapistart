using Configuration;
using Seido.Utilities.SeedGenerator;


namespace Models;


public interface ICountry
{
    public Guid CountryId { get; set; }
    string CountryName { get; set; }
    public List<ICity> Cities { get; set; }
}
public interface ICity
{
    public Guid CityId {get; set;}
    public int ZipCode {get; set;}
    public string Address {get; set;}
    public ICountry Country {get; set;}
}
public interface IUser
{
    public Guid UserId { get; set; }
    public string FirstName {get; set;}
    public string LastName {get; set;}
    public string Email {get; set;}
    public List<IComment> Comments {get; set;}
}

public interface IComment
{
    public Guid CommentId { get; set; }
    public string CommentText { get; set; }
}

public interface IAttraction
{
    public Guid AttractionId { get; set; }
    public string Name {get; set;}
}