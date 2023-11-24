using AutoMapper;
using BlazorWasmAppCookieAuth.Client.Components;
using BlazorWasmAppCookieAuth.Client.Services;
using BlazorWasmAppCookieAuth.Client.Shared;
using BlazorWasmAppCookieAuth.Client.ViewModels;
using BlazorWasmAppCookieAuth.Shared;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

namespace BlazorWasmAppCookieAuth.Client.Pages
{
    public class EditEmployeeBase : ComponentBase
    {

        [Inject]
        public IEmployeeService EmployeeService { get; set; }
        [Inject]
        public IDepartmentService DepartmentService { get; set; }
        [Inject]
        public IMapper Mapper { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
    

        private Employee Employee { get; set; } = new Employee();
        public VMEditEmployee EditEmployee { get; set; } = new VMEditEmployee();
        public List<Department> Departments { get; set; } = new List<Department>();

        [Parameter]
        public string Id { get; set; }

        public string PageHeaderText { get; set; }
        public string ButtonText { get; set; }

        protected ConfirmBase DeleteConfirmation { get; set; }


        protected override async Task OnInitializedAsync()
        {
            int.TryParse(Id, out int emoloyeeId);

            if(emoloyeeId != 0)
            {
                PageHeaderText = "Edit Employee";
                ButtonText = "Update";
                Employee = await EmployeeService.GetEmployee(int.Parse(Id));
            }
            else
            {
                PageHeaderText = "Create Employee";
                ButtonText = "Create";
                Employee = new Employee
                {
                    DepartmentId = 1,
                    DateOfBirth = DateTime.Now,
                    PhotoPath = "images/noimage.png"
                };
            }

            Departments = (await DepartmentService.GetDepartments()).ToList();

            Mapper.Map(Employee, EditEmployee);
        }

        protected async Task HandleSubmit()
        {
            Mapper.Map(EditEmployee, Employee);

            Employee result = null;

            if(Employee.EmployeeId != 0)
            {
                result = await EmployeeService.UpdateEmployee(Employee);
            }
            else
            {
                result = await EmployeeService.AddEmployee(Employee);
            }

            if (result is not null)
            {
                NavigationManager.NavigateTo("/employee");
            }
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
                NavigationManager.NavigateTo("/employee");
            }
        }
    }
}
