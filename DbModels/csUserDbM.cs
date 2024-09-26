using Models;
using Configuration;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Seido.Utilities.SeedGenerator;
using Newtonsoft.Json;



namespace DbModels;

public class csUserDbM : csUser, ISeed<csUserDbM>
{
    [Key]
    public override Guid UserId { get; set; }
    
    [NotMapped]
    public override List<IComment> CommentText { get; set;}

    // [JsonIgnore]
    // public  csCommentDbM CommentDbM { get; set; }

    public override csUserDbM Seed (csSeedGenerator _seeder)
    {
        base.Seed (_seeder);
        return this;
    }
}