#pragma checksum "D:\Clients\Tasat\App.UI\Pages\MailTemplates\ContactUs.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "bee12434d15fa07e0e8f549178b39be7681bbbb7"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(App.UI.Pages.MailTemplates.Pages_MailTemplates_ContactUs), @"mvc.1.0.view", @"/Pages/MailTemplates/ContactUs.cshtml")]
namespace App.UI.Pages.MailTemplates
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bee12434d15fa07e0e8f549178b39be7681bbbb7", @"/Pages/MailTemplates/ContactUs.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2d2353c98d07138744ff1f08855de090011924f0", @"/Pages/_ViewImports.cshtml")]
    #nullable restore
    public class Pages_MailTemplates_ContactUs : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<App.UI.Models.ContactUsEmail>
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n\r\n\r\n<!DOCTYPE HTML PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\">\r\n<html xmlns=\"http://www.w3.org/1999/xhtml\">\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bee12434d15fa07e0e8f549178b39be7681bbbb73164", async() => {
                WriteLiteral(@"
    <meta http-equiv=""X-UA-Compatible"" content=""IE=edge"" />
    <meta http-equiv=""Content-Type"" content=""text/html; charset=utf-8"" />
    <meta name=""viewport"" content=""width=device-width, initial-scale=1, minimum-scale=1, maximum-scale=1"" />
    <title>
        ");
#nullable restore
#line 12 "D:\Clients\Tasat\App.UI\Pages\MailTemplates\ContactUs.cshtml"
   Write(Model.BusinessName);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
    </title>
    <style type=""text/css"">
        .ReadMsgBody {
            width: 100%;
            background-color: #ffffff;
        }

        .ExternalClass {
            width: 100%;
            background-color: #ffffff;
        }

            .ExternalClass, .ExternalClass p, .ExternalClass span, .ExternalClass font, .ExternalClass td, .ExternalClass div {
                line-height: 100%;
            }

        html {
            width: 100%;
        }

        body {
            -webkit-text-size-adjust: none;
            -ms-text-size-adjust: none;
            margin: 0;
            padding: 0;
        }

        table {
            border-spacing: 0;
            border-collapse: collapse;
            table-layout: fixed;
            margin: 0 auto;
        }

            table table table {
                table-layout: auto;
            }

        img {
            display: block !important;
        }

        table td {
            border-collapse: c");
                WriteLiteral(@"ollapse;
        }

        .yshortcuts a {
            border-bottom: none !important;
        }

        img:hover {
            opacity: 0.9 !important;
        }

        a {
            text-decoration: none;
        }

        .textbutton a {
            font-family: 'open sans', arial, sans-serif !important;
            color: #ffffff !important;
        }

        .text-link a {
            color: #95a5a6 !important;
        }

        ");
                WriteLiteral(@"@media only screen and (max-width: 640px) {
            body {
                width: auto !important;
            }

            table[class=""table-inner""] {
                width: 90% !important;
            }

            table[class=""table-full""] {
                width: 100% !important;
                text-align: center !important;
            }
        }

        ");
                WriteLiteral(@"@media only screen and (max-width: 479px) {
            body {
                width: auto !important;
            }

            table[class=""table-inner""] {
                width: 90% !important;
            }

            table[class=""table-full""] {
                width: 100% !important;
                text-align: center !important;
            }
        }
    </style>
");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bee12434d15fa07e0e8f549178b39be7681bbbb77011", async() => {
                WriteLiteral("\r\n    <table width=\"100%\" border=\"0\" align=\"center\" cellpadding=\"0\" cellspacing=\"0\" bgcolor=\"#494c50\">\r\n        <tr>\r\n            <td align=\"center\"");
                BeginWriteAttribute("background", " background=\"", 2946, "\"", 3003, 2);
#nullable restore
#line 114 "D:\Clients\Tasat\App.UI\Pages\MailTemplates\ContactUs.cshtml"
WriteAttributeValue("", 2959, Model.HostName, 2959, 15, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 2974, "/images/mail-templates/bg.jpg", 2974, 29, true);
                EndWriteAttribute();
                WriteLiteral(@" style=""background-size:cover; background-position:top;"">
                <table class=""table-inner"" width=""600"" border=""0"" align=""center"" cellpadding=""0"" cellspacing=""0"">
                    <tr>
                        <td height=""60""></td>
                    </tr>
                    <tr>
                        <td align=""center"">
                            <table align=""center"" bgcolor=""#FFFFFF"" style=""border-radius:0; box-shadow: 0px 3px 0px #d4d2d2;"" width=""100%"" border=""0"" cellspacing=""0"" cellpadding=""0"">
                                <tr>
                                    <td height=""40""></td>
                                </tr>
                                <!-- logo -->
                                <tr>
                                    <td align=""center"" style=""line-height: 0px;"">

                                        <table class=""textbutton"" align=""center"" border=""0"" cellspacing=""0"" cellpadding=""0"">
                                            <tr>
             ");
                WriteLiteral("                                   <td height=\"55\" align=\"center\" style=\"font-family: \'Open Sans\', Arial, sans-serif; font-size:16px; font-weight: bold;padding-left: 25px;padding-right: 25px\"><a");
                BeginWriteAttribute("href", " href=\"", 4222, "\"", 4244, 1);
#nullable restore
#line 131 "D:\Clients\Tasat\App.UI\Pages\MailTemplates\ContactUs.cshtml"
WriteAttributeValue("", 4229, Model.HostName, 4229, 15, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" target=\"_blank\"><img style=\"display:block; line-height:0px; font-size:0px; border:0px;\"");
                BeginWriteAttribute("src", " src=\"", 4333, "\"", 4381, 1);
#nullable restore
#line 131 "D:\Clients\Tasat\App.UI\Pages\MailTemplates\ContactUs.cshtml"
WriteAttributeValue("", 4339, $"{Model.HostName}{Model.LogoFullPath}", 4339, 42, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@" /></a></td>
                                            </tr>
                                        </table>

                                    </td>
                                </tr>
                                <!-- end logo -->
                                <tr>
                                    <td height=""15""></td>
                                </tr>
                                <!-- slogan -->
                                <tr>
                                    <td align=""center"" style=""font-family: 'Open Sans', Arial, sans-serif; font-size:12px; color:#3b3b3b; text-transform:uppercase; letter-spacing:2px; font-weight: normal;"">
                                        ");
#nullable restore
#line 144 "D:\Clients\Tasat\App.UI\Pages\MailTemplates\ContactUs.cshtml"
                                   Write(Model.BusinessName);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
                                    </td>
                                </tr>
                                <!-- end slogan -->
                                <tr>
                                    <td height=""40""></td>
                                </tr>
                                <tr>
                                    <td align=""center"" bgcolor=""#f3f3f3"">
                                        <table align=""center"" class=""table-inner"" width=""500"" border=""0"" cellspacing=""0"" cellpadding=""0"">
                                            <tr>
                                                <td height=""50""></td>
                                            </tr>
                                            <!-- title -->
                                            <tr>
                                                <td align=""center"" style=""font-family: 'Open Sans', Arial, sans-serif; font-size:23px; color:#3b3b3b; font-weight: bold; letter-spacing:4px;"">
                         ");
                WriteLiteral("                           ");
#nullable restore
#line 160 "D:\Clients\Tasat\App.UI\Pages\MailTemplates\ContactUs.cshtml"
                                               Write(Model.Title);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
                                                </td>
                                            </tr>
                                            <!-- end title -->
                                            <tr>
                                                <td align=""center"">
                                                    <table width=""25"" border=""0"" cellspacing=""0"" cellpadding=""0"">
                                                        <tr>
                                                            <td height=""15"" style=""border-bottom:2px solid #3bb5e8;""></td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td height=""20""></td>
                                            </tr>
                             ");
                WriteLiteral(@"               <!-- content -->
                                            <tr>
                                                <td align=""left"" style=""font-family: 'Open Sans', Arial, sans-serif; font-size:13px; color:#7f8c8d;"">
                                                    Dear Administrator,
                                                    <br /><br />
                                                    The following email has been sent by:
                                                    <br />
                                                    ");
#nullable restore
#line 183 "D:\Clients\Tasat\App.UI\Pages\MailTemplates\ContactUs.cshtml"
                                               Write(Model.FullName);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                                    <br />\r\n                                                    <b>Country:</b> ");
#nullable restore
#line 185 "D:\Clients\Tasat\App.UI\Pages\MailTemplates\ContactUs.cshtml"
                                                               Write(Model.Country);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                                    <br />\r\n                                                    <b>Email:</b> ");
#nullable restore
#line 187 "D:\Clients\Tasat\App.UI\Pages\MailTemplates\ContactUs.cshtml"
                                                             Write(Model.Email);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                                    <br />\r\n                                                    <b>Phone:</b> ");
#nullable restore
#line 189 "D:\Clients\Tasat\App.UI\Pages\MailTemplates\ContactUs.cshtml"
                                                             Write(Model.Phone);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                                    <br />\r\n                                                    <b>Subject:</b> ");
#nullable restore
#line 191 "D:\Clients\Tasat\App.UI\Pages\MailTemplates\ContactUs.cshtml"
                                                               Write(Model.Subject);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                                    <br />\r\n                                                    <b>Message:</b> ");
#nullable restore
#line 193 "D:\Clients\Tasat\App.UI\Pages\MailTemplates\ContactUs.cshtml"
                                                               Write(Model.Message);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
                                                    <br />
                                                    <br />
                                                    Please don't reply directly to this email, this is a system generated message.
                                                </td>
                                            </tr>
                                            <!-- end content -->
                                            <tr>
                                                <td height=""50""></td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td height=""40""></td>
                                </tr>
                                <!-- end option -->
                            </table>
                        </td>
                    </tr>
         ");
                WriteLiteral(@"           <tr>
                        <td height=""30""></td>
                    </tr>
                    <!-- copyright -->
                    <tr>
                        <td align=""center"" style=""font-family: 'Open Sans', Arial, sans-serif; font-size:13px; color:#ffffff;""> ?? ");
#nullable restore
#line 218 "D:\Clients\Tasat\App.UI\Pages\MailTemplates\ContactUs.cshtml"
                                                                                                                             Write(DateTime.Today.Year);

#line default
#line hidden
#nullable disable
                WriteLiteral(" <a");
                BeginWriteAttribute("href", " href=\"", 9846, "\"", 9871, 1);
#nullable restore
#line 218 "D:\Clients\Tasat\App.UI\Pages\MailTemplates\ContactUs.cshtml"
WriteAttributeValue("", 9853, Model.WebsiteLink, 9853, 18, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" style=\"color:#3cb2d0; text-decoration: none\" target=\"_blank\">");
#nullable restore
#line 218 "D:\Clients\Tasat\App.UI\Pages\MailTemplates\ContactUs.cshtml"
                                                                                                                                                                                                                                            Write(Model.WebsiteText);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"</a> | All Rights Reserved.  </td>
                    </tr>
                    <!-- end copyright -->
                    <tr>
                        <td height=""25""></td>
                    </tr>
                    <!-- social -->
                    <tr>
                        <td align=""center"">
                            <table align=""center"" width=""80"" border=""0"" cellspacing=""0"" cellpadding=""0"">
                                <tr>
");
#nullable restore
#line 229 "D:\Clients\Tasat\App.UI\Pages\MailTemplates\ContactUs.cshtml"
                                      
                                        if (!string.IsNullOrEmpty(Model.FacebookLink))
                                        {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                            <td width=\"10\" align=\"center\" style=\"line-height:0px;\">\r\n                                                <a");
                BeginWriteAttribute("href", " href=\"", 10733, "\"", 10759, 1);
#nullable restore
#line 233 "D:\Clients\Tasat\App.UI\Pages\MailTemplates\ContactUs.cshtml"
WriteAttributeValue("", 10740, Model.FacebookLink, 10740, 19, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" target=\"_blank\">\r\n                                                    <img style=\"display:block; line-height:0px; font-size:0px; border:0px;\"");
                BeginWriteAttribute("src", "\r\n                                                         src=\"", 10902, "\"", 11016, 2);
#nullable restore
#line 235 "D:\Clients\Tasat\App.UI\Pages\MailTemplates\ContactUs.cshtml"
WriteAttributeValue("", 10966, Model.HostName, 10966, 15, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 10981, "/images/mail-templates/facebook.png", 10981, 35, true);
                EndWriteAttribute();
                WriteLiteral(" alt=\"img\" />\r\n                                                </a>\r\n                                            </td>\r\n");
#nullable restore
#line 238 "D:\Clients\Tasat\App.UI\Pages\MailTemplates\ContactUs.cshtml"
                                        }
                                    

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n");
#nullable restore
#line 241 "D:\Clients\Tasat\App.UI\Pages\MailTemplates\ContactUs.cshtml"
                                      
                                        if (!string.IsNullOrEmpty(Model.TwitterLink))
                                        {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                            <td width=\"10\" align=\"center\" style=\"line-height:0px;\">\r\n                                                <a");
                BeginWriteAttribute("href", " href=\"", 11542, "\"", 11567, 1);
#nullable restore
#line 245 "D:\Clients\Tasat\App.UI\Pages\MailTemplates\ContactUs.cshtml"
WriteAttributeValue("", 11549, Model.TwitterLink, 11549, 18, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" target=\"_blank\">\r\n                                                    <img style=\"display:block; line-height:0px; font-size:0px; border:0px;\"");
                BeginWriteAttribute("src", " src=\"", 11710, "\"", 11765, 2);
#nullable restore
#line 246 "D:\Clients\Tasat\App.UI\Pages\MailTemplates\ContactUs.cshtml"
WriteAttributeValue("", 11716, Model.HostName, 11716, 15, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 11731, "/images/mail-templates/twitter.png", 11731, 34, true);
                EndWriteAttribute();
                WriteLiteral(" alt=\"img\" />\r\n                                                </a>\r\n                                            </td>\r\n");
#nullable restore
#line 249 "D:\Clients\Tasat\App.UI\Pages\MailTemplates\ContactUs.cshtml"
                                        }
                                    

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                                </tr>
                            </table>
                        </td>
                    </tr>
                    <!-- end social -->
                    <tr>
                        <td height=""45""></td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</html>");
        }
        #pragma warning restore 1998
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<App.UI.Models.ContactUsEmail> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
