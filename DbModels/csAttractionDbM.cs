using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;
using Seido.Utilities.SeedGenerator;

namespace DbModels
{
    public class csAttractionDbM : csAttraction, ISeed<csAttractionDbM>
    {
        [Key]
        public override Guid AttractionId { get; set; }
        public override string Name {get; set;}

        // Attraction has a list of Comments
        [NotMapped]
        public override ICollection<csComment> CommentText 
        {
            get => CommentDbM?.Cast<csComment>().ToList(); 
            set => throw new NotImplementedException(); 
        }

        [JsonIgnore]
        public virtual List<csCommentDbM> CommentDbM { get; set; }

        // Attraction has a foreign key to City
        // Since Attraction cannot exist without a City 
        [NotMapped]
        public override csCity City
        {
            get => CityDbM; 
            set => throw new NotImplementedException(); 
        }

        [JsonIgnore]
        public virtual csCityDbM CityDbM { get; set; }

        [NotMapped]
        public override csCountries Country 
        {
            get => CountryDbM; 
            set => throw new NotImplementedException(); 
        }

        [JsonIgnore]
        public virtual csCountryDbM CountryDbM { get; set; }

        public bool IsTestData { get; set; }

        public override csAttractionDbM Seed(csSeedGenerator _seeder)
        {
            base.Seed (_seeder);
            return this;
        }
    }
}