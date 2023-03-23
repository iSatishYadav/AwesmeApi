using AwesmeApi.Contexts;
using AwesmeApi.Models;
using Microsoft.EntityFrameworkCore;

namespace AwesmeApi.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly HRContext _context;

        public EmployeeService(HRContext context)
        {
            _context = context;
        }

        public async Task<int> AddEmployee(Employee employee)
        {
            _context.Add(employee);
            await _context.SaveChangesAsync();
            return employee.Id;
        }

        public async Task<Employee?> UpdateEmployee(Employee employee)
        {
            _context.Entry(employee).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return employee;
        }

        public async Task<List<Employee>> GetEmployees()
        {
            return await _context.Employees.ToListAsync();
        }
        public async Task<Employee?> GetEmployee(int id)
        {
            return await _context.Employees.FindAsync(id);
        }

        public async Task DeleteEmployee(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
                await _context.SaveChangesAsync();
            }
        }
    }
}
