using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize(Roles = "administrator,recepionist")]
        [HttpGet("[action]")]
        public ActionResult<IEnumerable<Employee>> GetEmployees()
        {
            using(var uow = new UnitOfWork(_context))
            {
                return  uow.GetGenericRepository<Employee>().Get(includeProperties: "Department").Where(x => x.IsDeleted == IsDeleted.False).ToList();
            }
        }

        // GET: api/Employee/5
        [Authorize(Roles = "administrator,recepionist")]
        [HttpGet("[action]/{key}")]
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
        [Authorize(Roles = "administrator")]
        [HttpPut("[action]")]
        public async Task<IActionResult> PutEmployee(Employee employee)
        {
            return await UpdateAsync<Employee, EmployeeValidator>(employee);
        }

        // POST: api/Employees
        [Authorize(Roles = "administrator")]
        [HttpPost("[action]")]
        public async Task<ActionResult<Employee>> PostEmployee(Employee employee)
        {
            return await CreateAsync<Employee, EmployeeValidator>(employee);
        }

        // DELETE: api/Employees/5
        [Authorize(Roles = "administrator")]
        [HttpDelete("[action]/{key}")]
        public async Task<ActionResult<Employee>> DeleteEmployee(int key)
        {
            return await DeleteAsync<Employee>(key);
        }

    }
}
