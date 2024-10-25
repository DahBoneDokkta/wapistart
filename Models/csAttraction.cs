using Configuration;
using Microsoft.AspNetCore.Identity;
using Seido.Utilities.SeedGenerator;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System;

namespace Models;

public class csAttraction : IAttraction, ISeed<csAttraction>
{
    [Key]
    public virtual Guid AttractionId {get; set;} = Guid.NewGuid();
    
    public virtual string Name {get; set;}
    public virtual string Category {get; set;}
    public virtual string Title {get; set;}
    public virtual string Description {get; set;}
    
    public virtual ICollection<csComment> CommentText {get; set;}
    public virtual csCity City {get; set;}
    public virtual csCountries Country {get; set;}
    public bool Seeded {get; set;} = false;
    //public ICollection<IComment> CommentText { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public virtual csAttraction Seed (csSeedGenerator _seeder)
    {
        AttractionId = Guid.NewGuid();
        Seeded = true;
        Name = $"Attraction Name {_seeder.LatinWords}";
        return this;
    }
}