using AppCore.Contracts;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace AppCore.Models
{
    public partial class Banner : LocalizedEntity<BannerLocalized>
    {
        [NotMapped]
        public string Title { get; set; }
        [NotMapped]
        public string SubTitle { get; set; }
        [NotMapped]
        public string Link { get; set; }
        [NotMapped]
        public string PhotoPath
        {
            get
            {
                return "/photos/banners/" + Photo;
            }
        }
        public override void Localize(int languageId)
        {
            var dictionary = BannerLocalizeds.ToDictionary(x => x.LanguageId);
            GetLocalizedEntity(dictionary, languageId);
        }

        public override void Map(BannerLocalized localizedEntity)
        {
            Title = localizedEntity.Title;
            SubTitle = localizedEntity.SubTitle;
            Link = localizedEntity.Link;
        }
    }
}
