using Configuration;
using Microsoft.AspNetCore.Identity;
using Seido.Utilities.SeedGenerator;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System;

namespace Models;

public abstract class csCountries : ICountry, ISeed<csCountries>
{
    [Key]
    public virtual Guid CountryId {get; set;}
    public string CountryName {get; set;}
    public virtual ICollection<csCity> Cities {get; set;}
    public bool Seeded {get; set;} = false;
    public virtual csCountries Seed (csSeedGenerator _seeder)
    {
        CountryId = Guid.NewGuid();
        Seeded = true;
        CountryName = $"Countries {_seeder.LatinSentence}";
        return this;
    }
}