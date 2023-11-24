using BlazorWasmAppCookieAuth.Client.Handlers;
using BlazorWasmAppCookieAuth.Client.Providers;
using BlazorWasmAppCookieAuth.Client.Services;
using BlazorWasmAppCookieAuth.Client.ViewModels;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace BlazorWasmAppCookieAuth.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            //builder.RootComponents.Add<App>("#app");
            //builder.RootComponents.Add<HeadOutlet>("head::after");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7182/api/") });
            
            builder.Services.AddScoped<IEmployeeService, EmployeeService>();
            builder.Services.AddScoped<IDepartmentService, DepartmentService>();

            builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();
            builder.Services.AddScoped<CookieHandler>();
            builder.Services.AddAutoMapper(typeof(EmployeeProfile));

            builder.Services.AddHttpClient("BlazorWasmAppCookieAuth.ServerAPI", 
                client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
               .AddHttpMessageHandler<CookieHandler>();

            builder.Services.AddOptions();
            builder.Services.AddAuthorizationCore();


            await builder.Build().RunAsync();
        }
    }
}