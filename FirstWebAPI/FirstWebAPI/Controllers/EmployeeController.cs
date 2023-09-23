using FirstWebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Extensions;
using System.Linq;
using System.Runtime.InteropServices;

namespace FirstWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private RepositoryEmployee _repositoryEmployee;
        public EmployeeController(RepositoryEmployee repository)
        {
            _repositoryEmployee = repository;
        }
        [HttpGet("/FindEmployee")]
        public Employee FindEmployee(int id)
        {
            Employee employeeById = _repositoryEmployee.FindEmployeeById(id);
            return employeeById;
        }

        [HttpPost("/AddEmployee")]
        public int AddEmployee(EmpViewModel newemp)
        {
            Employee employee = new Employee()
            {
                // EmpId = emp.EmployeeId, IT WONT work
                FirstName = newemp.FirstName,
                LastName = newemp.LastName,
                BirthDate = newemp.BirthDate,
                HireDate = newemp.HireDate,
                Title = newemp.Title,
                City = newemp.City,
                ReportsTo = newemp.ReportsTo > 0 ? newemp.ReportsTo : 0,
            };
            _repositoryEmployee.AddEmployee(employee);
            return 1;
        }


        [HttpPut("/ModifyEmployee")]
        public int ModifyEmployee(int id, [FromBody] EmpViewModel updatedEmployee)
        {
            Employee employee = new Employee();
            employee.EmployeeId = updatedEmployee.EmpId;
            employee.FirstName = updatedEmployee.FirstName;
            employee.LastName  = updatedEmployee.LastName;
            employee.Title = updatedEmployee.Title;
            employee.City = updatedEmployee.City;
            employee.ReportsTo = updatedEmployee.ReportsTo;
            employee.HireDate = updatedEmployee.HireDate;
            employee.BirthDate = updatedEmployee.BirthDate;
            _repositoryEmployee.UpdateEmployee(employee);
            return 1;
        }

        [HttpDelete("/DeleteEmployee")]

        public string DeleteEmployee(int id)
        {
            int employeestatus = _repositoryEmployee.DeleteEmployee(id);
            if (employeestatus == 0)
            {
                return "Employee does not exist in the Database";
            }
            else
            {
                return "Employee Successfully Deleted";
            }
        }

        [HttpGet("/GetAllEmployee")]
        public IEnumerable<EmpViewModel> GetAllEmployees() 
        {
            List<Employee> employees = _repositoryEmployee.AllEmployees();
            var emplist = (from emp in employees
                           select new EmpViewModel()
                           {
                               EmpId = emp.EmployeeId,
                               FirstName = emp.FirstName,
                               LastName = emp.LastName,
                               BirthDate = (DateTime)emp.BirthDate,
                               HireDate = (DateTime)emp.HireDate,
                               Title = emp.Title,
                               City = emp.City,
                               ReportsTo = emp.ReportsTo
                           }
            ).ToList();
            return emplist;
        }

    }
}
