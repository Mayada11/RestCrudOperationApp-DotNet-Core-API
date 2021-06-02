using RestCrudOperationApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestCrudOperationApp.EmployeeData
{
    
    public class MockEmployeeData : IEmployeeData
    {
        private List<Employee> employees = new List<Employee>()
        {
            new Employee()
            {
                EmpNo = Guid.NewGuid(),
                Fname = "mayada",
                Lname = "mohamed",
                Salary = 12000
            },
              new Employee()
            {
                EmpNo = Guid.NewGuid(),
                Fname = "Sayed",
                Lname = "mohamed",
                Salary = 15000
            }
        };
        public Employee AddEmployee(Employee employee)
        {
            employee.EmpNo = Guid.NewGuid();
            employees.Add(employee);
            return employee;
        }

        public void DeleteEmployee(Employee employee)
        {
            employees.Remove(employee);
        }

        public Employee EditEmployee(Employee employee)
        {
            var existingEmployee = GetEmployee(employee.EmpNo);
            existingEmployee.Fname = employee.Fname;
            existingEmployee.Lname = employee.Lname;
            existingEmployee.Salary = employee.Salary;
            return existingEmployee;
        }

        public Employee GetEmployee(Guid id)
        {
            return employees.SingleOrDefault(x => x.EmpNo == id);
        }

        public List<Employee> GetEmployees()
        {
            return employees;
        }
    }
}
