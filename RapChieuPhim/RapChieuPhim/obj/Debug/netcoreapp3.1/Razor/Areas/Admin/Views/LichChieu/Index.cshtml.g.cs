#pragma checksum "D:\Desktop\doan_asp\Liemv2\RapChieuPhim\RapChieuPhim\Areas\Admin\Views\LichChieu\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7d11868924edaea5f01c97f10c3a19cc3c8b6c19"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_LichChieu_Index), @"mvc.1.0.view", @"/Areas/Admin/Views/LichChieu/Index.cshtml")]
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
#line 1 "D:\Desktop\doan_asp\Liemv2\RapChieuPhim\RapChieuPhim\Areas\Admin\_ViewImports.cshtml"
using RapChieuPhim;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Desktop\doan_asp\Liemv2\RapChieuPhim\RapChieuPhim\Areas\Admin\_ViewImports.cshtml"
using RapChieuPhim.Areas.Admin.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7d11868924edaea5f01c97f10c3a19cc3c8b6c19", @"/Areas/Admin/Views/LichChieu/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c5bfc023d8a92709f80b53d4defb67cfa305c594", @"/Areas/Admin/_ViewImports.cshtml")]
    public class Areas_Admin_Views_LichChieu_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<RapChieuPhim.Areas.Admin.Models.LichChieuModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Details", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\Desktop\doan_asp\Liemv2\RapChieuPhim\RapChieuPhim\Areas\Admin\Views\LichChieu\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Lịch chiếu</h1>\r\n\r\n<p>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7d11868924edaea5f01c97f10c3a19cc3c8b6c194416", async() => {
                WriteLiteral("Create New");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</p>\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
#nullable restore
#line 16 "D:\Desktop\doan_asp\Liemv2\RapChieuPhim\RapChieuPhim\Areas\Admin\Views\LichChieu\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Ngay));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 19 "D:\Desktop\doan_asp\Liemv2\RapChieuPhim\RapChieuPhim\Areas\Admin\Views\LichChieu\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.idRapPhim));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 22 "D:\Desktop\doan_asp\Liemv2\RapChieuPhim\RapChieuPhim\Areas\Admin\Views\LichChieu\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.idRapPhim.Ten_rap));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 25 "D:\Desktop\doan_asp\Liemv2\RapChieuPhim\RapChieuPhim\Areas\Admin\Views\LichChieu\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Da_xoa));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 31 "D:\Desktop\doan_asp\Liemv2\RapChieuPhim\RapChieuPhim\Areas\Admin\Views\LichChieu\Index.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>\r\n                    ");
#nullable restore
#line 35 "D:\Desktop\doan_asp\Liemv2\RapChieuPhim\RapChieuPhim\Areas\Admin\Views\LichChieu\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.Ngay));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 38 "D:\Desktop\doan_asp\Liemv2\RapChieuPhim\RapChieuPhim\Areas\Admin\Views\LichChieu\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.idRapPhim.ID));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 41 "D:\Desktop\doan_asp\Liemv2\RapChieuPhim\RapChieuPhim\Areas\Admin\Views\LichChieu\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.idRapPhim.Ten_rap));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 44 "D:\Desktop\doan_asp\Liemv2\RapChieuPhim\RapChieuPhim\Areas\Admin\Views\LichChieu\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.Da_xoa));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7d11868924edaea5f01c97f10c3a19cc3c8b6c198760", async() => {
                WriteLiteral("Edit");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 47 "D:\Desktop\doan_asp\Liemv2\RapChieuPhim\RapChieuPhim\Areas\Admin\Views\LichChieu\Index.cshtml"
                                           WriteLiteral(item.ID);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(" |\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7d11868924edaea5f01c97f10c3a19cc3c8b6c1910947", async() => {
                WriteLiteral("Details");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 48 "D:\Desktop\doan_asp\Liemv2\RapChieuPhim\RapChieuPhim\Areas\Admin\Views\LichChieu\Index.cshtml"
                                              WriteLiteral(item.ID);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(" |\r\n                    <a type=\"button\" class=\"Delete\" style=\"color:#007bff;\"");
            BeginWriteAttribute("name", " name=\"", 1483, "\"", 1498, 1);
#nullable restore
#line 49 "D:\Desktop\doan_asp\Liemv2\RapChieuPhim\RapChieuPhim\Areas\Admin\Views\LichChieu\Index.cshtml"
WriteAttributeValue("", 1490, item.ID, 1490, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Delete</a> |\r\n                    <a type=\"button\" class=\"Restore\" style=\"color:#007bff;\"");
            BeginWriteAttribute("name", " name=\"", 1589, "\"", 1604, 1);
#nullable restore
#line 50 "D:\Desktop\doan_asp\Liemv2\RapChieuPhim\RapChieuPhim\Areas\Admin\Views\LichChieu\Index.cshtml"
WriteAttributeValue("", 1596, item.ID, 1596, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Restore</a> <br />\r\n\r\n                </td>\r\n            </tr>\r\n");
#nullable restore
#line 54 "D:\Desktop\doan_asp\Liemv2\RapChieuPhim\RapChieuPhim\Areas\Admin\Views\LichChieu\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <script>
        $("".Delete"").click((e) => {

            console.log(""aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa"");
            //console.log($(e.currentTarget));
            const id = parseInt($(e.currentTarget)[0].name);
            $.ajax({
                type: 'POST',
                //chay đc rồi nha
                url: `./Delete/${id}`,
                dataType: 'json',
                data: null,
                success: function (data) {
                    if (!data)
                        return;
                    $(e.currentTarget)[0]
                        .parentElement
                        .parentElement
                        .cells[3]
                        .children[0]
                        .checked = true;
                }
            });
        });
        $("".Restore"").click((e) => {
            console.log(""bbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb"");
            //console.log($(e.currentTarget));
            const id = parseInt($(e.currentTarget)[0");
                WriteLiteral(@"].name);
            $.ajax({
                type: 'POST',
                //chay đc rồi nha
                url: `./Restore/${id}`,
                dataType: 'json',
                data: null,
                success: function (data) {
                    if (!data)
                        return;
                    $(e.currentTarget)[0]
                        .parentElement
                        .parentElement
                        .cells[3]
                        .children[0]
                        .checked = false;
                }
            });
        });
    </script>
");
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<RapChieuPhim.Areas.Admin.Models.LichChieuModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
