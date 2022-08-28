using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace App.UI.Models
{
    public class ContactUsEmail
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Country { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public string Title { get; set; }
        public string BusinessName { get; set; }
        public string WebsiteLink { get; set; }
        public string WebsiteText { get; set; }
        public string LogoFullPath { get; set; }
        public List<EmailFooterWebsiteLink> EmailFooterWebsiteLinks { get; set; }
        public string FacebookLink { get; set; }
        public string TwitterLink { get; set; }
        public string HostName { get; set; }
        public IEnumerable<SelectListItem> Countries { get; set; }
    }
    public class EmailFooterWebsiteLink
    {
        public string Name { get; set; }
        public string Link { get; set; }
    }
}