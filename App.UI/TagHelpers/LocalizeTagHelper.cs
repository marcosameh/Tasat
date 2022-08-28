using App.UI.InfraStructure;
using AppCore.Utilities;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Globalization;

namespace App.UI.TagHelpers
{
    [HtmlTargetElement("localize", TagStructure = TagStructure.WithoutEndTag)]
    public class LocalizeTagHelper : TagHelper
    {
        private readonly ResourceInfo resourceInfo;


        public LocalizeTagHelper(ResourceInfo resourceInfo)
        {
            this.resourceInfo = resourceInfo;
        }


        public string DefaultText { get; set; }
        public string Key { get; set; }
        public bool ToList { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var currentLanguage = GetCurrentLanguage();

            var localizedString = resourceInfo.GetLocalizedString(currentLanguage, Key);

            if (string.IsNullOrEmpty(localizedString))
            {
                localizedString = resourceInfo.GetLocalizedLayoutString(currentLanguage, Key);
            }

            output.TagName = null;

            if (!ToList)
            {
                output.Content.AppendHtml(string.IsNullOrEmpty(localizedString) ? DefaultText : localizedString);

            }
            else
            {
                if (!string.IsNullOrEmpty(localizedString))
                {
                    output.Content.AppendHtml(StringUtilities.TextToListItems(localizedString));
                }
                else
                {
                    output.Content.AppendHtml(StringUtilities.TextToListItems(DefaultText));
                }
            }
        }

        private string GetCurrentLanguage()
        {
            if (CultureInfo.CurrentUICulture.IetfLanguageTag == "en-US" || CultureInfo.CurrentUICulture.IetfLanguageTag == null)
            {
                return ".en-GB";
            }
            else
            {
                return "." + CultureInfo.CurrentUICulture.IetfLanguageTag;
            }
        }
    }
}

