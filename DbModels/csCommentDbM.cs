using Models;
using Configuration;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Seido.Utilities.SeedGenerator;
using Newtonsoft.Json;



namespace DbModels;

public class csCommentDbM : csComment, ISeed<csCommentDbM>
{
    [Key]
    public override Guid CommentId { get; set; }
    
    [NotMapped]
    public override List<IAttraction> Name 
    { 
        get => AttractionDbM.ConvertAll(async => (IAttraction)async); 
        set => throw new NotImplementedException(); }

    [JsonIgnore]
    public  csAttractionDbM AttractionDbM { get; set; }

    public override csAttractionDbM Seed (csSeedGenerator _seeder)
    {
        base.Seed (_seeder);
        return this;
    }
}
