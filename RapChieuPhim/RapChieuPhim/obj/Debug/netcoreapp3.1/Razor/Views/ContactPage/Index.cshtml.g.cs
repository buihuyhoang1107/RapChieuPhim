#pragma checksum "d:\Desktop\doan_asp\Liem\RapChieuPhim\RapChieuPhim\RapChieuPhim\Views\ContactPage\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b7adce6ba70516c7c1c3fc63b7b3e0a8083acb17"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_ContactPage_Index), @"mvc.1.0.view", @"/Views/ContactPage/Index.cshtml")]
namespace AspNetCore
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
#line 1 "d:\Desktop\doan_asp\Liem\RapChieuPhim\RapChieuPhim\RapChieuPhim\Views\_ViewImports.cshtml"
using RapChieuPhim;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "d:\Desktop\doan_asp\Liem\RapChieuPhim\RapChieuPhim\RapChieuPhim\Views\_ViewImports.cshtml"
using RapChieuPhim.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "d:\Desktop\doan_asp\Liem\RapChieuPhim\RapChieuPhim\RapChieuPhim\Views\_ViewImports.cshtml"
using RapChieuPhim.Areas.Admin.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b7adce6ba70516c7c1c3fc63b7b3e0a8083acb17", @"/Views/ContactPage/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ad80c071e32e25b1283406dd58bf453243598d01", @"/Views/_ViewImports.cshtml")]
    public class Views_ContactPage_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "d:\Desktop\doan_asp\Liem\RapChieuPhim\RapChieuPhim\RapChieuPhim\Views\ContactPage\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"main\">\r\n    ");
#nullable restore
#line 7 "d:\Desktop\doan_asp\Liem\RapChieuPhim\RapChieuPhim\RapChieuPhim\Views\ContactPage\Index.cshtml"
Write(await Html.PartialAsync("../Shared/_MenuPartial.cshtml"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    <div class=\"contact-content\">\r\n        ");
#nullable restore
#line 9 "d:\Desktop\doan_asp\Liem\RapChieuPhim\RapChieuPhim\RapChieuPhim\Views\ContactPage\Index.cshtml"
   Write(await Html.PartialAsync("../Shared/_TopHeaderPartial.cshtml"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        <!---contact-->\r\n        <div class=\"main-contact\">\r\n            <h3 class=\"head\">CONTACT</h3>\r\n            <p>WE\'RE ALWAYS HERE TO HELP YOU</p>\r\n            <div class=\"contact-form\">\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b7adce6ba70516c7c1c3fc63b7b3e0a8083acb174600", async() => {
                WriteLiteral(@"
                    <div class=""col-md-6 contact-left"">
                        <input type=""text"" placeholder=""Name"" required />
                        <input type=""text"" placeholder=""E-mail"" required />
                        <input type=""text"" placeholder=""Phone"" required />
                    </div>
                    <div class=""col-md-6 contact-right"">
                        <textarea placeholder=""Message""></textarea>
                        <input type=""submit"" value=""SEND"" />
                    </div>
                    <div class=""clearfix""></div>
                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
            </div>
            <div class=""contact_info"">
                <h3>Find Us Here</h3>
                <div class=""map"">
                    <iframe width=""100%"" frameborder=""0"" scrolling=""no"" marginheight=""0"" marginwidth=""0"" src=""https://maps.google.co.in/maps?f=q&amp;source=s_q&amp;hl=en&amp;geocode=&amp;q=Lighthouse+Point,+FL,+United+States&amp;aq=4&amp;oq=light&amp;sll=26.275636,-80.087265&amp;sspn=0.04941,0.104628&amp;ie=UTF8&amp;hq=&amp;hnear=Lighthouse+Point,+Broward,+Florida,+United+States&amp;t=m&amp;z=14&amp;ll=26.275636,-80.087265&amp;output=embed""></iframe><br><small><a href=""https://maps.google.co.in/maps?f=q&amp;source=embed&amp;hl=en&amp;geocode=&amp;q=Lighthouse+Point,+FL,+United+States&amp;aq=4&amp;oq=light&amp;sll=26.275636,-80.087265&amp;sspn=0.04941,0.104628&amp;ie=UTF8&amp;hq=&amp;hnear=Lighthouse+Point,+Broward,+Florida,+United+States&amp;t=m&amp;z=14&amp;ll=26.275636,-80.087265"" style=""color:#000;text-align:left;font-size:12px"">View Larger Map</a></small>
               ");
            WriteLiteral(" </div>\r\n            </div>\r\n        </div>\r\n        ");
#nullable restore
#line 35 "d:\Desktop\doan_asp\Liem\RapChieuPhim\RapChieuPhim\RapChieuPhim\Views\ContactPage\Index.cshtml"
   Write(await Html.PartialAsync("../Shared/_FooterPartial.cshtml"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n</div>\r\n<div class=\"clearfix\"></div>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
