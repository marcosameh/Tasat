using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace App.UI.InfraStructure
{
    public class RequestCultureMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IOptions<RequestLocalizationOptions> options;

        public RequestCultureMiddleware(RequestDelegate next, IOptions<RequestLocalizationOptions> options)
        {
            _next = next;
            this.options = options;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var supportedCultures = options.Value.SupportedUICultures.ToDictionary(x => x.TwoLetterISOLanguageName);

            CultureInfo culture = GetResponseCulture(context, supportedCultures);

            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;

            CultureInfo.DefaultThreadCurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentUICulture = culture;

            await _next(context);
        }

        private CultureInfo GetResponseCulture(HttpContext context, Dictionary<string, CultureInfo> supportedCultures)
        {
            CultureInfo defaultCulture = options.Value.DefaultRequestCulture.Culture;

            // check URL culture segment
            string urlCulture = context.Request.Path.Value.Split("/")[1];
            if (string.IsNullOrEmpty(urlCulture) == false)
            {

                return supportedCultures.ContainsKey(urlCulture)
                    ? supportedCultures[urlCulture]
                    : defaultCulture;
            }

            // check cookie
            var cookieCulture = context.Request.Cookies["culture"];
            if (string.IsNullOrEmpty(cookieCulture) == false)
            {
                return supportedCultures.ContainsKey(cookieCulture)
                    ? supportedCultures[cookieCulture]
                    : defaultCulture;
            }

            // check browser headers
            if (context.Request.Headers.ContainsKey("accept-language"))
            {
                var browserPreferredLanguage = context.Request.Headers["accept-language"].FirstOrDefault();
                var browserCulture = browserPreferredLanguage?.Split(",")[0].Split("-")[0];
                if (string.IsNullOrEmpty(browserCulture) == false)
                {
                    return supportedCultures.ContainsKey(browserCulture)
                        ? supportedCultures[browserCulture]
                        : defaultCulture;
                }
            }
            

            return defaultCulture;
        }
    }
}
