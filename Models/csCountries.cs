using Configuration;
using Microsoft.AspNetCore.Identity;
using Seido.Utilities.SeedGenerator;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System;

namespace Models;

public class csCountries : ISeed<csCountries>
{
    public virtual Guid CountryId {get; set;}
    public string Name {get; set;}
    
    public virtual List<ICity> City {get; set;}
    public bool Seeded {get; set;} = false;
    public virtual csCountries Seed (csSeedGenerator _seeder)
    {
        CountryId = Guid.NewGuid();
        Seeded = true;
        Name = $"Countries {_seeder.LatinSentence}";
        return this;
    }
}