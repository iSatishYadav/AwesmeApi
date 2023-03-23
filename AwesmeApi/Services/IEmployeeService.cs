using AwesmeApi.Models;

namespace AwesmeApi.Services
{
    public interface IEmployeeService
    {
        Task<int> AddEmployee(Employee employee);
        Task DeleteEmployee(int id);
        Task<Employee?> GetEmployee(int id);
        Task<List<Employee>> GetEmployees();
        Task<Employee?> UpdateEmployee(Employee employee);
    }
}
