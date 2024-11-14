using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;
using Seido.Utilities.SeedGenerator;
using System.Linq;

namespace DbModels
{
    public class csAttractionDbM : csAttraction, ISeed<csAttractionDbM>
    {
        [Key]
        public override Guid AttractionId { get; set; }

        // Attraction has a list of Comments
        [NotMapped]
        public override List<IComment> CommentText
        {
            get => CommentDbM?.Cast<IComment>().ToList(); 
            set => throw new NotImplementedException(); 
        }

        [JsonIgnore]
        public virtual List<csCommentDbM> CommentDbM { get; set; }

        [NotMapped]
        public override ICity City
        {
            get => CityDbM; 
            set => throw new NotImplementedException(); 
        }

        [JsonIgnore]
        public virtual csCityDbM CityDbM { get; set; }

        public int CountryId { get; set; }

        [NotMapped]
        public override ICountry Country 
        {
            get => CountryDbM; 
            set => throw new NotImplementedException(); 
        }

        [JsonIgnore]
        public virtual csCountryDbM CountryDbM { get ; set ; }


        public override csAttractionDbM Seed(csSeedGenerator _seeder)
        {
            base.Seed (_seeder);
            return this;
        }
    }
}