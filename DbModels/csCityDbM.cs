using Models;
using Configuration;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Seido.Utilities.SeedGenerator;
using Newtonsoft.Json;
using System.Linq;



namespace DbModels;

public class csCityDbM : csCity, ISeed<csCityDbM>
{
    [Key]
    public override Guid CityId { get; set; }

    [NotMapped]
    public override List <IAttraction> Attractions 
    {
        get => AttractionDbM?.Cast<IAttraction>().ToList();
        set => throw new NotImplementedException();
    }

    [JsonIgnore]
    public virtual List<csAttractionDbM> AttractionDbM { get; set; }
    
    [NotMapped]
    public override ICountry Country
    { 
        get => CountryDbM; 
        set => throw new NotImplementedException(); 
    }
    [JsonIgnore]
    public virtual csCountryDbM CountryDbM { get; set; }

    public override csCityDbM Seed (csSeedGenerator _seeder)
    {
        base.Seed (_seeder);
        return this;
    }
}
