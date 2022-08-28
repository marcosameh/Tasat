using AppCore.Contracts;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace AppCore.Models
{
    public partial class HomeBanner : LocalizedEntity<HomeBannerLocalized>
    {
        [NotMapped]
        public string Title { get; set; }

        //[NotMapped]
        //public string SubTitle { get; set; }

        
        [NotMapped]
        public string PhotoPath
        {
            get
            {
                return "/photos/home-banners/" + Photo;
            }
        }
        public override void Localize(int languageId)
        {
            var dictionary = HomeBannerLocalizeds.ToDictionary(x => x.LanguageId);
            GetLocalizedEntity(dictionary, languageId);
        }

        public override void Map(HomeBannerLocalized localizedEntity)
        {
            Title = localizedEntity.Title;
            //SubTitle = localizedEntity.SubTitle;
        }
    }
}
