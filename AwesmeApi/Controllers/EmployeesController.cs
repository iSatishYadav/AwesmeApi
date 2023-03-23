using AwesmeApi.Dtos;
using AwesmeApi.Models;
using AwesmeApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AwesmeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        readonly IEmployeeService _employeeService;

        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        // GET: api/Employees
        [HttpGet]
        public async Task<ActionResult<Result<List<Employee>>>> GetEmployees()
        {
            return Result<List<Employee>>.SuccessResult(await _employeeService.GetEmployees());
        }

        // GET: api/Employees/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Result<Employee>>> GetEmployee(int id)
        {
            return Result<Employee>.SuccessResult(await _employeeService.GetEmployee(id));
        }

        // PUT: api/Employees/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<Result<Employee?>> UpdateEmployee(int id, Employee employee)
        {
            if (id != employee.Id)
            {
                return Result<Employee?>.FailureResult(null, "Invalid Employee");
            }

            var updatedEmployee = await _employeeService.UpdateEmployee(employee);
            return Result<Employee?>.SuccessResult(updatedEmployee);            
        }

        // POST: api/Employees
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Result<Employee>>> AddEmployee(Employee employee)
        {
            var id = await _employeeService.AddEmployee(employee);
            employee.Id = id;
            return CreatedAtAction(nameof(GetEmployee), new { id = employee.Id }, Result<Employee>.SuccessResult(employee));
        }

        // DELETE: api/Employees/5
        [HttpDelete("{id}")]
        public async Task<Result<int>> DeleteEmployee(int id)
        {
            await _employeeService.DeleteEmployee(id);

            return Result<int>.SuccessResult(id);
        }
    }
}
