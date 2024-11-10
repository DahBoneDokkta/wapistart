using Models;
using Configuration;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Seido.Utilities.SeedGenerator;
using Newtonsoft.Json;

namespace DbModels
{
    public class csCountryDbM : csCountries, ISeed<csCountryDbM>
    {
        [Key]
        public override Guid CountryId { get; set; }
        
        // Country has a list of cities
        [NotMapped ]
        public override List<ICity> Cities
        {
            get => CitiesDbM.Cast<ICity>().ToList(); 
            set => throw new NotImplementedException();
        }

        [JsonIgnore]
        public List<csCityDbM> CitiesDbM { get; set; }

        public override csCountryDbM Seed(csSeedGenerator _seeder)
        {
            base.Seed(_seeder);
            return this;
        }
    }
}