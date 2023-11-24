using BlazorWasmAppCookieAuth.Shared;

namespace BlazorWasmAppCookieAuth.Client.Services
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> GetEmployees();

        Task<Employee> GetEmployee(int id);

        Task<Employee> UpdateEmployee(Employee updatedEmployee);

        Task<Employee> AddEmployee(Employee employee);

        Task DeleteEmployee(int id);
    }
}
