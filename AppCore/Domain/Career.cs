using AppCore.Contracts;
using AppCore.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;


namespace AppCore.Models
{
    public partial class Career : LocalizedEntity<CareerLocalized>
    {
        [NotMapped]
        public string Title { get; set; }

        [NotMapped]
        public string Description { get; set; }

        public override void Localize(int languageId)
        {
            var dictionary = CareerLocalizeds.ToDictionary(x => x.LanguageId);
            GetLocalizedEntity(dictionary, languageId);
        }

        public override void Map(CareerLocalized localizedEntity)
        {
            Title = localizedEntity.Title;
            Description = localizedEntity.Description;
        }
    }
}
