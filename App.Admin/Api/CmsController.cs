using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Web.Configuration;
using System.Web.Http;
using System.Xml.Linq;

namespace DynamicData.Admin
{
    public class CmsController : ApiController
    {
        [HttpPost()]
        [ActionName("Update")]
        public string Update([FromBody]CmsUpdateModel updateModel)
        {
            if (File.Exists(updateModel.FilePath) == false)
            {
                return "Error could not load resource file.";
            }


            XDocument document = XDocument.Load(updateModel.FilePath);
            string text;
            if (string.IsNullOrEmpty(updateModel.Value))
                text = "";
            else
            {
                text = Regex.Replace(updateModel.Value, @"\r\n?|\n", "<br />");
            }

            document.Root.Descendants("data").Single(e => e.Attribute("name").Value == updateModel.Key.Trim())
                .SetElementValue("value", text);
            document.Save(updateModel.FilePath);
            return string.Empty;
        }
    }
}