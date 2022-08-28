using App.UI.Models;
using App.UI.Enums;
using Microsoft.AspNetCore.Mvc;

namespace App.UI.Pages
{
    public class IndexModel : PageModelBase
    {
        public SocialSharing SocialSharing { get; set; }

        public IndexModel()
        {
            PageName = PageNames.Home;
        }


        public IActionResult OnGet()
        {
            //SocialSharing = SocialSharing.CreateSocialSharing("Title", "UrlToShare");
            //SocialSharing.WithFacebooK().WithLinkedIn().WithTwitter().WithGooglePlus();

            return Page();
        }

       
           
        }
    }

