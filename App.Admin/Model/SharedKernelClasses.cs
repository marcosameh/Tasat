using DynamicData.Admin.Infrastructure.Services;
using NotAClue.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Security;

namespace DynamicData.Admin.Model
{
    #region MediaItems

    [MetadataType(typeof(MediaItemMetadata))]
    //[DisableActions(DisableEditing = false)]
    public partial class MediaItem
    {
    }

    public class MediaItemMetadata
    {
        [UIHint("Photo")]
        [Photo("/photos/media-items/originals/", "/photos/media-items/")]
        [PhotoThumbnail(1, 0, "200,200,false,sm,.jpg", "6000,6000,false,lg,.jpg")]
        [Hint(Hint = "Please upload a Width X Height photo")]

        public object Photo { get; set; }

    
        //[ReadOnly(true)]
        public object Width { get; set; }
        //[ReadOnly(true)]
        public object Height { get; set; }
        //[ReadOnly(true)]
        public object ItemKey { get; set; }
    }

    #endregion
    #region Banners

    [MetadataType(typeof(BannerMetadata))]
    [DisableActions(DisableEditing = true)]
    public partial class Banner
    {
    }

    public class BannerMetadata
    {
        [UIHint("Photo")]
        [Photo("/photos/banners/originals/", "/photos/banners/")]
        [PhotoThumbnail(1, 0, "300,65,false,sm,.jpg", "1920,400,false,lg,.jpg")]
        [Hint(Hint = "Please upload a 1920 X 400 photo")]
        [DisplayName("Banner")]
        public object Photo { get; set; }

        [ReadOnly(true)]
        [DisplayName("Page Name")]
        public object SitePage { get; set; }

      
        [ScaffoldColumn(false)]
        public object Active { get; set; }
        [ScaffoldColumn(false)]
        public object DisplayOrder { get; set; }

        [ScaffoldColumn(false)]
        public object CustomField { get; set; }

        [ScaffoldColumn(false)]
        public object BannerLocalizeds { get; set; }
    }

    #endregion

    #region Banner Types

    [MetadataType(typeof(BannerTypeMetadata))]
    public partial class BannerType
    {
    }

    public class BannerTypeMetadata
    {
        [ReadOnly(true)]
        public object Name { get; set; }

        [ScaffoldColumn(false)]
        public object Id { get; set; }

        [ScaffoldColumn(false)]
        public object Width { get; set; }

        [ScaffoldColumn(false)]
        public object Height { get; set; }
    }

    #endregion

    #region Albums
    //[DisableActions(DisableEditing=true)]
    [MetadataType(typeof(AlbumMetadata))]
    public partial class Album
    {
    }

    public class AlbumMetadata
    {
        [PageName]
        [DisplayName("Url name")]
        public object Name { get; set; }


        [ScaffoldColumn(false)]
        public object AlbumLocalizeds { get; set; }
    }

    #endregion

    #region AlbumPhotos

    [MetadataType(typeof(AlbumPhotoMetadata))]
    public partial class AlbumPhoto
    {
    }

    public class AlbumPhotoMetadata
    {
        [UIHint("Photo")]
        [Photo("/photos/gallery/originals/", "/photos/gallery/")]
        [PhotoThumbnail(1, 0, "150,100,false,sm,.jpg", "1200,600,false,lg,.jpg")]
        [Hint(Hint = "Please upload a 1200 X 600 photo")]
        public object Photo { get; set; }
    }

    #endregion

    #region News

    [MetadataType(typeof(NewsMetadata))]
    public partial class News
    {
    }

    public class NewsMetadata
    {
        [UIHint("Photo")]
        [Photo("/photos/news/originals/", "/photos/news/")]
        [PhotoThumbnail(1, 0, "100,100,false,_thumb,.jpg", "200,200,false,_md,.jpg", "980,500,false,_lg,.jpg")]
        [Hint(Hint = "Please upload a 980 X 500 photo")]
        [DisplayName("Main Photo")]
        public object Photo { get; set; }

        [PageName]
        public object UrlName { get; set; }

        [DisplayName("News Date")]
        [UIHint("Date")]
        public object NewsDate { get; set; }

        [ScaffoldColumn(false)]
        public object NewsLocalizeds { get; set; }

        [ScaffoldColumn(false)]
        public object Thumbnail { get; set; }

