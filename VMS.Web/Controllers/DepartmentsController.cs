﻿using Microsoft.AspNetCore.Mvc;
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
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Department>>> GetDepartment()
        {
            return await _context.Department.Where(x => x.IsDeleted == IsDeleted.False).ToListAsync();
        }

        // GET: api/Departments/5
        [HttpGet("{key}")]
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
        [HttpPut("{key}")]
        public async Task<IActionResult> PutDepartment(int key, Department department)
        {
            if (key != department.DepartmentKey)
            {
                return BadRequest();
            }

            return await UpdateAsync<Department, DepartmentValidator>(department);
        }

        // POST: api/Departments
        [HttpPost]
        public async Task<ActionResult<Department>> PostDepartment(Department department)
        {
            return await CreateAsync<Department, DepartmentValidator>(department);
        }

        // DELETE: api/Departments/5
        [HttpDelete("{key}")]
        public async Task<ActionResult<Department>> DeleteDepartment(int key)
        {
            return await DeleteAsync<Department>(key);
        }

    }
}
