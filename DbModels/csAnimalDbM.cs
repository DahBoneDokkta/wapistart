using Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Seido.Utilities.SeedGenerator;
using Newtonsoft.Json;



namespace DbModels;

public class csAnimalDbM : csAnimal, ISeed<csAnimalDbM>
{
    [Key]
    public override Guid AnimalId { get; set; }

    #region adding more readability to an enum type in the database
    public virtual string strKind
    {
        get => Kind.ToString();
        set { }  //set is needed by EFC to include in the database, so I make it to do nothing
    }
    public virtual string strMood
    {
        get => Mood.ToString();
        set { } //set is needed by EFC to include in the database, so I make it to do nothing
    }
    #endregion
    
    [NotMapped]
    public override IZoo Zoo { get => ZooDbM; set => throw new NotImplementedException(); }

    [JsonIgnore]
    public  csZooDbM ZooDbM { get; set; }

    public override csAnimalDbM Seed (csSeedGenerator _seeder)
    {
        base.Seed (_seeder);
        return this;
    }
}
