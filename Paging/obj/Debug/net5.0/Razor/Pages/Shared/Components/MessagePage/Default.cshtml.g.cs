#pragma checksum "C:\C#\ProjectPage\paging\Pages\Shared\Components\MessagePage\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "99fae86e88c74bd0c411aaef9c066e90a9ff6a30"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(Paging.Pages.Shared.Components.MessagePage.Pages_Shared_Components_MessagePage_Default), @"mvc.1.0.view", @"/Pages/Shared/Components/MessagePage/Default.cshtml")]
namespace Paging.Pages.Shared.Components.MessagePage
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
#line 1 "C:\C#\ProjectPage\paging\Pages\_ViewImports.cshtml"
using Paging;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\C#\ProjectPage\paging\Pages\Shared\Components\MessagePage\Default.cshtml"
using Paging.Pages.Shared.Components.MessagePage;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"99fae86e88c74bd0c411aaef9c066e90a9ff6a30", @"/Pages/Shared/Components/MessagePage/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a449d83d1eec7c666a6e9717dbe46d18ed49f9b2", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Shared_Components_MessagePage_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<MessagePage.Message>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 4 "C:\C#\ProjectPage\paging\Pages\Shared\Components\MessagePage\Default.cshtml"
   
    Layout = "_Layout";
    ViewData["Title"] = Model.Title;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"card m-4\">\r\n    <div class=\"card-header bg-danger text-light\">\r\n        <h3>");
#nullable restore
#line 11 "C:\C#\ProjectPage\paging\Pages\Shared\Components\MessagePage\Default.cshtml"
       Write(Model.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n    </div>\r\n    <div class=\"card-body\">\r\n        ");
#nullable restore
#line 14 "C:\C#\ProjectPage\paging\Pages\Shared\Components\MessagePage\Default.cshtml"
   Write(Html.Raw(Model.Htmlcontent));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n    <div class=\"card-footer\">\r\n        Chuyển đến - <a");
            BeginWriteAttribute("href", " href=\"", 406, "\"", 429, 1);
#nullable restore
#line 17 "C:\C#\ProjectPage\paging\Pages\Shared\Components\MessagePage\Default.cshtml"
WriteAttributeValue("", 413, Model.ReturnUrl, 413, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Bam vao day</a>\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<MessagePage.Message> Html { get; private set; }
    }
}
#pragma warning restore 1591