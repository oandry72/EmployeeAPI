using EmployeeAPI.DBContexts;
using EmployeeAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace EmployeeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private MyDBContext myDbContext;

        public EmployeeController(MyDBContext context)
        {
            myDbContext = context;
        }

        [HttpGet]
        public IList<Employee> Get()
        {
            return (this.myDbContext.Employees.ToList());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(long id)
        {
            var employee = await myDbContext.Employees.FindAsync(id);

            if (employee == null)
            {
                return NotFound();
            }
            return employee;
        }
    }
}