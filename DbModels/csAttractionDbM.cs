using Models;
using Configuration;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Seido.Utilities.SeedGenerator;
using Newtonsoft.Json;



namespace DbModels;

public class csAttractionDbM : csAttraction, ISeed<csAttractionDbM>
{
    [Key]
    public override Guid AttractionId { get; set; }
    
    [JsonIgnore]
    public new List<csComment> Comments {get; set;}

    [NotMapped] 
    public override List<IComment> CommentText
    { 
        get => Comments?.Cast<IComment>().ToList(); 
        set => throw new NotImplementedException(); 
    }
    public List<csCommentDbM> CommentDbM { get; set; }
    
    [JsonIgnore]
    public  csCityDbM CityDbM { get; set; }

    public override csAttractionDbM Seed (csSeedGenerator _seeder)
    {
        base.Seed (_seeder);
        return this;
    }
}
