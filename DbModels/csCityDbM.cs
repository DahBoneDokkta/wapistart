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
    public override ICountry Country
    { 
        get => CountryDbM; 
        set => throw new NotImplementedException(); 
    }

    public csCountryDbM CountryDbM { get; set; }

    [NotMapped]
    public override List<csComment> CommentText
    {
        get => Comments?.Cast<csComment>().ToList();
        set => throw new NotImplementedException();
    }

    [JsonIgnore]
    public List<csCommentDbM> Comments {get; set;}
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
