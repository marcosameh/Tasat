using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace AppCore.Infrastructure
{
    public static class ExtensionsMethods
    {
        public static string ToCurrency(this decimal value)
        {
            return value.ToString("G29"); //
        }

        public static DateTime ToCultureInVariant(this string date)
        {
            if (DateTime.TryParseExact(date, "dd/MM/yyyy",
                       CultureInfo.InvariantCulture,
                       DateTimeStyles.None,
                       out DateTime formattedDate))
            {
                return formattedDate;
            }
            else if (DateTime.TryParseExact(date, "MM/dd/yyyy",
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.None,
                    out DateTime formattedMonthDate))
            {
                return formattedMonthDate;
            }
            else if (DateTime.TryParseExact(date, "dd.MM.yyyy",
                      CultureInfo.InvariantCulture,
                      DateTimeStyles.None,
                      out DateTime formattedGermanDate))
            {
                return formattedGermanDate;
            }
            else
            {
                Console.WriteLine("Parsing failed");
                return default;
            }
        }

       //public static IEnumerable<(T item, int index)> WithIndex<T>(this IEnumerable<T> self) => self.Select((item, index) => (item, index));

       public static string ToMonthName(this DateTime value) => value.ToString("MMM", CultureInfo.InvariantCulture);
       //public static string ToMonthName(this int value) => CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(value);
        public static int ToMonthNumber(this string value) => DateTime.ParseExact(value, "MMMM", CultureInfo.InvariantCulture).Month;
        public static bool IsEmpty(this DateTime dateTime) => dateTime == default;

        public static void Put<T>(this ITempDataDictionary tempData, string key, T value) where T : class
        {
            tempData[key] = JsonConvert.SerializeObject(value);
        }

        public static T Get<T>(this ITempDataDictionary tempData, string key) where T : class
        {
            object o;
            tempData.TryGetValue(key, out o);
            return o == null ? null : JsonConvert.DeserializeObject<T>((string)o);
        }

        

    }

   
}
