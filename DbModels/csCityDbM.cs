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
    public override List<ICountry> Country
    { 
        get => Countries?.Cast<ICountry>().ToList(); 
        set => throw new NotImplementedException(); 
    }

    public List<csCountryDbM> Countries { get; set; }
    public csCityDbM()
    {
        // Initialisera Countries om det behövs
        Countries = new List<csCountryDbM>();
    }


    // [JsonIgnore]
    // // Navigation property to City -> Country
    // public  csCountryDbM CountryDbM { get; set; }

    public override csCityDbM Seed (csSeedGenerator _seeder)
    {
        base.Seed (_seeder);
        return this;
    }
}
