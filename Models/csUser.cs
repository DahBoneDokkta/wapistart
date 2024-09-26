using Configuration;
using Microsoft.AspNetCore.Identity;
using Seido.Utilities.SeedGenerator;
using System.ComponentModel.DataAnnotations;

namespace Models;

public class csUser : IUser, ISeed<csUser>
{
    public virtual Guid UserId {get; set;}
    public string FirstName {get; set;}
    public string LastName {get; set;}
    public string Email {get; set;}
    
    public virtual List<IComment> CommentText {get; set;}
    public bool Seeded {get; set;} = false;
    public virtual csUser Seed (csSeedGenerator _seeder)
    {
        UserId = Guid.NewGuid();
        FirstName = $"Usernames {_seeder.FirstName}";
        return this;
    }
}