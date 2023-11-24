using BlazorWasmAppCookieAuth.Shared;

namespace BlazorWasmAppCookieAuth.Client.Services
{
    public interface IDepartmentService
    {
        Task<IEnumerable<Department>> GetDepartments();
        Task<Department> GetDepartment(int id);
    }
}
