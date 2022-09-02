using App.UI.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace App.UI.Pages
{

    public class sitemapModel : PageModel
    {
      //  private readonly SiteMapManager siteMapManager;

        public sitemapModel()
        {
           // this.siteMapManager = siteMapManager;
        }

        public IEnumerable<string> Articles { get; set; }

        public void OnGet()
        {
           // Articles = siteMapManager.GetUrls();

        }
    }
}