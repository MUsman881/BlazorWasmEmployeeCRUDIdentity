using BlazorWasmAppCookieAuth.Shared;
using Microsoft.EntityFrameworkCore;

namespace BlazorWasmAppCookieAuth.Server.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {

        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set;}

    }
}
