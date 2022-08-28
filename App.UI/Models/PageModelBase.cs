using App.UI.Enums;
using AppCore.Managers;
using AppCore.Models;
using AppCore.Utilities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace App.UI.Models
{

    public abstract class PageModelBase : PageModel
    {
        #region Cultures, Urls And Pages
        public string CurrentCulture
        {
            get
            {
                return (CultureInfo.CurrentCulture.TwoLetterISOLanguageName == "en") ?
                        string.Empty : $"/{CultureInfo.CurrentCulture.TwoLetterISOLanguageName}";
            }
        }

        public string HomeUrlCulture
        {
            get
            {
                return (CultureInfo.CurrentCulture.TwoLetterISOLanguageName == "en") ?
                        "/" : $"/{CultureInfo.CurrentCulture.TwoLetterISOLanguageName}";
            }
        }

        public string CurrentFullLanguageTag
        {
            get
            {
                if (CultureInfo.CurrentUICulture.IetfLanguageTag == "en-US" || CultureInfo.CurrentUICulture.IetfLanguageTag == null)
                {
                    return ".en-GB";
                }
                else
                {
                    return "." + CultureInfo.CurrentUICulture.IetfLanguageTag;
                }
            }
        }

        public string DomainName
        {
            get
            {
                return PageContext.HttpContext.Request.Scheme + "://" + PageContext.HttpContext.Request.Host.Value;
            }
        }

        //public string PageName
        //{
        //    get
        //    {
        //        return PageContext.ActionDescriptor.DisplayName.Split("/")[1].ToLower();
        //    }
        //}

        //public string IsActive(string page)
        //{
        //    return (PageName == page) ? "active" : string.Empty;
        //}

        public string GetLocalizedUrl(string path)
        {
            return CurrentCulture + path;
        }

        public string RequestPath(string currentCulture)
        {
            string query = PageContext.HttpContext.Request.Query.Any() ?
               "?" + string.Join("&", PageContext.HttpContext.Request.Query.Select(x => $"{x.Key}={x.Value}")).Replace("?&", "?") :
               string.Empty;

            var pathArray = PageContext.HttpContext.Request.Path.ToString().Split("/").ToList();
            if (SupportedCultures.Any(x => x.TwoLetterISOLanguageName == pathArray[1]) || string.IsNullOrEmpty(pathArray[1]))
            {
                if (string.IsNullOrEmpty(currentCulture))
                {
                    pathArray.RemoveAt(1);
                }
                else
                {
                    pathArray[1] = currentCulture;
                }

                var joinedPathArray = string.Join("/", pathArray);

                if (string.IsNullOrEmpty(joinedPathArray)) return "/";

                return joinedPathArray + query;
            }

            if (!string.IsNullOrEmpty(currentCulture))
            {
                pathArray[1] = $"{currentCulture}/{pathArray[1]}";
            }

            return string.Join("/", pathArray) + query;
        }
        #endregion

        #region MetaTags, Banners, Settings And SocialLinks
        public MetaTag MetaTag { get; private set; }
        public PageNames? PageName { get; set; }
        public Banner Banner { get; set; }
        public BusinessInfo BusinessInfo { get; set; }
        public SocialMediaInfo SocialMediaInfo { get; set; }
        #endregion

        #region Supported Culture
        public IEnumerable<CultureInfo> SupportedCultures { get; set; }
        public CultureInfo DefaultCulture { get; set; }
        public IEnumerable<SelectListItem> SupportedCulturesList { get; set; }
        #endregion

        #region On Page Excution Handler and Methods
        public override async Task OnPageHandlerExecutionAsync(PageHandlerExecutingContext context, PageHandlerExecutionDelegate next)
        {
            
            SetSupportedCulturesProperties(context);
            SetSettingsAndSocialLinksProperties(context);
            SetMetaTagsProperties(context);
            SetBannerProperties(context);

            await next.Invoke();
        }

        private void SetBannerProperties(PageHandlerExecutingContext context)
        {
            if (PageName.HasValue)
            {
                var bannerManager =
                context.HttpContext.RequestServices.GetService(typeof(BannerManager)) as BannerManager;
                Banner = bannerManager.GetBanner((int)PageName.Value);
            }
        }

        private void SetMetaTagsProperties(PageHandlerExecutingContext context)
        {
            if (PageName.HasValue)
            {
                
                var _metaTagManager =
                context.HttpContext.RequestServices.GetService(typeof(MetaTagManager)) as MetaTagManager;
                MetaTag = _metaTagManager.GetPageTags((int)PageName.Value);

                ViewData["Title"] = MetaTag?.Title;
                ViewData["MetaDescription"] = MetaTag?.Description;
            }
        }

        private void SetSettingsAndSocialLinksProperties(PageHandlerExecutingContext context)
        {
            var _settingsManager =
                            context.HttpContext.RequestServices.GetService(typeof(BusinessInfoManager)) as BusinessInfoManager;
            BusinessInfo = _settingsManager.GetBusinessInfo();
            SocialMediaInfo = _settingsManager.GetSocialMediaInfo();
        }

        private void SetSupportedCulturesProperties(PageHandlerExecutingContext context)
        {
            var _supportedCultureOptions =
                        context.HttpContext.RequestServices.GetService(typeof(IOptions<RequestLocalizationOptions>)) as IOptions<RequestLocalizationOptions>;
            SupportedCultures = _supportedCultureOptions.Value.SupportedCultures;
            DefaultCulture = _supportedCultureOptions.Value.DefaultRequestCulture.Culture;
            SupportedCulturesList = SupportedCultures.Select(c => new SelectListItem
            {
                Value = $"{c.TwoLetterISOLanguageName}",
                Text = $"{c.Parent.EnglishName.ToUpper()}"
            });
        }
        #endregion


        public RedirectResult RedirectAndNotify(string url, List<string> messages, string title = null, NotificationType notificationType = NotificationType.success)
        {
            var notifyObject = new NotificationDetails
            {
                Message = string.Join(",", messages.ToList()),
                Title = title,
                NotificationType = notificationType
            };

            TempData.Put("Notify", notifyObject);
            return Redirect(url);
        }

        public RedirectResult RedirectAndNotify(string url, string message, string title = null, NotificationType notificationType = NotificationType.success)
        {
            var notifyObject = new NotificationDetails
            {
                Message = message,
                Title = title,
                NotificationType = notificationType
            };

            TempData.Put("Notify", notifyObject);
            return Redirect(url);
        }

        public void Notify(string message, string title = "", NotificationType notificationType = NotificationType.success)
        {
            var notificationObject = new NotificationDetails
            {
                Message = message,
                Title = title,
                NotificationType = notificationType
            };

            TempData.Put("Notify", notificationObject);
        }

        #region Error
        public IActionResult RedirectToNotFound()
        {
            return Redirect(GetLocalizedUrl("/error"));
        }
        #endregion

    }
}
