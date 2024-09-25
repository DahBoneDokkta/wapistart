using Models;
using Configuration;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Seido.Utilities.SeedGenerator;
using Newtonsoft.Json;



namespace DbModels;

public class csCityDbM : csCity, ISeed<csCityDbM>
{
    [Key]
    public override Guid CityId { get; set; }
    
    [NotMapped]
    public override ICountry Country {get; set;}

    // [JsonIgnore]
    // // Navigation property to City -> Country
    // public  csCountryDbM CountryDbM { get; set; }

    public override csCityDbM Seed (csSeedGenerator _seeder)
    {
        base.Seed (_seeder);
        return this;
    }
}
