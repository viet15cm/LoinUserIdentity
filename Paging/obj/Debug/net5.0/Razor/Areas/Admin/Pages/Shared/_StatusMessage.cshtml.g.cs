#pragma checksum "C:\C#\ProjectPage\paging\Areas\Admin\Pages\Shared\_StatusMessage.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "291ae568543e6be29a0106a2d6026c7a2becce09"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(Paging.Areas.Admin.Pages.Shared.Areas_Admin_Pages_Shared__StatusMessage), @"mvc.1.0.view", @"/Areas/Admin/Pages/Shared/_StatusMessage.cshtml")]
namespace Paging.Areas.Admin.Pages.Shared
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"291ae568543e6be29a0106a2d6026c7a2becce09", @"/Areas/Admin/Pages/Shared/_StatusMessage.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"31839b9ae4f76c0417bbf8efd8329486e26cf82d", @"/Areas/Admin/Pages/_ViewImports.cshtml")]
    public class Areas_Admin_Pages_Shared__StatusMessage : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<string>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\C#\ProjectPage\paging\Areas\Admin\Pages\Shared\_StatusMessage.cshtml"
 if (!String.IsNullOrEmpty(Model))
{
    var statusMessageClass = Model.StartsWith("Error") ? "danger" : "primary";
    var mesage = Model;
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\C#\ProjectPage\paging\Areas\Admin\Pages\Shared\_StatusMessage.cshtml"
     if (Model.StartsWith("Error")) {
        mesage = Model.Substring(5);
    }
   

#line default
#line hidden
#nullable disable
            WriteLiteral(" <div");
            BeginWriteAttribute("class", " class=\"", 499, "\"", 566, 6);
            WriteAttributeValue("", 507, "alert", 507, 5, true);
            WriteAttributeValue(" ", 512, "alert-", 513, 7, true);
#nullable restore
#line 14 "C:\C#\ProjectPage\paging\Areas\Admin\Pages\Shared\_StatusMessage.cshtml"
WriteAttributeValue("", 519, statusMessageClass, 519, 19, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue(" ", 538, "alert-dismissible", 539, 18, true);
            WriteAttributeValue(" ", 556, "fade", 557, 5, true);
            WriteAttributeValue(" ", 561, "show", 562, 5, true);
            EndWriteAttribute();
            WriteLiteral(" role=\"alert\">\r\n  <strong><i class=\"fas fa-check-circle\"></i></strong> ");
#nullable restore
#line 15 "C:\C#\ProjectPage\paging\Areas\Admin\Pages\Shared\_StatusMessage.cshtml"
                                                  Write(mesage);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n  <button type=\"button\" class=\"btn-close\" data-bs-dismiss=\"alert\" aria-label=\"Close\"></button>\r\n</div>\r\n");
#nullable restore
#line 18 "C:\C#\ProjectPage\paging\Areas\Admin\Pages\Shared\_StatusMessage.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<string> Html { get; private set; }
    }
}
#pragma warning restore 1591
