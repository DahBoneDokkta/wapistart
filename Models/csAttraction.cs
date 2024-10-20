using Configuration;
using Microsoft.AspNetCore.Identity;
using Seido.Utilities.SeedGenerator;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System;

namespace Models;

public class csAttraction : IAttraction, ISeed<csAttraction>
{
    public virtual Guid AttractionId {get; set;}
    
    public virtual string Name {get; set;}
    
    // public virtual List<IComment> CommentText {get; set;}
    public virtual ICollection<IComment> CommentText {get; set;}
    public virtual ICity City {get; set;}
    public bool Seeded {get; set;} = false;
    public List<IComment> Comments { get; set;}

    public virtual csAttraction Seed (csSeedGenerator _seeder)
    {
        AttractionId = Guid.NewGuid();
        Seeded = true;
        Name = $"Attraction Name {_seeder.LatinWords}";
        return this;
    }
}