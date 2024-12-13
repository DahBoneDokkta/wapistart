using Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Seido.Utilities.SeedGenerator;
using Newtonsoft.Json;

namespace DbModels
{
    public class csCommentDbM : csComment, ISeed<csCommentDbM>
    {
        [Key]
        public override Guid CommentId { get; set; }

        public Guid AttractionId { get; set; }

        // Mappar från IAttraction till csAttractionDbM
        [JsonIgnore]
        [ForeignKey("AttractionId")]
        public csAttractionDbM AttractionDbM {get; set;}

        [NotMapped]
        public override IAttraction Attraction 
        { 
            get => AttractionDbM; 
            set => throw new NotImplementedException(); 
        }

        // Mappning från IUser till csUserDbM
        [NotMapped]
        public override IUser User
        {
            get => UserDbM; 
            set => throw new NotImplementedException();
        }

        // ForeignKey till User
        [JsonIgnore]
        public csUserDbM UserDbM { get; set; }

        public override csCommentDbM Seed(csSeedGenerator _seeder)
        {
            base.Seed(_seeder);
            return this;
        }
/*
        csCommentDbM ISeed<csCommentDbM>.Seed(csSeedGenerator seedGenerator)
        {
            return this;
        }
        */
    }
}