        [ScaffoldColumn(false)]
        public object GroupId { get; set; }
    }

    #endregion news

    #region Language

    [MetadataType(typeof(LanguageMetadata))]
    [DisplayColumn("FriendlyName", "FriendlyName")]
    public partial class Language
    {
    }

    public class LanguageMetadata
    {
        [ScaffoldColumn(false)]
        public object NewsLocalizeds { get; set; }

        [ScaffoldColumn(false)]
        public object MetaTagLocalizeds { get; set; }
    }

    #endregion

    #region Setting

    [MetadataType(typeof(SettingMetadata))]
    public partial class Setting
    {
    }

    public class SettingMetadata
    {
        [ScaffoldColumn(false)]
        public object Key { get; set; }

        [ReadOnly(true)]
        public object Description { get; set; }

        [ScaffoldColumn(false)]
        public object DataType { get; set; }

        [ScaffoldColumn(false)]
        public object SettingCategory { get; set; }
    }

    #endregion

    #region Faq

    [MetadataType(typeof(FaqCategoryMetadata))]
    public partial class FaqCategory
    {
    }

    public class FaqCategoryMetadata
    {
        [PageName]
        public object UrlName { get; set; }

        [ScaffoldColumn(false)]
        public object FaqCategoryLocalizeds { get; set; }
    }

    [MetadataType(typeof(FaqMetadata))]
    public partial class Faq
    {
    }

    public class FaqMetadata
    {
        [ScaffoldColumn(false)]
        public object FaqLocalizeds { get; set; }
    }

    #endregion

    #region Metatags

    [MetadataType(typeof(MetaTagMetadata))]
    public partial class MetaTag
    {

        public string Title
        {
            get
            {
                if (this.MetaTagLocalizeds.Any(x => x.LanguageId == 2057))
                {
                    return this.MetaTagLocalizeds.First(x => x.LanguageId == 2057).MetaTitle;
                }
                return string.Empty;
            }
        }
    }

    public class MetaTagMetadata
    {
        [ReadOnly(true)]
        [DisplayName("Page Name")]
        public object SitePage { get; set; }

        [ScaffoldColumn(false)]
        public object MetaTagLocalizeds { get; set; }

        // [Hint(Hint = "Page Title should be 70 characters max including spaces")]
        // public object MetaTitle { get; set; }

        // [Hint(Hint = "Page Description should be 150 characters max including spaces")]
        // public object MetaDescription { get; set; }
    }

    #endregion

    #region SocialLink

    [MetadataType(typeof(SocialLinkMetadata))]
    [DisableActions(DisableEditing = true)]
    public partial class SocialLink
    {
    }

    public class SocialLinkMetadata
    {
        [ScaffoldColumn(false)]
        public object CssClass { get; set; }

        [ReadOnly(true)]
        [DisplayName("Social Network")]
        public object Type { get; set; }

        [ScaffoldColumn(false)]
        public object GroupId { get; set; }
    }

    #endregion

    #region Users

    [MetadataType(typeof(UserMetadata))]
    public partial class User
    {
        public List<string> Roles
        {
            get
            {
                var roles = new UserService().GetUserRole(Email);

                return roles;
            }
        }

        public string FirstRole
        {
            get
            {
                return Roles.FirstOrDefault();
            }
        }

        public string Password
        {
            get
            {
                if (string.IsNullOrEmpty(_password))
                {
                    if (aspUser == null)
                        aspUser = Membership.GetUser(AspNetUserId);
                    return aspUser.GetPassword();
                }
                else
                    return _password;
            }
        }

        public string Email
        {
            get
            {
                if (aspUser == null)
                    aspUser = Membership.GetUser(AspNetUserId);
                return aspUser.Email;
            }
        }

        public bool Locked
        {
            get
            {
                if (aspUser == null)
                    aspUser = Membership.GetUser(AspNetUserId);
                return aspUser.IsLockedOut;
            }
        }

        public bool Active
        {
            get
            {
                if (aspUser == null)
                    aspUser = Membership.GetUser(AspNetUserId);
                return aspUser.IsApproved;
            }
        }

        private string _password;
        private MembershipUser aspUser = null;
    }

    public class UserMetadata
    {
        [ScaffoldColumn(false)]
        public object PasswordResetTime { get; set; }

        [ScaffoldColumn(false)]
        public object PasswordResetKey { get; set; }
    }

    #endregion
}