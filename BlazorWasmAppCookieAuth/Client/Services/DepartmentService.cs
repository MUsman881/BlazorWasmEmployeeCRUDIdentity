using BlazorWasmAppCookieAuth.Shared;
using System.Net.Http.Json;

namespace BlazorWasmAppCookieAuth.Client.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly HttpClient httpClient;

        public DepartmentService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<Department> GetDepartment(int id)
        {
            return await httpClient.GetFromJsonAsync<Department>($"departments/{id}");
        }

        public async Task<IEnumerable<Department>> GetDepartments()
        {
            return await httpClient.GetFromJsonAsync<Department[]>("departments");
        }
    }
}
