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
    public override string CommentText 
    { 
        get => AttractionDbM?.ToString();
        set => throw new NotImplementedException(); }

    [JsonIgnore]
    public  csAttractionDbM AttractionDbM { get; set; }

    // [ForeignKey("CityId")]
    // public csCityDbM City {get; set;}

    [ForeignKey("UserId")]
    public override csUser User {get; set;}

    public override csCommentDbM Seed (csSeedGenerator _seeder)
    {
        base.Seed (_seeder);
        return this;
    }

    csCommentDbM ISeed<csCommentDbM>.Seed(csSeedGenerator seedGenerator)
    {
        return this;
    }
}
