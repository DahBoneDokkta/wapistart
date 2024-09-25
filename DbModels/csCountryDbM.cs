using Models;
using Configuration;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Seido.Utilities.SeedGenerator;
using Newtonsoft.Json;



namespace DbModels;

public class csCountryDbM : csCountries, ISeed<csCountryDbM>
{
    [Key]
    public override Guid CountryId { get; set; }
    
    [NotMapped]
    public override List<ICity> City {get; set;}

    // [JsonIgnore]
    // public  csCountryDbM CountryDbM { get; set; }


    public override csCountryDbM Seed (csSeedGenerator _seeder)
    {
        base.Seed (_seeder);
        return this;
    }
}
