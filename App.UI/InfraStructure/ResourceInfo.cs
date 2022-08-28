using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace App.UI.InfraStructure
{
    public class ResourceInfo
    {
        private readonly IWebHostEnvironment environment;
        private readonly IActionContextAccessor actionContextAccessor;


        public ResourceInfo(IWebHostEnvironment environment, IActionContextAccessor actionContextAccessor)
        {
            this.environment = environment;
            this.actionContextAccessor = actionContextAccessor;
        }

        public IEnumerable<FileInfo> ResourceFilesList
        {
            get
            {
                return new DirectoryInfo(environment.WebRootPath).GetDirectories()
                    .FirstOrDefault(d => d.GetFiles("*.resx").Any()).GetFiles(string.Empty, SearchOption.AllDirectories);
            }

        }

        public string PageName
        {
            get
            {
                return actionContextAccessor.ActionContext.ActionDescriptor.DisplayName;
            }
        }

        public string SimplePageName
        {
            get
            {
                if(PageName.Split("/").Length == 1)
                {
                    return $"resources{PageName}";
                }
                return PageName.Substring(1).ToLower();
            }
        }

        public string GetLocalizedString(string currentLanguage, string Key)
        {

            var pageLanguageFiles = ResourceFilesList
                .Where(x =>
                 $"{x.Directory.Name}/{x.Name}".ToLower().Contains($"{SimplePageName}{currentLanguage.ToLower()}"));

            foreach (var file in pageLanguageFiles)
            {
                return ReadResourceFiles(file.FullName)?.FirstOrDefault(r => r.Key == Key)?.Value;
            }

            return string.Empty;
        }

        public string GetLocalizedLayoutString(string currentLanguage, string Key)
        {
            var pageLanguageFiles = ResourceFilesList
                .Where(x =>
                x.Name.ToLower()== $"_layout{currentLanguage.ToLower()}.resx");

            foreach (var file in pageLanguageFiles)
            {
                return ReadResourceFiles(file.FullName)?.FirstOrDefault(r => r.Key == Key)?.Value;
            }

            return string.Empty;
        }

        public string GetLocalizedSharedString(string currentLanguage, string Key)
        {
            var pageLanguageFiles = ResourceFilesList
                           .Where(x =>
                         x.Name.ToLower() == $"_shared{currentLanguage.ToLower()}.resx");

            foreach (var file in pageLanguageFiles)
            {
                return ReadResourceFiles(file.FullName)?.FirstOrDefault(r => r.Key == Key)?.Value;
            }

            return string.Empty;
        }

        private IEnumerable<ResourceData> ReadResourceFiles(string filePath)
        {

            XDocument document = XDocument.Load(filePath);

            var resources = from resource in document.Descendants("data")
                            select new ResourceData
                            {
                                Key = resource.Attribute("name").Value,
                                Value = resource.Element("value") == null ? string.Empty : resource.Element("value").Value,
                                Hint = resource.Element("comment") == null ? string.Empty : resource.Element("comment").Value
                            };
            return resources;

        }
    }
}
