using BlazorWasmAppCookieAuth.Shared;
using Microsoft.EntityFrameworkCore;

namespace BlazorWasmAppCookieAuth.Server.Data
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext _dbContext;
        
        public EmployeeRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Employee> AddEmployee(Employee employee)
        {
            var result = await _dbContext.Employees.AddAsync(employee);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Employee> DeleteEmployee(int employeeId)
        {
            var result = await _dbContext.Employees
                .FirstOrDefaultAsync(e => e.EmployeeId == employeeId);

            if(result is not null)
            {
                _dbContext.Employees.Remove(result);
                await _dbContext.SaveChangesAsync();
                return result;
            }

            return null;
        }

        public async Task<Employee> GetEmployee(int employeeId)
        {
            return await _dbContext.Employees
                .Include(d => d.Department)
                .FirstOrDefaultAsync(e => e.EmployeeId == employeeId);
        }

        public async Task<Employee> GetEmployeeByEmail(string email)
        {
            return await _dbContext.Employees
                .FirstOrDefaultAsync(e => e.Email == email);
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await _dbContext.Employees.ToListAsync();
        }

        public async Task<IEnumerable<Employee>> Search(string name, Gender? gender)
        {
            IQueryable<Employee> query = _dbContext.Employees;

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(e => e.FirstName.Contains(name)
                                    || e.LastName.Contains(name));
            }

            if(gender is not null)
            {
                query = query.Where(e => e.Gender == gender);
            }

            return await query.ToListAsync();
        }

        public async Task<Employee> UpdateEmployee(Employee employee)
        {
            var result = await _dbContext.Employees
               .FirstOrDefaultAsync(e => e.EmployeeId == employee.EmployeeId);

            if(result is not null)
            {
                result.FirstName = employee.FirstName;
                result.LastName = employee.LastName;
                result.Email = employee.Email;
                result.DateOfBirth = employee.DateOfBirth;
                result.Gender = employee.Gender;
                result.DepartmentId = employee.DepartmentId;
                result.PhotoPath = employee.PhotoPath;

                await _dbContext.SaveChangesAsync();

                return result;
            }
            return null;
        }
    }
}
