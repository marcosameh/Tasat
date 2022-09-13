using App.UI.Enums;
using App.UI.InfraStructure;
using App.UI.Models;
using AppCore.DTO;
using AppCore.Enums;
using AppCore.Managers;
using AppCore.Models;
using LazZiya.TagHelpers.Alerts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;

namespace App.UI.Pages
{
    public class IndexModel : PageModel
    {
        private readonly MediaItemManager mediaItemManager;
        private readonly MenuManager menuManager;
        private readonly EventManager eventManager;
        private readonly GalleryManager galleryManager;
        private readonly ResourceInfo resourceInfo;
        private readonly MailManager mailManager;
        private readonly BusinessInfoManager businessInfoManager;
        private readonly TestimonialManager testimonialManager;
        private readonly TeamManager teamManager;

        public MediaItem TopRightMedia { get; set; }
        public MediaItem RightImageMedia { get; set; }
        public MediaItem LeftImageMedia { get; set; }
        public IQueryable<MenuSection> Menu { get; set; }  
        public IQueryable<Event> Events { get; set; }  
        public IQueryable<Gallery> Galleries { get; set; }
        public IEnumerable<Testimonial> Testimonials { get; set; }
        public IEnumerable<TeamMember> Team { get; set; }
        public BusinessInfo BusinessInfo { get; set; }

        [BindProperty]
        public ContactUsEmail contactUsEmail { get; set; } = new ContactUsEmail();

        public IndexModel(MediaItemManager mediaItemManager,
            MenuManager menuManager,EventManager eventManager,GalleryManager galleryManager,
            ResourceInfo resourceInfo,MailManager mailManager,BusinessInfoManager businessInfoManager,
            TestimonialManager testimonialManager,TeamManager teamManager)
        {
            this.mediaItemManager = mediaItemManager;
            this.menuManager = menuManager;
            this.eventManager = eventManager;
            this.galleryManager = galleryManager;
            this.resourceInfo = resourceInfo;
            this.mailManager = mailManager;
            this.businessInfoManager = businessInfoManager;
            this.testimonialManager = testimonialManager;
            this.teamManager = teamManager;
        }


        public void OnGet()
        {
            Initialize();


        }

        private void Initialize()
        {
            TopRightMedia = mediaItemManager.GetMediaItem(MediaItemKeys.TopRight.ToString());
            RightImageMedia = mediaItemManager.GetMediaItem(MediaItemKeys.RightImage.ToString());
            LeftImageMedia = mediaItemManager.GetMediaItem(MediaItemKeys.LeftImage.ToString());
            Menu=menuManager.GetMenu();
            Events = eventManager.GetEvents();
            Galleries=galleryManager.GetGallery();
            BusinessInfo=businessInfoManager.GetBusinessInfo();
            Testimonials = testimonialManager.GetTestimonials();
            Team = teamManager.GetTeam();
           

        }
        public IActionResult OnPost()
        {
            Initialize();


            MailInfo mailInfo = new MailInfo
                {
                    Title = contactUsEmail.Subject,
                    Model =contactUsEmail,
                    ToMail = businessInfoManager.GetSetting(SettingType.ContactUsEmail),
                    Subject = contactUsEmail.Subject,
                    TemplateName = "ContactUs",
                };
                var result = mailManager.SendRequest(mailInfo);



                if (result.IsFailure)
                {
                TempData.Warning(result.Error, "SomeThingWrong", false);
            }

            TempData.Success("Your Email Send Successfly We will Contact You Soon");
            return Page();




        }

    }
}
