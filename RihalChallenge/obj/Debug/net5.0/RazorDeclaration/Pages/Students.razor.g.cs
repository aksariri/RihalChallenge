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
#line 3 "C:\Users\abdullahsariri\source\repos\RihalChallenge\RihalChallenge\Pages\Students.razor"
using RihalChallenge.Data;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\abdullahsariri\source\repos\RihalChallenge\RihalChallenge\Pages\Students.razor"
using RihalChallenge.VModel;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/students")]
    public partial class Students : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 73 "C:\Users\abdullahsariri\source\repos\RihalChallenge\RihalChallenge\Pages\Students.razor"
       
    public int country_Id;
    public int class_Id;
    public string oman = "Oman";
    private string searchString = "";
    private string searchString1 = "";
    public students students = new();
    public studentsVM _studentsvm = new();
    public List<studentsVM> _students = new();
    public List<classes> _classes = new List<classes>();
    public List<countries> _countries = new List<countries>();
    protected override async Task OnInitializedAsync()
    {
        GetListofstudents();
        GetListofClasses();
        GetListofCountries();
        country_Id = _countries.Find(xx => xx.name == "Oman").id;
        class_Id = _classes.FirstOrDefault().id;
    }

    public List<countries> GetListofCountries()
    {
        _countries = _countriesServices.GetListofcountries();
        return _countries;
    }
    public List<classes> GetListofClasses()
    {
        _classes = _classesServices.GetListofClasses();
        return _classes;
    }
    public async Task<bool> addedditDatastudents()
    {
        students.country_Id = country_Id;
        students.class_Id = class_Id;
        return await _studentsServices.addedditdeleteDatastudents(students, "EDIT");
    }
    public async Task<bool> deleteDatastudents()
    {
        return await _studentsServices.addedditdeleteDatastudents(students, "DELTED");
    }
    private void Edit(int Student_Id)
    {
        students = (from s in _students where s.id == Student_Id
                    select new students
                    {
                        id = s.id,
                        name = s.name,
                        class_Id = s.classes.id,
                        country_Id = s.countries.id,
                        date_of_birth = s.date_of_birth
                    }).FirstOrDefault();
    }
    public async Task<bool> Delete(studentsVM _students, string code)
    {
        students.id = _students.id;
        return await _studentsServices.addedditdeleteDatastudents(students, code);
    }
    public async Task<bool> postRandomSeedDataFaker()
    {
        return await _studentsServices.postRandomSeedDataFaker();
    }
    public List<studentsVM> GetListofstudents()
    {
        _students = _studentsServices.GetListofstudents();
        return _students;
    }

    private bool Search(studentsVM students) => _Search(students, searchString);

    private bool _Search(studentsVM students, string searchString1)
    {
        if (string.IsNullOrWhiteSpace(searchString))
            return true;
        if (students.name.Contains(searchString, StringComparison.OrdinalIgnoreCase))
            return true;

        return false;
    }


#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private MudBlazor.ISnackbar _snackbar { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private RihalChallenge.Services.CountriesServices.ICountriesServices _countriesServices { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private RihalChallenge.Services.ClassesServices.IClassesServices _classesServices { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private RihalChallenge.Services.StudentServices.IStudentsServices _studentsServices { get; set; }
    }
}
#pragma warning restore 1591
