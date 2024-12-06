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
        public csAttractionDbM AttractionDbM {get; set;}
        // {
        //     get => AttractionDbM; 
        //     set => AttractionDbM = value as csAttractionDbM; // Här mappas interface till konkret typ
        // }

        // Här definierar vi den konkreta relationen till AttractionDbM
        [NotMapped]
        // [ForeignKey("AttractionId")]
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
            // set => UserDbM = value as csUserDbM;
        }

        // ForeignKey till User
        [JsonIgnore]
        // [ForeignKey("UserId")]
        // public Guid? UserId {get; set;}
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
