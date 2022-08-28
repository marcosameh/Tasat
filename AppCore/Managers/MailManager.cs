using AppCore.Common;
using AppCore.Contracts;
using AppCore.DTO;
using AppCore.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace AppCore.Managers
{
    public class MailManager
    {
        private readonly IViewRenderService _renderService;
        private readonly ISendMail _sendMailService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IConfiguration _configuration;
        private readonly BusinessInfoManager _businessInfoManager;
       
        public MailManager(IViewRenderService renderService, ISendMail sendMailService,
            IHttpContextAccessor httpContextAccessor, IConfiguration  configuration,
            BusinessInfoManager businessInfoManager)
        {
            _renderService = renderService;
            _sendMailService = sendMailService;
            _httpContextAccessor = httpContextAccessor;
            _configuration = configuration;
            _businessInfoManager = businessInfoManager;
        }
        public Result SendRequest(MailInfo mailInfo)
        {

            PopulateEmailModel(mailInfo.Model, mailInfo.Title);

            var body = _renderService.RenderToStringAsync(mailInfo.TemplateName, mailInfo.Model).Result;

            if (mailInfo.ToList == null) mailInfo.ToList = new List<string>();

            if (mailInfo.CCMails == null) mailInfo.CCMails = new List<string>();

            Email request = new Email
            {
                To = !string.IsNullOrWhiteSpace(mailInfo.ToMail) ? mailInfo.ToMail : "",
                ToList = mailInfo.ToList.Count > 0 ? mailInfo.ToList : null,
                Body = body,
                Subject = mailInfo.Subject,
                CCList = mailInfo.CCMails
            };

            return _sendMailService.Send(request);

        }
      
        private Result PopulateEmailModel(dynamic model, string title)
        {
            var socialMediaInfo = _businessInfoManager.GetSocialMediaInfo();
            var domainName = _httpContextAccessor.HttpContext.Request.Scheme + "://" + _httpContextAccessor.HttpContext.Request.Host.Value;
           
            var siteLogo = _configuration.GetValue<string>("BusinessDetails:SiteLogo");
            var businessName = _configuration.GetValue<string>("BusinessDetails:BusinessName");

            try
            {
                model.Title = title;
                model.BusinessName = businessName;
                model.TwitterLink = socialMediaInfo.TwitterLink;
                model.FacebookLink = socialMediaInfo.FacebookLink;
                model.LogoFullPath = siteLogo;
                model.HostName = domainName;

                return Result.Ok();
            }
            catch (System.Exception ex)
            {

                return Result.Fail(ex.Message);
            }
          
        }
    }
}
