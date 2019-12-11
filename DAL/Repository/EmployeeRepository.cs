namespace DAL.Repository
{
    using System.Collections.Generic;
    using System.Linq;

    using DAL.Context;
    using DAL.Models;
   
    public class EmployeeRepository
    {
       public void AddEmployee(Employee employee)
       {
            using (var context = new HangfireEmployeeDBContext() )
            {
                context.Add(employee);
                context.SaveChanges();
            }
               
       }

        public List<Employee> GetEmployees()
        {
            using (var context = new HangfireEmployeeDBContext())
            {
                var employees = context.Employee.ToList();
                return employees;
            }
        }
    }
}
