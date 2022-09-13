using AppCore.Contracts;
using AppCore.Infrastructure;
using AppCore.Managers;
using AppCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using System.Globalization;

namespace AppCore
{
    public static class AppCoreServicesProviderResgistration
    {
        public static int LanguageId
        {
            get
            {
                return CultureInfo.CurrentCulture.LCID;
            }
        }


        public static IServiceCollection AddAppCoreServices(this IServiceCollection services)
        {

            services
                   .AddScoped(s => new BannerManager(s.GetService<AppCoreContext>(), LanguageId))
                   .AddScoped(s => new InfoPageManager(s.GetService<AppCoreContext>(), LanguageId))
                   .AddScoped(s => new MetaTagManager(s.GetService<AppCoreContext>(), LanguageId))
                   .AddScoped(s => new FaqManager(s.GetService<AppCoreContext>(), LanguageId))
                   .AddScoped(s => new NewsManager(s.GetService<AppCoreContext>(), LanguageId))
                   .AddScoped(s => new AlbumManager(s.GetService<AppCoreContext>(), LanguageId))
                   .AddScoped(s => new CountryManager(s.GetService<AppCoreContext>()))
                   .AddScoped(s => new HomeBannerManager(s.GetService<AppCoreContext>(), LanguageId))
                   .AddScoped(s => new CareerManager(s.GetService<AppCoreContext>(), LanguageId))
                   .AddScoped(s => new TestimonialManager(s.GetService<AppCoreContext>(), LanguageId))
                   .AddScoped(s => new LanguageManager(s.GetService<AppCoreContext>(), LanguageId))
                   .AddScoped<BusinessInfoManager>()
                   .AddScoped<MediaItemManager>()
                   .AddScoped<CurrencyConverter>()
                   .AddScoped<ISendMail, ElasticMailService>()
                   .AddScoped<MailManager>()
                   .AddScoped<MenuManager>()
                   .AddScoped<GalleryManager>()
                   .AddScoped<EventManager>()
                   .AddScoped<TeamManager>()
                   .AddScoped<MailChimpServiceManager>()
                   .AddScoped<IViewRenderService, ViewRenderService>();

            /*use this pattern to register your serivces
             * services.AddScoped(s => new NameOfManager(s.GetService<NameOfContext>(), languageId))
             */

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();

            return services;
        }
    }
}
