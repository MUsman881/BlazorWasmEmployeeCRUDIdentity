using BlazorWasmAppCookieAuth.Client.Services;
using BlazorWasmAppCookieAuth.Shared;
using Microsoft.AspNetCore.Components;

namespace BlazorWasmAppCookieAuth.Client.Pages
{
    public class EmployeeDetailsBase : ComponentBase
    {
        public Employee Employee { get; set; } = new Employee();

        //dynamically set buttontext and css class
        protected string ButtonText { get; set; } = "Hide Footer";
        protected string CssClass { get; set; } = null;

        [Inject]
        public IEmployeeService EmployeeService { get; set; }

        [Parameter]
        public string Id { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Employee = await EmployeeService.GetEmployee(int.Parse(Id));
        }

        //show/hide footer
        protected void ButtonClick()
        {
            if(ButtonText == "Hide Footer")
            {
                ButtonText = "Show Footer";
                CssClass = "Hidefooter";
            }
            else
            {
                CssClass = null;
                ButtonText = "Hide Footer";
            }
        }
    }
}
