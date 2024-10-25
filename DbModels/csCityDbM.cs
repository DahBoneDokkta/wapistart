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
    public string Name {get; set;}
    public string ZipCode {get; set;}
    public string Address {get; set;}
    
    [NotMapped]
    public override csCountries Country
    { 
        get => CountryDbM; 
        set => throw new NotImplementedException(); 
    }
    [JsonIgnore]
    public virtual csCountryDbM CountryDbM { get; set; }

    [JsonIgnore]
    public List<csAttractionDbM> Attractions {get; set;}
    // { 
    // get => AttractionDbM?.ToList<IAttraction>(); 
    // set => throw new NotImplementedException(); 
    // }

    // [JsonIgnore]
    // public List<csCommentDbM> Comments {get; set;}
    public bool IsTestData { get; set; }

     public csCityDbM()
    {
    }

    public override csCityDbM Seed (csSeedGenerator _seeder)
    {
        base.Seed (_seeder);
        return this;
    }
}
