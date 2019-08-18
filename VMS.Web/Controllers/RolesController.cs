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
    public class RolesController : BaseController
    {
        private readonly MyDbContext _context;

        public RolesController(MyDbContext context) : base(context)
        {
            _context = context;
        }

        // GET: api/Roles
        [HttpGet("[action]")]
        public async Task<ActionResult<IEnumerable<Role>>> GetRoles()
        {
            return await _context.Role.Where(x => x.IsDeleted == IsDeleted.False).ToListAsync();
        }

        // GET: api/Roles/5
        [HttpGet("[action]/{key}")]
        public async Task<ActionResult<Role>> GetRole(int key)
        {
            var role = await _context.Role.FindAsync(key);

            if (role == null)
            {
                return NotFound();
            }

            return role;
        }

        // PUT: api/Roles/5
        [HttpPut("[action]")]
        public async Task<IActionResult> PutRole(Role role)
        {
            return await UpdateAsync<Role, RoleValidator>(role);
        }

        // POST: api/Roles
        [HttpPost("[action]")]
        public async Task<ActionResult<Role>> PostRole(Role role)
        {
            return await CreateAsync<Role, RoleValidator>(role);
        }

        // DELETE: api/Roles/5
        [HttpDelete("[action]/{key}")]
        public async Task<ActionResult<Role>> DeleteRole(int key)
        {
            return await DeleteAsync<Role>(key);
        }

    }
}
