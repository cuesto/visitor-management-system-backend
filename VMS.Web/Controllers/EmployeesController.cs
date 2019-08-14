using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VMS.DataModel.DAL;
using VMS.DataModel.Entities;
using VMS.DataModel.Enums;
using VMS.DataModel.Validators;

namespace VMS.Web.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : BaseController
    {
        private readonly MyDbContext _context;

        public EmployeesController(MyDbContext context) : base(context)
        {
            _context = context;
        }

        // GET: api/Employees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployee()
        {
            return await _context.Employee.Where(x => x.IsDeleted == IsDeleted.False).ToListAsync();
        }

        // GET: api/Employee/5
        [HttpGet("{key}")]
        public async Task<ActionResult<Employee>> GetEmployee(int key)
        {
            var employee = await _context.Employee.FindAsync(key);

            if (employee == null)
            {
                return NotFound();
            }

            return employee;
        }

        // PUT: api/Employees/5
        [HttpPut("{key}")]
        public async Task<IActionResult> PutEmployee(int key, Employee employee)
        {
            if (key != employee.EmployeeKey)
            {
                return BadRequest();
            }

            return await UpdateAsync<Employee, EmployeeValidator>(employee);
        }

        // POST: api/Employees
        [HttpPost]
        public async Task<ActionResult<Employee>> PostEmployee(Employee employee)
        {
            return await CreateAsync<Employee, EmployeeValidator>(employee);
        }

        // DELETE: api/Employees/5
        [HttpDelete("{key}")]
        public async Task<ActionResult<Employee>> DeleteEmployee(int id)
        {
            return await DeleteAsync<Employee>(id);
        }

    }
}
