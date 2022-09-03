using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace App.UI.Models
{
    public class ContactUsEmail
    {
        [Required]
        public string FullName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Phone { get; set; }
        public string Country { get; set; }
        [Required]
        public string Subject { get; set; }
        [Required]
        public string Department { get; set; }
        [Required]
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