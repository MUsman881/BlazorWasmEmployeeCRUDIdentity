using BlazorWasmAppCookieAuth.Client.Components;
using BlazorWasmAppCookieAuth.Client.Services;
using BlazorWasmAppCookieAuth.Shared;
using Microsoft.AspNetCore.Components;

namespace BlazorWasmAppCookieAuth.Client.Pages
{
    public class DisplayEmployeeBase : ComponentBase
    {
        [Inject]
        public IEmployeeService EmployeeService { get; set; }

        [Parameter]
        public Employee Employee { get; set; }

        [Parameter]
        public bool ShowFooter { get; set; }

        [Parameter]
        public EventCallback<bool> OnEmployeeSelection { get; set; }

        [Parameter]
        public EventCallback<int> OnEmployeeDeleted { get; set; }

        protected ConfirmBase DeleteConfirmation {get;set ;}

        protected async Task CheckBoxChanged(ChangeEventArgs e)
        {
            await OnEmployeeSelection.InvokeAsync((bool)e.Value);
        }

        protected void DeleteEmployee()
        {
            DeleteConfirmation.Show();
        }

        protected async Task ConfirmDelete_Click(bool deleteConfirmed)
        {
            if (deleteConfirmed)
            {
                await EmployeeService.DeleteEmployee(Employee.EmployeeId);
                await OnEmployeeDeleted.InvokeAsync(Employee.EmployeeId);
            }
        }
    }
}
