using System;
using System.Collections.Generic;
using System.Text;

namespace AppCore.DTO
{
    public record MailInfo
    {
        public List<string> ToList { get; internal set; }
        public string TemplateName { get; set; }
        public dynamic Model { get; set; }
        public string Title { get; set; }

        public string Subject { get; set; }
        public string Body { get; set; }

        public string ToMail { get; set; }
        public List<string> CCMails { get; set; }
    }
}
