using Models;
using Configuration;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Seido.Utilities.SeedGenerator;
using Newtonsoft.Json;
using System.Linq;



namespace DbModels;

public class csUserDbM : csUser, ISeed<csUserDbM>
{
    [Key]
    public override Guid UserId { get; set; }
    
    // public override List<IComment> CommentText { get; set;}
    [NotMapped]
    public override List<IComment> CommentText
    { 
        get => Comments?.Cast<IComment>().ToList(); 
        set => throw new NotImplementedException();
    }

    // Navigation property
    [JsonIgnore]
    public virtual List<csCommentDbM> Comments { get; set; }

    public override csUserDbM Seed (csSeedGenerator _seeder)
    {
        base.Seed (_seeder);
        return this;
    }
}
