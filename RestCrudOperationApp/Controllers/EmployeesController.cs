﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestCrudOperationApp.EmployeeData;
using RestCrudOperationApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestCrudOperationApp.Controllers
{
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private IEmployeeData _employeeData;
        public EmployeesController(IEmployeeData employeeData)
        {
            _employeeData = employeeData;
        }
        [HttpGet]
        [Route("api/[controller]")]
        public IActionResult GetEmployees()
        {
            return Ok(_employeeData.GetEmployees());
        }

        [HttpGet]
        [Route("api/[controller]/{id}")]
        public IActionResult GetEmployee(Guid id)
        {
            var employee = _employeeData.GetEmployee(id);
           
            if (employee != null)
            {
                return Ok(employee);
            }
            return NotFound($"Employee with id : {id} not found");
        }

        [HttpPost]
        [Route("api/[controller]")]
        public IActionResult addEmployee(Employee employee)
        {
             _employeeData.AddEmployee(employee);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + employee.EmpNo, employee);
        }

        [HttpDelete]
        [Route("api/[controller]/{id}")]
        public IActionResult DeleteEmployee(Guid id)
        {
            var employee = _employeeData.GetEmployee(id);

            if (employee != null)
            {
                _employeeData.DeleteEmployee(employee);
                return Ok();
;            }
            return NotFound($"Employee with id : {id} not found");
        }

        [HttpPatch]
        [Route("api/[controller]/{id}")]
        public IActionResult EditEmployee(Guid id,Employee employee)
        {
            var existingEmployee = _employeeData.GetEmployee(id);
            if(existingEmployee != null)
            {
                employee.EmpNo = existingEmployee.EmpNo;
                _employeeData.EditEmployee(employee);
                
            }
            return Ok(employee);
        }
    }
}
