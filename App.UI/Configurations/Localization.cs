using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Globalization;

namespace App.UI.Configurations
{
    public static class Localization
    {
        public static List<CultureInfo> SupportedCultures = new List<CultureInfo>
        {
            new CultureInfo("en-GB")
        };


        public static IServiceCollection AddLocalizations(this IServiceCollection services)
        {

            services.AddLocalization(options => { options.ResourcesPath = "wwwroot/resources"; });

            services.Configure<RequestLocalizationOptions>(
                options =>
                {
                    options.DefaultRequestCulture = new RequestCulture(culture: "en-GB", uiCulture: "en-GB");
                    options.SupportedCultures = SupportedCultures;
                    options.SupportedUICultures = SupportedCultures;
                    options.RequestCultureProviders.Insert(0, new CookieRequestCultureProvider());
                });

            return services;
        }
    }
}


