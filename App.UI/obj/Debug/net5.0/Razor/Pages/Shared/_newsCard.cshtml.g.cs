#pragma checksum "D:\Clients\Tasat\App.UI\Pages\Shared\_newsCard.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e4f6c79257b3ebbd410fe72458df13208f2de033"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(App.UI.Pages.Shared.Pages_Shared__newsCard), @"mvc.1.0.view", @"/Pages/Shared/_newsCard.cshtml")]
namespace App.UI.Pages.Shared
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
#line 1 "D:\Clients\Tasat\App.UI\Pages\Shared\_newsCard.cshtml"
using Microsoft.Extensions.Configuration;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Clients\Tasat\App.UI\Pages\Shared\_newsCard.cshtml"
using AppCore.Utilities;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e4f6c79257b3ebbd410fe72458df13208f2de033", @"/Pages/Shared/_newsCard.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2d2353c98d07138744ff1f08855de090011924f0", @"/Pages/_ViewImports.cshtml")]
    #nullable restore
    public class Pages_Shared__newsCard : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<AppCore.DTO.NewsArchive>>
    #nullable disable
    {
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::App.UI.TagHelpers.LocalizeHrefTagHelper __App_UI_TagHelpers_LocalizeHrefTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 7 "D:\Clients\Tasat\App.UI\Pages\Shared\_newsCard.cshtml"
 foreach (var item in Model)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <!------ Card ------>\r\n    <div class=\"card\">\r\n        <!------ Card Header------>\r\n        <div class=\"card-header\">\r\n            <button class=\"btn\" type=\"button\" data-toggle=\"collapse\" data-target=\"");
#nullable restore
#line 13 "D:\Clients\Tasat\App.UI\Pages\Shared\_newsCard.cshtml"
                                                                             Write(item.Year);

#line default
#line hidden
#nullable disable
            WriteLiteral("\" aria-expanded=\"true\"");
            BeginWriteAttribute("aria-controls", " aria-controls=\"", 427, "\"", 453, 1);
#nullable restore
#line 13 "D:\Clients\Tasat\App.UI\Pages\Shared\_newsCard.cshtml"
WriteAttributeValue("", 443, item.Year, 443, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                ");
#nullable restore
#line 14 "D:\Clients\Tasat\App.UI\Pages\Shared\_newsCard.cshtml"
           Write(item.Year);

#line default
#line hidden
#nullable disable
            WriteLiteral(" <i class=\"flaticon-minus-symbol float-right\"></i>\r\n                <i class=\"flaticon-add float-right\"></i>\r\n            </button>\r\n        </div>\r\n        <!------ Collapse ------>\r\n        <div class=\"collapse show\"");
            BeginWriteAttribute("id", " id=\"", 701, "\"", 716, 1);
#nullable restore
#line 19 "D:\Clients\Tasat\App.UI\Pages\Shared\_newsCard.cshtml"
WriteAttributeValue("", 706, item.Year, 706, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n            <div class=\"card-body\">\r\n");
#nullable restore
#line 21 "D:\Clients\Tasat\App.UI\Pages\Shared\_newsCard.cshtml"
                 foreach (var month in item.Months)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "e4f6c79257b3ebbd410fe72458df13208f2de0335246", async() => {
            }
            );
            __App_UI_TagHelpers_LocalizeHrefTagHelper = CreateTagHelper<global::App.UI.TagHelpers.LocalizeHrefTagHelper>();
            __tagHelperExecutionContext.Add(__App_UI_TagHelpers_LocalizeHrefTagHelper);
            BeginWriteTagHelperAttribute();
            WriteLiteral("/news/");
#nullable restore
#line 23 "D:\Clients\Tasat\App.UI\Pages\Shared\_newsCard.cshtml"
                           WriteLiteral(month.Year);

#line default
#line hidden
#nullable disable
            WriteLiteral("/");
#nullable restore
#line 23 "D:\Clients\Tasat\App.UI\Pages\Shared\_newsCard.cshtml"
                                       WriteLiteral(month.Month);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __App_UI_TagHelpers_LocalizeHrefTagHelper.Url = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-href", __App_UI_TagHelpers_LocalizeHrefTagHelper.Url, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
#nullable restore
#line 23 "D:\Clients\Tasat\App.UI\Pages\Shared\_newsCard.cshtml"
                                                            Write(month.Month.ToMonthName());

#line default
#line hidden
#nullable disable
            WriteLiteral(" <span>(");
#nullable restore
#line 23 "D:\Clients\Tasat\App.UI\Pages\Shared\_newsCard.cshtml"
                                                                                              Write(month.NewsCount);

#line default
#line hidden
#nullable disable
            WriteLiteral(")</span></a>\r\n");
#nullable restore
#line 24 "D:\Clients\Tasat\App.UI\Pages\Shared\_newsCard.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n    </div>\r\n");
#nullable restore
#line 29 "D:\Clients\Tasat\App.UI\Pages\Shared\_newsCard.cshtml"
}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<AppCore.DTO.NewsArchive>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
