using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VMS.DataModel.DAL;
using VMS.DataModel.Entities;
using VMS.DataModel.Enums;
using VMS.DataModel.Validators;

namespace VMS.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : BaseController
    {
        private readonly MyDbContext _context;

        public DepartmentsController(MyDbContext context) : base(context)
        {
            _context = context;
        }

        // GET: api/Departments
        [HttpGet("[action]")]
        public async Task<ActionResult<IEnumerable<Department>>> GetDepartments()
        {
            return await _context.Department.Where(x => x.IsDeleted == IsDeleted.False).ToListAsync();
        }

        // GET: api/Departments/5
        [HttpGet("[action]/{key}")]
        public async Task<ActionResult<Department>> GetDepartment(int key)
        {
            var department = await _context.Department.FindAsync(key);

            if (department == null)
            {
                return NotFound();
            }

            return department;
        }

        // PUT: api/Departments/5
        [HttpPut("[action]")]
        public async Task<IActionResult> PutDepartment(Department department)
        {
            return await UpdateAsync<Department, DepartmentValidator>(department);
        }

        // POST: api/Departments
        [HttpPost("[action]")]
        public async Task<ActionResult<Department>> PostDepartment(Department department)
        {
            return await CreateAsync<Department, DepartmentValidator>(department);
        }

        // DELETE: api/Departments/5
        [HttpDelete("[action]/{key}")]
        public async Task<ActionResult<Department>> DeleteDepartment(int key)
        {
            return await DeleteAsync<Department>(key);
        }

    }
}
