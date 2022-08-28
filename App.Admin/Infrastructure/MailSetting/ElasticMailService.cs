using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Net.Http;

namespace DynamicData.Admin.Infrastructure.MailSetting
{
    public class ElasticMailSettings : IMailSettings
    {
        public string ApiKey { get; set; }
        public string FromName { get; set; }
        public string FromEmail { get; set; }
    }

    public class ElasticMailService : IMailer
    {
        public IMailSettings MailSettings { get; set; }
        private ElasticMailSettings _settings = null;


        public ElasticMailService()
        {
            _settings = new ElasticMailSettings
            {
                ApiKey = "80b67d7a-54f5-4319-a5dd-65532ad20911",
                FromName = "Admin",
                FromEmail = "info@innovixsolutions.com"
            };
        }

        public ElasticMailService(ElasticMailSettings mailSettings)
        {
            _settings = mailSettings;
        }

        public void Send(Email email)
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

            var filesStreams = new List<Stream>();
            var fileNames = new List<string>();
            foreach (var attachment in email.Attachments)
            {
                filesStreams.Add(attachment.ContentStream);
                fileNames.Add(attachment.Name);
            }

            string result = Upload(URL, values, filesStreams.ToArray(), fileNames.ToArray());

            //string result = Send(address, values);
            var data = (JObject)JsonConvert.DeserializeObject(result);
            bool success = (bool)data["success"];
            if (!success)
            {
                throw new Exception(data["error"].ToString());
            }
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

                for (int i = 0; i < paramFileStream.Length; i++)
                {
                    HttpContent fileStreamContent = new StreamContent(paramFileStream[i]);
                    formData.Add(fileStreamContent, "file" + i, filenames[i]);
                }

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
