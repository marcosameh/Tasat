using AppCore.ValueObjects;
using System.Collections.Generic;

namespace AppCore.Models
{
    public class BusinessInfo
    {

        public List<PhoneNumber> PhoneNumbers { get; set; }
        public PhoneNumber Landline { get; set; }
        public string ContactUsEmail { get; set; }
        public List<EmailAddress> ContactEmails { get; set; }
        public string BookingEmail { get; set; }
        public string Address { get; set; }
        public string WorkingHours { get; set; }
        public string BusinessName { get; set; }
        public string WebsiteLink { get; set; }
        public string WebsiteText { get; set; }
        public string LogoFullPath { get; set; }
        public string FacebookLink { get; set; }
        public string TripAdvisorLink { get; set; }
        public string YouTubeLink { get; set; }
        public string InstagramLink { get; set; }
        public string ViberLink { get; set; }
        public string WhatsAppLink { get; set; }
        public string AdminEmail { get; set; }
        public string OpeningHours { get; set; }
        public string FaxNo { get; set; }
        public string Video { get; set; }

    }
}