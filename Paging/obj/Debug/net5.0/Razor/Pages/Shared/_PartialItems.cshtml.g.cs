#pragma checksum "C:\C#\ProjectPage\paging\Pages\Shared\_PartialItems.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c37c120362c61b2913e39ce0b67bed3c276689b8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(Paging.Pages.Shared.Pages_Shared__PartialItems), @"mvc.1.0.view", @"/Pages/Shared/_PartialItems.cshtml")]
namespace Paging.Pages.Shared
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
#line 1 "C:\C#\ProjectPage\paging\Pages\Shared\_PartialItems.cshtml"
using Paging.Services;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c37c120362c61b2913e39ce0b67bed3c276689b8", @"/Pages/Shared/_PartialItems.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a449d83d1eec7c666a6e9717dbe46d18ed49f9b2", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Shared__PartialItems : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral("\r\n");
#nullable restore
#line 5 "C:\C#\ProjectPage\paging\Pages\Shared\_PartialItems.cshtml"
  

    Func<string, int, string> navLeft = (string datatarget, int i) => datatarget + "navLeft" + i;

    var items = await itemServices.GetAll();



#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 14 "C:\C#\ProjectPage\paging\Pages\Shared\_PartialItems.cshtml"
 for (var i = 0; i < items.Count; i++)
{
    


#line default
#line hidden
#nullable disable
            WriteLiteral("    <li class=\"nav-item border-bottom border-dark\">\r\n        <a class=\"nav-link\" data-toggle=\"collapse\" data-target=\"");
#nullable restore
#line 19 "C:\C#\ProjectPage\paging\Pages\Shared\_PartialItems.cshtml"
                                                           Write(navLeft("#", @i));

#line default
#line hidden
#nullable disable
            WriteLiteral("\"");
            BeginWriteAttribute("aria-controls", "\r\n           aria-controls=\"", 412, "\"", 457, 1);
#nullable restore
#line 20 "C:\C#\ProjectPage\paging\Pages\Shared\_PartialItems.cshtml"
WriteAttributeValue("", 440, navLeft(null,@i), 440, 17, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" aria-expanded=\"false\" style=\"cursor: pointer\">          \r\n           <i class=\"fas fa-caret-down\"></i> ");
#nullable restore
#line 21 "C:\C#\ProjectPage\paging\Pages\Shared\_PartialItems.cshtml"
                                        Write(items[i].Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n         </a>\r\n        <div class=\"collapse\"");
            BeginWriteAttribute("id", " id=\"", 622, "\"", 644, 1);
#nullable restore
#line 23 "C:\C#\ProjectPage\paging\Pages\Shared\_PartialItems.cshtml"
WriteAttributeValue("", 627, navLeft(null,@i), 627, 17, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n            ");
#nullable restore
#line 24 "C:\C#\ProjectPage\paging\Pages\Shared\_PartialItems.cshtml"
       Write(await Html.PartialAsync("_PartialFindProductItem", items[i].Id ));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n    </li>\r\n");
#nullable restore
#line 27 "C:\C#\ProjectPage\paging\Pages\Shared\_PartialItems.cshtml"


}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public ItemServices itemServices { get; private set; }
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
