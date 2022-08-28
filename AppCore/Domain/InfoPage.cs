using AppCore.Contracts;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace AppCore.Models
{
    public partial class InfoPage : LocalizedEntity<InfoPageLocalized>
    {
        [NotMapped]
        public string Title { get; set; }
        [NotMapped]
        public string SubTitle { get; set; }
        [NotMapped]
        public string Body { get; set; }
        [NotMapped]
        public string MetaTitle { get; set; }
        [NotMapped]
        public string MetaDescription { get; set; }
        [NotMapped]
        public string BannerPath
        {
            get
            {
                return $"/photos/info-page/{Banner}";
            }
        }
        [NotMapped]
        public string URL
        {
            get
            {
                return $"/info/{UrlName}";
            }
        }
        public override void Localize(int languageId)
        {
            var dictionary = InfoPageLocalizeds.ToDictionary(x => x.LanguageId);
            GetLocalizedEntity(dictionary, languageId);
        }

        public override void Map(InfoPageLocalized localizedEntity)
        {
            Title = localizedEntity.Title;
            SubTitle = localizedEntity.SubTitle;
            Body = localizedEntity.Body;
            MetaTitle = localizedEntity.MetaTitle;
            MetaDescription = localizedEntity.MetaDescription;
        }
    }
}