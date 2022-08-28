using App.UI.InfraStructure;
using App.UI.Models;
using AppCore.DTO;
using App.UI.Enums;
using AppCore.Managers;
using AppCore.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace App.UI
{
    public class contactusModel : PageModelBase
    {
        private readonly ResourceInfo resourceInfo;
        private readonly MailManager _mailManager;

        [BindProperty]
        public ContactUsEmail ContactUsDataModel { get; set; } = new ContactUsEmail();

        [Required]
        [GoogleReCaptchaValidation]
        [BindProperty(Name = "g-recaptcha-response")]
        public string GoogleReCaptchaResponse { get; set; }

        public contactusModel(ResourceInfo resourceInfo, MailManager mailManager)
        {
            this.resourceInfo = resourceInfo;
            _mailManager = mailManager;

            PageName = PageNames.ContactUs;

        }

        public IActionResult OnPost()
        {

            if (GoogleReCaptchaResponse != null)
            {

                MailInfo mailInfo = new MailInfo
                {
                    Title = "Contact Form Request",
                    Model = ContactUsDataModel,
                    ToMail = BusinessInfo.ContactUsEmail,
                    Subject = "Contact Us Request",
                    TemplateName = "ContactUs",
                };
                var result = _mailManager.SendRequest(mailInfo);



                if (result.IsFailure)
                {
                    Notify(result.Error,
                    resourceInfo.GetLocalizedSharedString(CurrentFullLanguageTag, "ErrorTitle"), NotificationType.error);

                    return Page();
                }

                return RedirectAndNotify(GetLocalizedUrl("/contact-us"),
                    resourceInfo.GetLocalizedSharedString(CurrentFullLanguageTag, "SuccessMessage")
                , resourceInfo.GetLocalizedSharedString(CurrentFullLanguageTag, "SuccessTitle"),
                NotificationType.success
                );

            }

            Notify(resourceInfo.GetLocalizedSharedString(CurrentFullLanguageTag, "RobottestMessage")
                , resourceInfo.GetLocalizedSharedString(CurrentFullLanguageTag, "ErrorTitle"),
                NotificationType.error);

            return Page();


        }

    }
}