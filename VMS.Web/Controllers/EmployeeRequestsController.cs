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
    public class EmployeeRequestsController : BaseController
    {
        private readonly MyDbContext _context;

        public EmployeeRequestsController(MyDbContext context) : base(context)
        {
            _context = context;
        }

        // GET: api/EmployeeRequests
        [HttpGet("[action]")]
        public ActionResult<IEnumerable<EmployeeRequest>> GetEmployeeRequests()
        {
            using (var uow = new UnitOfWork(_context))
            {
                return uow.GetGenericRepository<EmployeeRequest>().Get(includeProperties: "Employee,Purpose").Where(x => x.IsDeleted == IsDeleted.False).ToList();
            }
        }

        // GET: api/EmployeeRequests/5
        [HttpGet("[action]/{key}")]
        public async Task<ActionResult<EmployeeRequest>> GetEmployeeRequest(int key)
        {
            var employeeRequest = await _context.EmployeeRequest.FindAsync(key);

            if (employeeRequest == null)
            {
                return NotFound();
            }

            return employeeRequest;
        }

        // PUT: api/EmployeeRequests/5
        [HttpPut("[action]")]
        public async Task<IActionResult> PutEmployeeRequest(EmployeeRequest employeeRequest)
        {
            return await UpdateAsync<EmployeeRequest, EmployeeRequestValidator>(employeeRequest);
        }

        // POST: api/EmployeeRequests
        [HttpPost("[action]")]
        public async Task<ActionResult<EmployeeRequest>> PostEmployeeRequest(EmployeeRequest employeeRequest)
        {
            return await CreateAsync<EmployeeRequest, EmployeeRequestValidator>(employeeRequest);
        }

        // DELETE: api/EmployeeRequests/5
        [HttpDelete("[action]/{key}")]
        public async Task<ActionResult<EmployeeRequest>> DeleteEmployeeRequest(int key)
        {
            return await DeleteAsync<EmployeeRequest>(key);
        }

    }
}
