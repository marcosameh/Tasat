using AppCore.Contracts;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace AppCore.Models
{
    public partial class InfoPageCategory : LocalizedEntity<InfoPageCategoryLocalized>
    {
        [NotMapped]
        public string Name { get; set; }

        public override void Localize(int languageId)
        {
            var dictionary = InfoPageCategoryLocalizeds.ToDictionary(x => x.LanguageId);
            GetLocalizedEntity(dictionary, languageId);
        }

        public override void Map(InfoPageCategoryLocalized localizedEntity)
        {
            Name = localizedEntity.Name;
        }
   
    }
}