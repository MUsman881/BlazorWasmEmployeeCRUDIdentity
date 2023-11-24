using BlazorWasmAppCookieAuth.Shared;
using Microsoft.EntityFrameworkCore;

namespace BlazorWasmAppCookieAuth.Server.Data
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly AppDbContext _dbContext;

        public DepartmentRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Department> GetDepartment(int departmentId)
        {
            return await _dbContext.Departments
                .FirstOrDefaultAsync(d => d.DepartmentId == departmentId);
        }

        public async Task<IEnumerable<Department>> GetDepartments()
        {
            return await _dbContext.Departments.ToListAsync();
        }
    }
}
