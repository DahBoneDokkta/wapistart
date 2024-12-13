using Configuration;
using Microsoft.AspNetCore.Identity;
using Seido.Utilities.SeedGenerator;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System;

namespace Models;

public class csComment : IComment, ISeed<csComment>
{
    [Key]
    public virtual Guid CommentId {get; set;} = Guid.NewGuid();
    public virtual string CommentText {get; set;}
    public DateTime Date {get; set;}
    public virtual IAttraction Attraction {get; set;}
    public virtual IUser User {get; set;}
    
    public bool Seeded {get; set;} = false;
    public virtual csComment Seed (csSeedGenerator _seeder)
    {
        CommentId = Guid.NewGuid();
        CommentText = _seeder.LatinSentence;
        Date = DateTime.Now; // Sätter exakt tidpunkt när kommentaren skapas
        Seeded = true;
        return this;
    }
}