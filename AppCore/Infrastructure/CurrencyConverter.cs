using AppCore.Common;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Net;

namespace AppCore.Infrastructure
{
    public class CurrencyConverter
    {

        //Fixer.io  Exchange Currency
        //https://fixer.io/quickstart
        //reading json object into c# https://stackoverflow.com/questions/9926600/how-to-read-json-response-in-c-sharp
        // fuLl list of currency rates http://data.fixer.io/api/latest?access_key=API-KEY&format=1

        private readonly IMemoryCache cache;
        private readonly IConfiguration configuration;

        public CurrencyConverter(IMemoryCache cache, IConfiguration configuration)
        {
            this.cache = cache;
            this.configuration = configuration;
        }

        public Result<decimal> GetTotalInRequestedCurrency(string fromcurrency, string toCurrecny, decimal total)
        {
            var result = Result.Ok(total);

            if (fromcurrency != toCurrecny)
            {
                 result = Convert(total, fromcurrency, toCurrecny)
                                 .OnSuccess(value => Math.Round(value, 2));
            }

            return result;
        }

        private Result<decimal> Convert(decimal amount, string fromCurrencyIso3Code, string toCurrencyIso3Code)
        {
            var cacheKey = $"{fromCurrencyIso3Code}-{toCurrencyIso3Code}";

            if (!cache.TryGetValue(cacheKey, out decimal exchangeRate))
            {
                try
                {
                    var endPoint = "latest";
                    var apiKey = configuration.GetValue<string>("CurrencyConverterApiKey");

                    if (string.IsNullOrEmpty(apiKey))
                    {
                        return Result.Fail<decimal>("There's no valid Api Key");
                    }

                    var URL = "http://data.fixer.io/api/" + endPoint + "?access_key=" + apiKey + "&format=1";

                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL);

                    using (var twitpicResponse = (HttpWebResponse)request.GetResponse())
                    {
                        using var reader = new StreamReader(twitpicResponse.GetResponseStream());

                        var objText = reader.ReadToEnd();
                        JObject joResponse = JObject.Parse(objText);
                        JValue baseCurrency = (JValue)joResponse["base"];
                        JObject rates = (JObject)joResponse["rates"];

                        var isValidSymbols = IsValidSymbols(fromCurrencyIso3Code, toCurrencyIso3Code, apiKey);
                        if (isValidSymbols == true)
                        {
                            var baseToCurrentCurrency = decimal.Parse(rates[fromCurrencyIso3Code].ToString());
                            var baseToTargetCurrency = decimal.Parse(rates[toCurrencyIso3Code].ToString());
                            exchangeRate = baseToTargetCurrency / baseToCurrentCurrency;
                        }
                        else
                        {
                            return Result.Fail<decimal>("invalid currency convertor");
                        }
                    }

                    var cacheEntryOptions = new MemoryCacheEntryOptions()
                        .SetSlidingExpiration(TimeSpan.FromHours(12));

                    cache.Set(cacheKey, exchangeRate, cacheEntryOptions);

                }
                catch (Exception exp)
                {
                    return Result.Fail<decimal>(exp.Message);
                }
            }

            var convertedAmount = exchangeRate * amount;

            return Result.Ok(convertedAmount);
        }
       
        private bool IsValidSymbols(string fromCurrencyIso3Code, string toCurrencyIso3Code, string apiKey)
        {
            bool isValidSymbols = false;
            var url = "http://data.fixer.io/api/symbols?access_key=" + apiKey + "&format=1";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

            using (var twitpicResponse = (HttpWebResponse)request.GetResponse())
            {
                using var reader = new StreamReader(twitpicResponse.GetResponseStream());
                var objText = reader.ReadToEnd();
                JObject joResponse = JObject.Parse(objText);
                if (JObject.Parse(objText)["symbols"][fromCurrencyIso3Code] != null
                      && JObject.Parse(objText)["symbols"][toCurrencyIso3Code] != null)
                {
                    isValidSymbols = true;
                }
            }
            return isValidSymbols;
        }
    }
}
