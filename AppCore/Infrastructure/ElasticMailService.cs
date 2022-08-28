using AppCore.Common;
using AppCore.Contracts;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Net.Http;

namespace AppCore.Infrastructure
{
    public class ElasticMailSettings
    {
        public string ApiKey { get; set; }
        public string FromName { get; set; }
        public string FromEmail { get; set; }
    }

    public class ElasticMailService : ISendMail
    {

        private readonly IConfiguration _config;
        private readonly ElasticMailSettings _settings;

        public ElasticMailService(IConfiguration config)
        {
            _config = config;

            _settings = new ElasticMailSettings
            {
                ApiKey = _config.GetValue<string>("MailSettings:APIKey"),
                FromEmail = _config.GetValue<string>("MailSettings:FromEmail"),
                FromName = _config.GetValue<string>("MailSettings:FromName")
            };

            if (string.IsNullOrWhiteSpace(_settings.ApiKey))
                throw new Exception("Elastic Mail Service Error : Missing APIKey Property");

            if (string.IsNullOrWhiteSpace(_settings.FromEmail))
                throw new Exception("Elastic Mail Service Error : Missing FromEmail Property");

            if (string.IsNullOrWhiteSpace(_settings.FromName))
                throw new Exception("Elastic Mail Service Error : Missing FromName Property");
        }



        public Result Send(Email email)
        {
            NameValueCollection values = new NameValueCollection();
            values.Add("apikey", _settings.ApiKey);
            values.Add("from", _settings.FromEmail);
            values.Add("fromName", _settings.FromName);
            values.Add("msgTo", email.To);
            values.Add("isTransactional", "true");

            if (string.IsNullOrEmpty(email.CC) == false)
            {
                email.CCList.Add(email.CC);
                values.Add("msgCC", string.Join(",", email.CCList));
            }
            if (string.IsNullOrEmpty(email.Bcc) == false)
            {
                email.BccList.Add(email.Bcc);
                values.Add("msgBcc", string.Join(",", email.BccList));
            }

            values.Add("replyTo", email.ReplyTo);
            values.Add("subject", email.Subject);
            values.Add("bodyText", "Text Body");
            values.Add("bodyHtml", email.Body);

            values.Add("isTransactional", true.ToString());
            var URL = "https://api.elasticemail.com/v2/email/send";


            string result = Upload(URL, values, null, null);

            var data = (JObject)JsonConvert.DeserializeObject(result);
            bool success = (bool)data["success"];
            if (success)
            {
                return Result.Ok();
            }

            return Result.Fail(data["error"].ToString());

        }

        private string Send(string address, NameValueCollection values)
        {
            using (WebClient client = new WebClient())
            {
                try
                {
                    byte[] apiResponse = client.UploadValues(address, values);
                    return System.Text.Encoding.UTF8.GetString(apiResponse);
                }
                catch (Exception ex)
                {
                    return "Exception caught: " + ex.Message + "\n" + ex.StackTrace;
                }
            }
        }

        public static string Upload(string actionUrl, NameValueCollection values, Stream[] paramFileStream = null, string[] filenames = null)
        {
            using (var client = new HttpClient())
            using (var formData = new MultipartFormDataContent())
            {
                foreach (string key in values)
                {
                    HttpContent stringContent = new StringContent(values[key]);
                    formData.Add(stringContent, key);
                }

                //for (int i = 0; i < paramFileStream.Length; i++)
                //{
                //    HttpContent fileStreamContent = new StreamContent(paramFileStream[i]);
                //    formData.Add(fileStreamContent, "file" + i, filenames[i]);
                //}

                var response = client.PostAsync(actionUrl, formData).Result;
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception(response.Content.ReadAsStringAsync().Result);
                }

                return response.Content.ReadAsStringAsync().Result;
            }
        }


    }
}
