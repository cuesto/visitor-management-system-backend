using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VMS.DataModel.DAL;
using VMS.DataModel.Entities;
using VMS.DataModel.Enums;
using VMS.DataModel.Validators;

namespace VMS.Web.Controllers
{
    [Authorize(Roles = "administrator,recepionist")]
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
        public ActionResult<IEnumerable<Visitor>> GetVisitors()
        {
            using (var uow = new UnitOfWork(_context))
            {
                return uow.GetGenericRepository<Visitor>().Get(includeProperties: "Employee.Department,Purpose,")
                    .Where(x => x.IsDeleted == IsDeleted.False && x.Status == Status.VisitorIn).OrderByDescending(x => x.VisitorKey).ToList();
            }
        }

        // GET: api/Visitors
        [HttpGet("[action]/{startdate}/{enddate}")]
        public ActionResult<IEnumerable<Visitor>> GetVisitors(DateTime startdate, DateTime enddate)
        {
            using (var uow = new UnitOfWork(_context))
            {
                return uow.GetGenericRepository<Visitor>().Get(includeProperties: "Employee.Department,Purpose,")
                    .Where(x => x.IsDeleted == IsDeleted.False && (x.StartDate >= startdate && x.EndDate <= enddate)).OrderByDescending(x => x.VisitorKey).ToList();
            }
        }

        [HttpGet("[action]/{startdate}/{enddate}")]
        public ActionResult<IEnumerable<VisitorByDate>> GetVisitorsSummaryByDate(DateTime startdate, DateTime enddate)
        {
            using (var uow = new UnitOfWork(_context))
            {
                var visitors = uow.GetGenericRepository<Visitor>().Get(includeProperties: "Employee.Department,Purpose,")
                    .Where(x => x.IsDeleted == IsDeleted.False && (x.StartDate >= startdate && x.EndDate <= enddate)).ToList();

                return visitors.GroupBy(x => x.StartDate).Select(x => new VisitorByDate() { date = x.Key, value = x.Count() }).ToList(); ;
            }
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
        public async Task<ActionResult<Visitor>> PutVisitor(Visitor visitor)
        {
            return await UpdateAsync<Visitor, VisitorValidator>(visitor);
        }

        // POST: api/Visitors
        [HttpPost("[action]")]
        public async Task<ActionResult<Visitor>> PostVisitor(Visitor visitor)
        {
            visitor.StartDate = DateTime.Now;
            visitor.EndDate = DateTime.Now;
            visitor.Status = Status.VisitorIn;
            return await CreateAsync<Visitor, VisitorValidator>(visitor);
        }

        // DELETE: api/Visitors/5
        [HttpDelete("[action]/{key}")]
        public async Task<ActionResult<Visitor>> DeleteVisitor(int key)
        {
            return await DeleteAsync<Visitor>(key);
        }
    }

    public class VisitorByDate
    {
        public DateTime date { get; set; }
        public int value { get; set; }
    }
}
