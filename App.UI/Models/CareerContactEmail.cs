using App.UI.InfraStructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace App.UI.Models
{
    public class CareerContactEmail
    {
        public string FullName { get; set; }
        public string JobTitle { get; set; }
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

        [DataType(DataType.Upload)]
        [MaxFileSize(10 * 1024 * 1024)]
        [FileExtensions(Extensions = "pdf,doc,docx,txt")]
        public IFormFile AttachmentCV { get; set; }

        public List<EmailFooterWebsiteLink> EmailFooterWebsiteLinks { get; set; }
        public string FacebookLink { get; set; }
        public string TwitterLink { get; set; }
        public string HostName { get; set; }
        public IEnumerable<SelectListItem> Countries { get; set; }
        public string CVPath { get; internal set; }
    }
    
}