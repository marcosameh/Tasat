#pragma checksum "D:\Clients\Tasat\App.UI\Pages\contact-us.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b7869b4e4d9ffc99030a9bea0fbefb0563fd3fdb"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(App.UI.Pages.Pages_contact_us), @"mvc.1.0.razor-page", @"/Pages/contact-us.cshtml")]
namespace App.UI.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 3 "D:\Clients\Tasat\App.UI\Pages\contact-us.cshtml"
using Microsoft.Extensions.Configuration;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\Clients\Tasat\App.UI\Pages\contact-us.cshtml"
using System.Globalization;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b7869b4e4d9ffc99030a9bea0fbefb0563fd3fdb", @"/Pages/contact-us.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2d2353c98d07138744ff1f08855de090011924f0", @"/Pages/_ViewImports.cshtml")]
    #nullable restore
    public class Pages_contact_us : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral("\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n    <script");
                BeginWriteAttribute("src", " src=\"", 311, "\"", 442, 3);
                WriteAttributeValue("", 317, "/lib/jQuery-Validation-Engine/languages/jquery.validationEngine-", 317, 64, true);
#nullable restore
#line 11 "D:\Clients\Tasat\App.UI\Pages\contact-us.cshtml"
WriteAttributeValue("", 381, CultureInfo.CurrentCulture.TwoLetterISOLanguageName, 381, 54, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 435, ".min.js", 435, 7, true);
                EndWriteAttribute();
                WriteLiteral(@"></script>
    <script src=""/lib/jQuery-Validation-Engine/jquery.validationEngine.min.js""></script>
    <script src=""/lib/toastr.js/toastr.min.js""></script>

    <script>
        function form_validate() {
            var isValid = $('#contact-form').validationEngine('validate');
            if (isValid) {
                if (grecaptcha.getResponse() == """") {
                    alert(""Please complete 'I am not a robot' test"");
                    return false;
                }
                return true;
            }
            return false;
        }
    </script>
");
            }
            );
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public IConfiguration Configuration { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<App.UI.contactusModel> Html { get; private set; } = default!;
        #nullable disable
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<App.UI.contactusModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<App.UI.contactusModel>)PageContext?.ViewData;
        public App.UI.contactusModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
