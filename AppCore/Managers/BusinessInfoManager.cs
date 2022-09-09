using AppCore.Enums;
using AppCore.Models;
using AppCore.Utilities;
using AppCore.ValueObjects;
using System.Collections.Generic;
using System.Linq;

namespace AppCore.Managers
{
    public class BusinessInfoManager
    {
        private readonly AppCoreContext _context;


        public BusinessInfoManager(AppCoreContext context)
        {
            _context = context;

        }


        public string GetSetting(SettingType keyType)
        {
            try
            {
                return _context.Settings.SingleOrDefault(s => s.Key == keyType.ToString())?.Value;
            }
            catch
            {
                return string.Empty;
            }
        }




        public BusinessInfo GetBusinessInfo()
        {

            BusinessInfo info = new BusinessInfo();
            info.Address = GetSetting(SettingType.Address);
            info.ContactEmails = StringUtilities.TextToListItemsArray(GetSetting(SettingType.ContactUsEmail)).Select(e => new EmailAddress(e)).ToList();
            info.ContactUsEmail = info.ContactEmails.FirstOrDefault().Value;
            info.AdminEmail = GetSetting(SettingType.AdminEmail);
            info.PhoneNumbers = StringUtilities.TextToListItemsArray(GetSetting(SettingType.Telephone)).Select(x => new PhoneNumber(x)).ToList();
            info.Landline = new PhoneNumber(GetSetting(SettingType.Landline));
            info.WebsiteLink = GetSetting(SettingType.WebsiteLink);
            //info.DomainName = GetSetting(SettingType.DomainName);
            info.FacebookLink = GetSocialLink(SocialLinkTypes.Facebook);
            info.YouTubeLink = GetSocialLink(SocialLinkTypes.YouTube);
            info.InstagramLink = GetSocialLink(SocialLinkTypes.Instagram);
            info.OpeningHours = GetSetting(SettingType.OpeningHours);

            return info;
        }

        public string GetSocialLink(SocialLinkTypes type)
        {
            var socialLinks = GetSocialLinks();
            var mediaItem = socialLinks.Where(x => x.Type == (int)type && x.Active.Value).FirstOrDefault();
            return mediaItem != null ? mediaItem.Link : "";
        }
        public SocialMediaInfo GetSocialMediaInfo()
        {
            SocialMediaInfo info = new SocialMediaInfo
            {
                FacebookLink = GetSocialLink(SocialLinkTypes.Facebook),
                TwitterLink = GetSocialLink(SocialLinkTypes.Twitter),
                InstagramLink = GetSocialLink(SocialLinkTypes.Instagram),
                YouTubeLink = GetSocialLink(SocialLinkTypes.YouTube),
                LinkedInLink = GetSocialLink(SocialLinkTypes.LinkedIn),
                GooglePlusLink = GetSocialLink(SocialLinkTypes.GooglePlus),
                PinterestLink = GetSocialLink(SocialLinkTypes.Pinterest),
                SkypeLink = GetSocialLink(SocialLinkTypes.Skype),
                WhatsappLink = GetSocialLink(SocialLinkTypes.WhatsApp)
            };
            return info;
        }

        public List<SocialLink> GetSocialLinks()
        {
            List<SocialLink> socialLinks;

            socialLinks = _context.SocialLinks.Where(x => x.Active.Value).ToList();

            return socialLinks;
        }


    }
}