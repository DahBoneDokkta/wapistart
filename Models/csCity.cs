using Configuration;
using Microsoft.AspNetCore.Identity;
using Seido.Utilities.SeedGenerator;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System;

namespace Models;

public class csCity : ICity, ISeed<csCity>
{
    [Key]
    public virtual Guid CityId {get; set;}
    public virtual string Name {get; set;}
    public int ZipCode {get; set;}
    public string Address {get; set;}

    public virtual ICountry Country {get; set;}
    public bool Seeded {get; set;} = false;

    public virtual List<csAttraction> Attractions {get; set;}

    public virtual csCity Seed (csSeedGenerator _seeder)
    {
        CityId = Guid.NewGuid();
        Seeded = true;
        Name = $"Countries {_seeder.MusicGroupName}";
        return this;
    }
}