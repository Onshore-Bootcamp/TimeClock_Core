#pragma checksum "C:\Users\Andrew\source\repos\TimeClock_Core\TimeClock_Core\Views\Account\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c94b1bab9b58d55b11832c41eade351f13eb76ba"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Account_Index), @"mvc.1.0.view", @"/Views/Account/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Account/Index.cshtml", typeof(AspNetCore.Views_Account_Index))]
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
#line 1 "C:\Users\Andrew\source\repos\TimeClock_Core\TimeClock_Core\Views\_ViewImports.cshtml"
using TimeClock_Core;

#line default
#line hidden
#line 2 "C:\Users\Andrew\source\repos\TimeClock_Core\TimeClock_Core\Views\_ViewImports.cshtml"
using TimeClock_Core.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c94b1bab9b58d55b11832c41eade351f13eb76ba", @"/Views/Account/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"de330e40f8c1fdb39e9db32c5b25f52317c59659", @"/Views/_ViewImports.cshtml")]
    public class Views_Account_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<User>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Users\Andrew\source\repos\TimeClock_Core\TimeClock_Core\Views\Account\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Views/Shared/_TimeManagerLayout.cshtml";

#line default
#line hidden
            BeginContext(118, 474, true);
            WriteLiteral(@"
<h2 class=""text-center"">Users</h2>

<table class=""table table-striped table-condensed"">
    <thead>
        <tr>
            <th>
                Username
            </th>
            <th>
                First Name
            </th>
            <th>
                Last Name
            </th>
            <th>
                Role
            </th>
            <th>
                Active
            </th>
        </tr>
    </thead>
    <tbody>
");
            EndContext();
#line 30 "C:\Users\Andrew\source\repos\TimeClock_Core\TimeClock_Core\Views\Account\Index.cshtml"
         foreach (User user in Model)
        {

#line default
#line hidden
            BeginContext(642, 60, true);
            WriteLiteral("            <tr>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(703, 13, false);
#line 34 "C:\Users\Andrew\source\repos\TimeClock_Core\TimeClock_Core\Views\Account\Index.cshtml"
               Write(user.Username);

#line default
#line hidden
            EndContext();
            BeginContext(716, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(784, 14, false);
#line 37 "C:\Users\Andrew\source\repos\TimeClock_Core\TimeClock_Core\Views\Account\Index.cshtml"
               Write(user.FirstName);

#line default
#line hidden
            EndContext();
            BeginContext(798, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(866, 13, false);
#line 40 "C:\Users\Andrew\source\repos\TimeClock_Core\TimeClock_Core\Views\Account\Index.cshtml"
               Write(user.LastName);

#line default
#line hidden
            EndContext();
            BeginContext(879, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(947, 9, false);
#line 43 "C:\Users\Andrew\source\repos\TimeClock_Core\TimeClock_Core\Views\Account\Index.cshtml"
               Write(user.Role);

#line default
#line hidden
            EndContext();
            BeginContext(956, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(1024, 11, false);
#line 46 "C:\Users\Andrew\source\repos\TimeClock_Core\TimeClock_Core\Views\Account\Index.cshtml"
               Write(user.Active);

#line default
#line hidden
            EndContext();
            BeginContext(1035, 44, true);
            WriteLiteral("\r\n                </td>\r\n            </tr>\r\n");
            EndContext();
#line 49 "C:\Users\Andrew\source\repos\TimeClock_Core\TimeClock_Core\Views\Account\Index.cshtml"
        }

#line default
#line hidden
            BeginContext(1090, 22, true);
            WriteLiteral("    </tbody>\r\n</table>");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<User>> Html { get; private set; }
    }
}
#pragma warning restore 1591
