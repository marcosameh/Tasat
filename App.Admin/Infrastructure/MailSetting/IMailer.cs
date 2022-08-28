namespace DynamicData.Admin.Infrastructure.MailSetting
{
    interface IMailer
    {
        IMailSettings MailSettings { get; set; }

        void Send(Email email);
    }
}
