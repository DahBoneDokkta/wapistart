using Configuration;
using Seido.Utilities.SeedGenerator;


namespace Models;


public interface ICountry
{
    public Guid CountryId { get; set; }
    string CountryName { get; set; }
    ICollection<csCity> Cities { get; set; }
}
public interface ICity
{
    public Guid CityId {get; set;}
    public int ZipCode {get; set;}
    public string Address {get; set;}
    csCountries Country {get; set;}
}
public interface IUser
{
    public Guid UserId { get; set; }
    public string FirstName {get; set;}
    public string LastName {get; set;}
    public string Email {get; set;}
    ICollection<csComment> CommentText {get; set;}
}

public interface IComment
{
    public Guid CommentId { get; set; }
    public string CommentText { get; set; }
    csAttraction Attraction { get; set; }
}

public interface IAttraction
{
    public Guid AttractionId { get; set; }
    string Name {get; set;}
    ICollection<csComment> CommentText {get; set;}
    csCity City {get; set;}
}