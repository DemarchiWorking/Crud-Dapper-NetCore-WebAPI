using Dapper.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dapper.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeRepository employeeRepository;
        public EmployeeController()
        {
            employeeRepository = new EmployeeRepository();
        }
        [HttpGet]
        [Route("")]
        public IEnumerable<Employee> GetAll()
        {
            return employeeRepository.GetAll();
        }
        [HttpGet]
        [Route("{id}")]
        public Employee GetById(int id)
        {
            return employeeRepository.GetById(id);
        }

        [HttpPost]
        public void Post([FromBody]Employee employee)
        {
            if (ModelState.IsValid)
                employeeRepository.Add(employee);
        }

        [HttpPut("{id}")]
        public void Put(int id,[FromBody] Employee employee)
        {
            employee.EmpId = id;

            if (ModelState.IsValid)
                employeeRepository.Update(employee);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            employeeRepository.Delete(id);
        }
    }
}
