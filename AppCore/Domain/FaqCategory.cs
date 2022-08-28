using AppCore.Contracts;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;


namespace AppCore.Models
{
    public partial class FaqCategory : LocalizedEntity<FaqCategoryLocalized>
    {
        [NotMapped]
        public string Name { get; set; }

        public override void Localize(int languageId)
        {
            var dictionary = FaqCategoryLocalizeds.ToDictionary(x => x.LanguageId);
            GetLocalizedEntity(dictionary, languageId);
        }

        public override void Map(FaqCategoryLocalized localizedEntity)
        {
            Name = localizedEntity.Name;
        }
    }
}