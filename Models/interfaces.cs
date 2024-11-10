using Configuration;
using Seido.Utilities.SeedGenerator;


namespace Models;


public interface ICountry
{
    public Guid CountryId { get; set; }
    string CountryName { get; set; }
    List<ICity> Cities { get; set; }
}
public interface ICity
{
    public Guid CityId {get; set;}
    public string Name {get; set;}
    public int ZipCode {get; set;}
    public string Address {get; set;}
    ICountry Country {get; set;}
}
public interface IUser
{
    public Guid UserId { get; set; }
    public string FirstName {get; set;}
    public string LastName {get; set;}
    public string Email {get; set;}
    List<IComment> CommentText {get; set;}
}

public interface IComment
{
    public Guid CommentId { get; set; }
    public string CommentText { get; set; }
    IAttraction Attraction { get; set; }
    IUser User { get; set; }
}

public interface IAttraction
{
    public Guid AttractionId { get; set; }
    string Name {get; set;}
    string Description {get; set;}
    string Category {get; set;}
    string Title {get; set;}
    List<IComment> CommentText {get; set;}
    ICity City {get; set;}
    ICountry Country {get; set;}
}