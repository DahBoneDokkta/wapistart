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
    
    // public override List<IComment> CommentText { get; set;}
    [NotMapped]
    public override ICollection<csComment> CommentText { get; set; }

    // Navigation property
    [JsonIgnore]
    public List<csCommentDbM> Comments { get; set; }
    public bool IsTestData { get; set; }

        public csUserDbM()
    {
        CommentText = new List<csComment>();
        Comments = new List<csCommentDbM>();
    }

    public override csUserDbM Seed (csSeedGenerator _seeder)
    {
        base.Seed (_seeder);
        return this;
    }
}
