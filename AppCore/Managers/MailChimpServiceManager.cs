using MailChimp.Net;
using MailChimp.Net.Interfaces;
using MailChimp.Net.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AppCore.Managers
{

    public class MailChimpServiceManager
    {
        private readonly IConfiguration configuration;

        public MailChimpServiceManager(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task<Common.Result> AddToMailChimp(string emailAddress)
        {
            var apiKey = configuration.GetValue<string>("MailChimpSettings:APIKey");

            if (string.IsNullOrWhiteSpace(apiKey))
            {
                return Common.Result.Fail("MailChimp Error Message : Missing API Key Value");
            }

            if (string.IsNullOrWhiteSpace(emailAddress))
            {
                return Common.Result.Fail("MailChimp Error Message : Missing Email Address");
            }


            IMailChimpManager mailChimpManager = new MailChimpManager(apiKey);

            var membersList = await mailChimpManager.Lists.GetAllAsync();

            var list = membersList.FirstOrDefault();

            var member = new Member
            {

                EmailAddress = emailAddress,
                StatusIfNew = Status.Pending,
                EmailType = "html",
                TimestampSignup = DateTime.UtcNow.ToString("yyyy-MM-dd hh:mm:ss")
            };

            try
            {
                var result = await mailChimpManager.Members.AddOrUpdateAsync(list.Id, member);
                return Common.Result.Ok();
            }

            catch (Exception ex)
            {
                return Common.Result.Fail("Subscribing Faild " + ex.Message);
            }
        }

    }
}