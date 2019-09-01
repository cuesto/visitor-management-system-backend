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
    public class VisitorsController : BaseController
    {
        private readonly MyDbContext _context;

        public VisitorsController(MyDbContext context) : base(context)
        {
            _context = context;
        }

        // GET: api/Visitors
        [HttpGet("[action]")]
        public async Task<ActionResult<IEnumerable<Visitor>>> GetVisitors()
        {
            return await _context.Visitor.Where(x => x.IsDeleted == IsDeleted.False && x.Status == Status.VisitorIn).ToListAsync();
        }

        // GET: api/Visitors/5
        [HttpGet("[action]/{key}")]
        public async Task<ActionResult<Visitor>> GetVisitor(int key)
        {
            var visitor = await _context.Visitor.FindAsync(key);

            if (visitor == null)
            {
                return NotFound();
            }

            return visitor;
        }

        // PUT: api/Visitors/5
        [HttpPut("[action]")]
        public async Task<IActionResult> PutVisitor(Visitor visitor)
        {
            return await UpdateAsync<Visitor, VisitorValidator>(visitor);
        }

        // POST: api/Visitors
        [HttpPost("[action]")]
        public async Task<ActionResult<Visitor>> PostVisitor(Visitor visitor)
        {
            visitor.StartDate = DateTime.Now;
            visitor.EndDate = DateTime.Now;
            return await CreateAsync<Visitor, VisitorValidator>(visitor);
        }

        // DELETE: api/Visitors/5
        [HttpDelete("[action]/{key}")]
        public async Task<ActionResult<Visitor>> DeleteVisitor(int key)
        {
            return await DeleteAsync<Visitor>(key);
        }

    }
}
