namespace DynamicData.Admin.Infrastructure.MailSetting
{
    public class MailSettings : IMailSettings
    {
        public bool EnableSSL { get; set; }
        public string FromEmail { get; set; }
        public string FromName { get; set; }
        public string SmtpHost { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public int Port { get; set; }
    }
}
