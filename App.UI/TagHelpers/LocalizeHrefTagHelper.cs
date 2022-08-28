using App.UI.InfraStructure;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Globalization;

namespace App.UI.TagHelpers
{
    [HtmlTargetElement("a", Attributes = HrefAttributeName, TagStructure = TagStructure.WithoutEndTag)]
    public class LocalizeHrefTagHelper : AnchorTagHelper
    {
        private const string HrefAttributeName = "asp-href";

        public LocalizeHrefTagHelper(IHtmlGenerator generator) : base(generator)
        {
        }

        [HtmlAttributeName(HrefAttributeName)]
        public string Url { get; set; }


        public override void Process(TagHelperContext context, TagHelperOutput output)
        {

            var localizedUrl = CurrentCulture + Url;

            if (!output.Attributes.TryGetAttribute("href", out var hrefAttribute))
            {
                output.Attributes.Add(new TagHelperAttribute("href", localizedUrl));
            }

        }

        private string CurrentCulture
        {
            get
            {
                return (CultureInfo.CurrentCulture.TwoLetterISOLanguageName == "en") ?
                        string.Empty : $"/{CultureInfo.CurrentCulture.TwoLetterISOLanguageName}";
            }
        }
    }
}
