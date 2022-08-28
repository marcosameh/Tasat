using AppCore.Models;
using System.Collections.Generic;
using System.Linq;

namespace AppCore.Managers
{


    public class CountryManager
    {
        /* For Sql Cahce  to work, you have to create a SqlCache Table which you can find its design on this page
         * 
         * https://docs.microsoft.com/en-us/aspnet/core/performance/caching/distributed?view=aspnetcore-3.1#code-try-2
         * 
         */

        private readonly AppCoreContext context;

        public CountryManager(AppCoreContext context)
        {
            this.context = context;

        }
        public IEnumerable<Country> GetCountries()
        {
            return context.Countries;
        }
        public Country GetCountry(string Iso2)
        {
            return context.Countries.Where(c => c.Iso2 == Iso2).FirstOrDefault();
           

        }

    }
}
