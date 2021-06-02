using RestCrudOperationApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestCrudOperationApp.EmployeeData
{
    public class SqlEmployeeData : IEmployeeData
    {
        private EmployeeContext _employeeContext;
        public SqlEmployeeData(EmployeeContext employeeContext)
        {
            _employeeContext = employeeContext;
        }
        public Employee AddEmployee(Employee employee)
        {
            employee.EmpNo = Guid.NewGuid();
            _employeeContext.Employees.Add(employee);
            _employeeContext.SaveChanges();
            return employee;
        }

        public void DeleteEmployee(Employee employee)
        {
           
                _employeeContext.Employees.Remove(employee);
                _employeeContext.SaveChanges();

        }

        public Employee EditEmployee(Employee employee)
        {
            var existingEmployee = _employeeContext.Employees.Find(employee.EmpNo);

            if (existingEmployee != null)
            {
                existingEmployee.Fname = employee.Fname;
                existingEmployee.Lname = employee.Lname;
                existingEmployee.Salary = employee.Salary;
                _employeeContext.Employees.Update(existingEmployee);
                _employeeContext.SaveChanges();
            }

            return employee;
        }

        public Employee GetEmployee(Guid id)
        {
            return _employeeContext.Employees.SingleOrDefault(x => x.EmpNo == id);
        }

        public List<Employee> GetEmployees()
        {
           return _employeeContext.Employees.ToList();
        }
    }
}
