using AppCore.Contracts;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;


namespace AppCore.Models
{
    public partial class Faq : LocalizedEntity<FaqLocalized>
    {
        [NotMapped]
        public string Question { get; set; }
        [NotMapped]
        public string Answer { get; set; }

        public override void Localize(int languageId)
        {
            var dictionary = FaqLocalizeds.ToDictionary(x => x.LanguageId);
            GetLocalizedEntity(dictionary, languageId);
        }

        public override void Map(FaqLocalized localizedEntity)
        {
            Question = localizedEntity.Question;
            Answer = localizedEntity.Answer;
        }
    }
}