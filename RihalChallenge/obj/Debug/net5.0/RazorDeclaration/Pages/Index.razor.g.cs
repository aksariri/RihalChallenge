// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace RihalChallenge.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Users\abdullahsariri\source\repos\RihalChallenge\RihalChallenge\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\abdullahsariri\source\repos\RihalChallenge\RihalChallenge\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\abdullahsariri\source\repos\RihalChallenge\RihalChallenge\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\abdullahsariri\source\repos\RihalChallenge\RihalChallenge\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\abdullahsariri\source\repos\RihalChallenge\RihalChallenge\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\abdullahsariri\source\repos\RihalChallenge\RihalChallenge\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\abdullahsariri\source\repos\RihalChallenge\RihalChallenge\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\abdullahsariri\source\repos\RihalChallenge\RihalChallenge\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\abdullahsariri\source\repos\RihalChallenge\RihalChallenge\_Imports.razor"
using RihalChallenge;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\abdullahsariri\source\repos\RihalChallenge\RihalChallenge\_Imports.razor"
using RihalChallenge.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "C:\Users\abdullahsariri\source\repos\RihalChallenge\RihalChallenge\_Imports.razor"
using MudBlazor;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\abdullahsariri\source\repos\RihalChallenge\RihalChallenge\Pages\Index.razor"
using RihalChallenge.VModel;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/")]
    public partial class Index : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 71 "C:\Users\abdullahsariri\source\repos\RihalChallenge\RihalChallenge\Pages\Index.razor"
      

    private string searchString = "";
    private string searchString1 = "";

    public Dashboard dashboard = new();
    public classesDashboard classesDashboard = new();
    public List<classesDashboard> _classesDashboard = new();
    public CountryDashboard countryDashboard = new();
    public List<CountryDashboard> _countryDashboard = new();
    protected override async Task OnInitializedAsync()
    {
        await getDashboardData();
    }


    public async Task<Dashboard> getDashboardData()
    {
        dashboard = await _dashboardServices.getDashboardData();
        _classesDashboard = dashboard.classesDashboards;
        _countryDashboard = dashboard.countryDashboards;
        return dashboard;
    }
   

    private bool Search(classesDashboard classes) => _Search(classes, searchString);

    private bool _Search(classesDashboard classes, string searchString1)
    {
        if (string.IsNullOrWhiteSpace(searchString))
            return true;
        if (classes.className.Contains(searchString, StringComparison.OrdinalIgnoreCase))
            return true;

        return false;
    }

    private bool Search(CountryDashboard country) => _Search(country, searchString);

    private bool _Search(CountryDashboard country, string searchString1)
    {
        if (string.IsNullOrWhiteSpace(searchString))
            return true;
        if (country.CountryName.Contains(searchString, StringComparison.OrdinalIgnoreCase))
            return true;

        return false;
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private RihalChallenge.Services.DashboardServices.IDashboardServices _dashboardServices { get; set; }
    }
}
#pragma warning restore 1591
