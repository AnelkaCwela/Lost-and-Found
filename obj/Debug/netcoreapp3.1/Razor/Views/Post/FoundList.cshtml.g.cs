#pragma checksum "C:\Users\Anele\Desktop\Vistaul Studio Work\Web\Published\LostNelsonFound\Views\Post\FoundList.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3f5594f6ca38069cbc6918eb6064c016a2e959ad"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Post_FoundList), @"mvc.1.0.view", @"/Views/Post/FoundList.cshtml")]
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
#line 1 "C:\Users\Anele\Desktop\Vistaul Studio Work\Web\Published\LostNelsonFound\Views\_ViewImports.cshtml"
using LostNelsonFound;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Anele\Desktop\Vistaul Studio Work\Web\Published\LostNelsonFound\Views\_ViewImports.cshtml"
using LostNelsonFound.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Anele\Desktop\Vistaul Studio Work\Web\Published\LostNelsonFound\Views\_ViewImports.cshtml"
using LostNelsonFound.Models.Binding;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\Anele\Desktop\Vistaul Studio Work\Web\Published\LostNelsonFound\Views\_ViewImports.cshtml"
using LostNelsonFound.Models.DataModel;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\Anele\Desktop\Vistaul Studio Work\Web\Published\LostNelsonFound\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3f5594f6ca38069cbc6918eb6064c016a2e959ad", @"/Views/Post/FoundList.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"78a224a6ff3698519c28796a5276d238d293ceb3", @"/Views/_ViewImports.cshtml")]
    public class Views_Post_FoundList : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<FoundListViewModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("img-rounded img-responsive"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("role", new global::Microsoft.AspNetCore.Html.HtmlString("img"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("width", new global::Microsoft.AspNetCore.Html.HtmlString("200"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("height", new global::Microsoft.AspNetCore.Html.HtmlString("200"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Details", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-sm btn-info"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.ImageTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Anele\Desktop\Vistaul Studio Work\Web\Published\LostNelsonFound\Views\Post\FoundList.cshtml"
  
    ViewData["Title"] = "Found Items";
    Layout = "__HomeLayout";

#line default
#line hidden
#nullable disable
            WriteLiteral("<br />\r\n<h3 class=\"text-primary\">Found Items</h3>\r\n<hr />\r\n\r\n<br />\r\n");
#nullable restore
#line 12 "C:\Users\Anele\Desktop\Vistaul Studio Work\Web\Published\LostNelsonFound\Views\Post\FoundList.cshtml"
 if (Model.Any())
{

    

#line default
#line hidden
#nullable disable
#nullable restore
#line 15 "C:\Users\Anele\Desktop\Vistaul Studio Work\Web\Published\LostNelsonFound\Views\Post\FoundList.cshtml"
     foreach (var item in Model)
    {


#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"card mb-3\">\r\n    <div class=\"card-text text-center\">\r\n        Posted :");
#nullable restore
#line 20 "C:\Users\Anele\Desktop\Vistaul Studio Work\Web\Published\LostNelsonFound\Views\Post\FoundList.cshtml"
           Write(item.FoundModel.DatePosted);

#line default
#line hidden
#nullable disable
            WriteLiteral(" &nbsp;&nbsp;\r\n        <div>\r\n            ");
#nullable restore
#line 22 "C:\Users\Anele\Desktop\Vistaul Studio Work\Web\Published\LostNelsonFound\Views\Post\FoundList.cshtml"
       Write(ViewBag.Claim);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n    <div class=\"card-img\">\r\n        <span class=\"img-responsive\">\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "3f5594f6ca38069cbc6918eb6064c016a2e959ad7913", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ImageTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            BeginWriteTagHelperAttribute();
            WriteLiteral("data:image/jpg;base64,");
#nullable restore
#line 27 "C:\Users\Anele\Desktop\Vistaul Studio Work\Web\Published\LostNelsonFound\Views\Post\FoundList.cshtml"
                                                                              WriteLiteral(System.Convert.ToBase64String(item.FoundModel.PhotoFound));

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper.Src = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("src", __Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper.Src, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
#nullable restore
#line 27 "C:\Users\Anele\Desktop\Vistaul Studio Work\Web\Published\LostNelsonFound\Views\Post\FoundList.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper.AppendVersion = true;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-append-version", __Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper.AppendVersion, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n        </span>\r\n    </div>\r\n    <div class=\"card-body\">\r\n        <h5> Catergory : ");
#nullable restore
#line 31 "C:\Users\Anele\Desktop\Vistaul Studio Work\Web\Published\LostNelsonFound\Views\Post\FoundList.cshtml"
                    Write(item.CategoryModel.CategoryName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n\r\n        <h5> Date Found : ");
#nullable restore
#line 33 "C:\Users\Anele\Desktop\Vistaul Studio Work\Web\Published\LostNelsonFound\Views\Post\FoundList.cshtml"
                     Write(item.FoundModel.DateFound);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n        <h5 class=\"alert alert-info\">Description: ");
#nullable restore
#line 34 "C:\Users\Anele\Desktop\Vistaul Studio Work\Web\Published\LostNelsonFound\Views\Post\FoundList.cshtml"
                                             Write(item.FoundModel.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n    </div>\r\n    <div class=\"card-footer\">\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3f5594f6ca38069cbc6918eb6064c016a2e959ad11562", async() => {
                WriteLiteral("Details");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 37 "C:\Users\Anele\Desktop\Vistaul Studio Work\Web\Published\LostNelsonFound\Views\Post\FoundList.cshtml"
                                                                                    WriteLiteral(item.FoundModel.FoundId);

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
            WriteLiteral("\r\n      \r\n\r\n     \r\n    </div>\r\n\r\n</div>\r\n");
#nullable restore
#line 44 "C:\Users\Anele\Desktop\Vistaul Studio Work\Web\Published\LostNelsonFound\Views\Post\FoundList.cshtml"
    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 44 "C:\Users\Anele\Desktop\Vistaul Studio Work\Web\Published\LostNelsonFound\Views\Post\FoundList.cshtml"
     
}
else
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"card\">\r\n        <div class=\"card-header\">\r\n            No Items yet Posted\r\n        </div>\r\n\r\n    </div>\r\n");
#nullable restore
#line 54 "C:\Users\Anele\Desktop\Vistaul Studio Work\Web\Published\LostNelsonFound\Views\Post\FoundList.cshtml"
}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<FoundListViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
