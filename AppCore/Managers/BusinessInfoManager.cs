using AppCore.Enums;
using AppCore.Models;
using AppCore.Utilities;
using AppCore.ValueObjects;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AppCore.Managers
{
    public class BusinessInfoManager
    {
        private readonly AppCoreContext _context;
        private readonly IMemoryCache memoryCache;
        private const string BusinessInfoKey = "BusinessInfo_Cache";
        private const string SocialLinkKey = "SocialLink_Cache";
        private const int CACHE_DURATION_HOURS = 1;

        public BusinessInfoManager(AppCoreContext context, IMemoryCache memoryCache)
        {
            _context = context;
            this.memoryCache = memoryCache;
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


        private void AddBusinessInfoToCache(BusinessInfo BusinessInfo)
        {
            memoryCache.Set(BusinessInfoKey, BusinessInfo, TimeSpan.FromHours(CACHE_DURATION_HOURS));
        }

        public BusinessInfo GetBusinessInfo()
        {
            BusinessInfo info = null;
            if (!memoryCache.TryGetValue(BusinessInfoKey, out info))
            {
                info = new BusinessInfo();
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
            };
            AddBusinessInfoToCache(info);
            return info;
        }

        public string GetSocialLink(SocialLinkTypes type)
        {
            var socialLinks  = GetSocialLinks();
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
            if (!memoryCache.TryGetValue(SocialLinkKey, out socialLinks))
            {
                socialLinks = _context.SocialLinks.Where(x => x.Active.Value).ToList();
                AddSocialLinksToCache(socialLinks);
            }
            return socialLinks;
        }
        private void AddSocialLinksToCache(List<SocialLink> SocialLinks)
        {
            memoryCache.Set(SocialLinkKey, SocialLinks, TimeSpan.FromHours(1));
        }

    }
}