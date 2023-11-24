using BlazorWasmAppCookieAuth.Client.Services;
using BlazorWasmAppCookieAuth.Shared;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

namespace BlazorWasmAppCookieAuth.Client.Pages
{
    public class EmployeeListBase : ComponentBase
    {
        [CascadingParameter]
        public Task<AuthenticationState> AuthenticationState { get; set; }

        [Inject]
        public IEmployeeService EmployeeService { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public bool ShowFooter { get; set; } = true;

        protected int EmployeeSelectedCount { get; set; } = 0;

        public IEnumerable<Employee> Employees { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Employees = (await EmployeeService.GetEmployees()).ToList();
        }

        protected async Task EmployeeDeleted()
        {
            Employees = (await EmployeeService.GetEmployees()).ToList();
        }

        protected void EmployeeSelected(bool isSelected)
        {
            if (isSelected)
            {
                EmployeeSelectedCount++;
            }
            else
            {
                EmployeeSelectedCount--;
            }
        }

    }
}
