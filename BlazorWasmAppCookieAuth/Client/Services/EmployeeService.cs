using BlazorWasmAppCookieAuth.Shared;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace BlazorWasmAppCookieAuth.Client.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly HttpClient httpClient;

        public EmployeeService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<Employee> AddEmployee(Employee employee)
        {
            return await httpClient.PostJsonAsync<Employee>("employees", employee);
        }

        public async Task DeleteEmployee(int id)
        {
            await httpClient.DeleteAsync($"employees/{id}");
        }

        public async Task<Employee> GetEmployee(int id)
        {
            return await httpClient.GetFromJsonAsync<Employee>($"employees/{id}");
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await httpClient.GetFromJsonAsync<Employee[]>("employees");
        }

        public async Task<Employee> UpdateEmployee(Employee updatedEmployee)
        {
            return await httpClient.PutJsonAsync<Employee>("employees", updatedEmployee);
        }
    }

    public static class HttpUtils
    {
        public static async Task<T?> PutJsonAsync<T>(this HttpClient httpClient,string uri,object body)
        {
            var ss = await httpClient.PutAsJsonAsync(uri, body);
            ss.EnsureSuccessStatusCode();
            var result = await ss.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<T>(result);
        }

        public static async Task<T?> PostJsonAsync<T>(this HttpClient httpClient, string uri, object body)
        {
            var post = await httpClient.PostAsJsonAsync(uri, body);
            post.EnsureSuccessStatusCode();
            var result = await post.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<T>(result);
        }
    }
}
