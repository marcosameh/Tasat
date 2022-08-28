using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using AppCore.Contracts;


namespace AppCore.Models
{
    public partial class News : LocalizedEntity<NewsLocalized>
    {
        [NotMapped]
        public string Title { get; set; }
        
        [NotMapped]
        public string ShortDescription { get; set; }

        [NotMapped]
        public string Body { get; set; }
        
        [NotMapped]
        public string MetaTitle { get; set; }
        
        [NotMapped]
        public string MetaDescription { get; set; }

        [NotMapped]
        public string URL
        {
            get
            {
                return string.Format("news-details/{0}/{1}", UrlName, Id);
            }
        }

        [NotMapped]
        public string SmallPhotoPath
        {
            get
            {
                return string.Format("/photos/news/{0}", Photo).Replace("lg", "sm");
            }
        }

        [NotMapped]
        public string PhotoPath
        {
            get
            {
                return string.Format("/photos/news/{0}", Photo);
            }
        }
        [NotMapped]
        public string DetailsUrl
        {
            get
            {
                return string.Format("/blog/{0}/{1}/{2}/{3}", NewsDate.Year, NewsDate.Month, UrlName, Id);
            }
        }
        [NotMapped]
        public string FormattedDate
        {
            get
            {
                return NewsDate.ToString("MMMM dd, yyyy");
            }
        }



        public override void Localize(int languageId)
        {
            var dictionary = NewsLocalizeds.ToDictionary(x => x.LanguageId);
            GetLocalizedEntity(dictionary, languageId);
        }

        public override void Map(NewsLocalized localizedEntity)
        {
            Title = localizedEntity.Title;
            ShortDescription = localizedEntity.ShortDescription;
            Body = localizedEntity.Body;
            MetaTitle = localizedEntity.MetaTitle;
            MetaDescription = localizedEntity.MetaDescription;
        }
    }
}