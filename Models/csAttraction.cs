using Configuration;
using Microsoft.AspNetCore.Identity;
using Seido.Utilities.SeedGenerator;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models;

public class csAttraction : IAttraction, ISeed<csAttraction>
{
    [Key]
    public virtual Guid AttractionId {get; set;} = Guid.NewGuid();
    
    public virtual string Name {get; set;}
    public virtual string Category {get; set;}
    public virtual string Title {get; set;}
    public virtual string Description {get; set;}
    
    public virtual List<IComment> CommentText {get; set;}
    public virtual ICity City {get; set;}
    public virtual ICountry Country {get; set;}
    public bool Seeded {get; set;} = false;

    public virtual csAttraction Seed (csSeedGenerator _seeder)
    {
        AttractionId = Guid.NewGuid();
        Seeded = true;
        Name = $"Attraction Name {_seeder.LatinWords}";
        return this;
    }
}