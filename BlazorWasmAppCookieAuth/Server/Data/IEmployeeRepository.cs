using BlazorWasmAppCookieAuth.Shared;

namespace BlazorWasmAppCookieAuth.Server.Data
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> Search(string name, Gender? gender);

        Task<IEnumerable<Employee>> GetEmployees();

        Task<Employee> GetEmployee(int employeeId);

        Task<Employee> GetEmployeeByEmail(string email);

        Task<Employee> AddEmployee(Employee employee);

        Task<Employee> UpdateEmployee(Employee employee);

        Task<Employee> DeleteEmployee(int employeeId);
    }
}
