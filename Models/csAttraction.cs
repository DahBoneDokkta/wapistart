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
    
    public virtual List<IComment> Comment {get; set;}
    public virtual ICity City {get; set;}
    public virtual ICountry Country {get; set;}
    public bool Seeded {get; set;} = false;

    public virtual csAttraction Seed (csSeedGenerator _seeder)
    {
        AttractionId = Guid.NewGuid();
        Name = _seeder.FromString("Adventure Land, Ocean World, Fantasy Park, Safari Kingdom, Mountain Retreat, Sky Towers, Starry Beach, Jungle Adventure");
        Category = _seeder.FromString("Amusement Park, Aquarium, Wildlife Reserve, Mountain Resort, Skydiving, Beach Resort, Adventure Park, Water Park");
        Title = _seeder.FromString("Crystal Caverns, Skyline Observatory, Moonlit Gardens, Echo Canyon Trails, Ancient Ruins of Zaros, Emerald Lake Sanctuary, Firefly Forest, Solar Winds Amusement Park, Mystic Mountain, The Enchanted Castle");
        Description = _seeder.FromString("The ultimate thrill awaits, Explore the depths of the ocean, Step into a world of magic, Discover the wonders of wildlife, Escape to the mountains, Reach new heights, Relax by the sea, Dare to venture into the wild");
        Seeded = true;
        return this;
    }
}