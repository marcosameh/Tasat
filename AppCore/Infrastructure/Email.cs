//using MimeKit;
using System.Collections.Generic;
using System.Net.Mail;

namespace AppCore.Infrastructure
{
    public class Email
    {
        public Email()
        {
            ReplyTo = string.Empty;
            ToList = new List<string>();
            CCList = new List<string>();
            BccList = new List<string>();
            Attachments = new List<string>();
        }
        public Email(string to, string subject, string body) : this()
        {
            To = to;
            Subject = subject;
            Body = body;
        }
        public MailPriority Priority { get; set; }
        public string To { get; set; }
        public string Subject { get; set; }
        public string FromName { get; set; }
        public string FromEmail { get; set; }
        public string Body { get; set; }
        public string Phone { get; set; }
        public string ReplyTo { get; set; }
        public List<string> ToList { get; set; }
        public string CC { get; set; }
        public List<string> CCList { get; set; }
        public string Bcc { get; set; }
        public List<string> BccList { get; set; }

        //public List<Attachment> Attachments { get; set; }
        public List<string> Attachments { get; set; }
        public string MailTemplate { get;  set; }
    }
}
