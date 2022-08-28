using AppCore.Contracts;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace AppCore.Models
{
    public partial class MetaTag : LocalizedEntity<MetaTagLocalized>
    {
        [NotMapped]
        public string Title { get; set; }
        [NotMapped]
        public string Description { get; set; }
        [NotMapped]
        public string Keywords { get; set; }


        public override void Localize(int languageId)
        {
            var dictionary = MetaTagLocalizeds.ToDictionary(x => x.LanguageId);
            GetLocalizedEntity(dictionary, languageId);
        }

        public override void Map(MetaTagLocalized localizedEntity)
        {
            Title = localizedEntity.MetaTitle;
            Description = localizedEntity.MetaDescription;
            Keywords = localizedEntity.MetaKeywords;
        }
    }
}
