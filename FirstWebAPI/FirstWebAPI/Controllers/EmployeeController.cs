using FirstWebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public string AddEmployee(Employee newEmployee)
        {
            int employeestatus = _repositoryEmployee.AddEmployee(newEmployee);
            if (employeestatus == 0)
            {
                return "Employee Not Added To Database Since it already exist";
            }
            else
            {
                return "Employee Added To Database";
            }
        }

        [HttpPut("/ModifyEmployee")]
        public Employee ModifyEmployee(int id, [FromBody] Employee updatedEmployee)
        {
            updatedEmployee.EmployeeId = id;
            Employee savedEmployee = _repositoryEmployee.UpdateEmployee(updatedEmployee);
            return savedEmployee;
        }

        [HttpPut("/DeleteEmployee")]

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
