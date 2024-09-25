using Configuration;
using Microsoft.AspNetCore.Identity;
using Seido.Utilities.SeedGenerator;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System;

namespace Models;

public class csComment : ISeed<csComment>
{
    public virtual Guid CommentId {get; set;}
    public virtual string CommentText {get; set;}
    public DateTime Date {get; set;}
    
    public bool Seeded {get; set;} = false;
    public virtual csComment Seed (csSeedGenerator _seeder)
    {
        CommentId = Guid.NewGuid();
        Seeded = true;
        CommentText = $"Comments {_seeder.LatinSentence}";
        Date = DateTime.Now; // Sätter exakt tidpunkt när kommentaren skapas
        return this;
    }
}