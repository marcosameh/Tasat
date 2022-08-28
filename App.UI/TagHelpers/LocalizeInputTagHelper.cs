using App.UI.InfraStructure;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Globalization;

namespace App.UI.TagHelpers
{
    [HtmlTargetElement("input", Attributes = PlaceholderAttributeName, TagStructure = TagStructure.WithoutEndTag)]
    [HtmlTargetElement("textarea", Attributes = PlaceholderAttributeName, TagStructure = TagStructure.NormalOrSelfClosing)]
    public class LocalizeInputTagHelper : InputTagHelper
    {
        private const string PlaceholderAttributeName = "asp-placeholder";
       
        private readonly ResourceInfo resourceInfo;

        public LocalizeInputTagHelper(IHtmlGenerator generator, ResourceInfo resourceInfo) : base(generator)
        {
            this.resourceInfo = resourceInfo;
        }

        [HtmlAttributeName(PlaceholderAttributeName)]
        public string Key { get; set; }


       public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            string currentLanguage = GetCurrentLanguage();
            
            string localizedString = resourceInfo.GetLocalizedString(currentLanguage, Key);

            if (string.IsNullOrEmpty(localizedString))
            {
                localizedString = resourceInfo.GetLocalizedLayoutString(currentLanguage, Key);
            }

            if (!output.Attributes.TryGetAttribute("placeholder", out _))
            {
                output.Attributes.Add(new TagHelperAttribute("placeholder", localizedString ?? Key));
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
