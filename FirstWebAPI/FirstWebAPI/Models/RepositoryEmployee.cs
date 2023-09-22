using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Extensions;
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

        public int AddEmployee(Employee emp)

        {
            //EntityState es = _context.Entry(newEmployee).State;
            //Console.WriteLine($"EntityState B4ADD :{es.GetDisplayName()}");
            //_context.Employees.Add(newEmployee);
            //es = _context.Entry(newEmployee).State;
            //Console.WriteLine($"EntityState AfterAdd :{es.GetDisplayName()}");
            //int result =  _context.SaveChanges();
            //es = _context.Entry(newEmployee).State;
            //Console.WriteLine($"EntityState SaveChanges :{es.GetDisplayName()}");
            //return result;
            Employee? foundEmp = _context.Employees.Find(emp.EmployeeId);



            if (foundEmp != null)



            {



                throw new Exception("failed to add");



            }



            EntityState es = _context.Entry(emp).State;



            Console.WriteLine($"EntityState B4 Add:{es.GetDisplayName()}");



            _context.Employees.Add(emp);



            es = _context.Entry(emp).State;



            Console.WriteLine($"EntityState After Add:{es.GetDisplayName()}");



            int result = _context.SaveChanges();



            es = _context.Entry(emp).State;



            Console.WriteLine($"EntityState After SaveChanges:{es.GetDisplayName()}");
            return result;
        }
        public int UpdateEmployee(Employee updatedemployee) 
        {
            EntityState es = _context.Entry(updatedemployee).State;
            Console.WriteLine($"EntityState B4Update :{es.GetDisplayName()}");
            _context.Employees.Update(updatedemployee);
            es = _context.Entry(updatedemployee).State;
            Console.WriteLine($"EntityState AfterUpdate :{es.GetDisplayName()}");
            int result =_context.SaveChanges();
            es = _context.Entry(updatedemployee).State;
            Console.WriteLine($"EntityState AfterSaveChanges :{es.GetDisplayName()}");
            return result;
        }

        public int ModifyEmployee(int id)

        {

            Employee emp = _context.Employees.Find(id);
            EntityState es = _context.Entry(emp).State;
            Console.WriteLine($"EntityState B4Update :{es.GetDisplayName()}");
            _context.Employees.Update(emp);
            es = _context.Entry(emp).State;
            Console.WriteLine($"EntityState AfterUpdate :{es.GetDisplayName()}");
            int result = _context.SaveChanges();
            es = _context.Entry(emp).State;
            Console.WriteLine($"EntityState AfterSaveChanges :{es.GetDisplayName()}");
            return result;

        }

        public int DeleteEmployee(int id)

        {

            Employee emp = _context.Employees.Find(id);
            EntityState es = _context.Entry(emp).State;
            Console.WriteLine($"EntityState B4Delete :{es.GetDisplayName()}");
            _context.Employees.Remove(emp);
            es = _context.Entry(emp).State;
            Console.WriteLine($"EntityState AfterDelete :{es.GetDisplayName()}");
            int result =  _context.SaveChanges();
            es = _context.Entry(emp).State;
            Console.WriteLine($"EntityState AfterSaveChanges :{es.GetDisplayName()}");
            return result;
        }
    }
}
