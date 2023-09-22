using System.Runtime.InteropServices;

namespace FirstWebAPI.Models
{
    public class RepositoryEmployee
    {
        private NorthwindContext _context;
        public RepositoryEmployee(NorthwindContext context)
        {
            _context = context;

        }

        public List<Employee> AllEmployees()

        {

            return _context.Employees.ToList();

        }

        public Employee FindEmployeeById(int id)

        {

            Employee employeeId = _context.Employees.Find(id);

            return employeeId;

        }

        public int AddEmployee(Employee newEmployee)

        {

            _context.Employees.Add(newEmployee);

            return _context.SaveChanges();

        }
        public Employee UpdateEmployee(Employee updatedemployee) 
        {
            _context.Employees.Update(updatedemployee);
            _context.SaveChanges();
            return updatedemployee;
        }

        public int ModifyEmployee(int id)

        {

            Employee emp = _context.Employees.Find(id);
            
            _context.Employees.Update(emp);

            return _context.SaveChanges();

        }

        public int DeleteEmployee(int id)

        {

            Employee emp = _context.Employees.Find(id);

            _context.Employees.Remove(emp);

            return _context.SaveChanges();

        }
    }
}
