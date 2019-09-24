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
    public class PurposesController : BaseController
    {
        private readonly MyDbContext _context;

        public PurposesController(MyDbContext context) : base(context)
        {
            _context = context;
        }

        // GET: api/VisitorByPurpose
        [Authorize(Roles = "administrator,recepionist")]
        [HttpGet("[action]")]
        public ActionResult<IEnumerable<PurposeCount>> GetVisitorsPurpose()
        {
            using (var uow = new UnitOfWork(_context))
            {
                var visitors = uow.GetGenericRepository<Visitor>().Get().Where(x => x.IsDeleted == IsDeleted.False
                && x.Status == Status.VisitorIn).ToList();
                var purposes = uow.GetGenericRepository<Purpose>().Get().Where(x => x.IsDeleted == IsDeleted.False).ToList();
                var visitorsByPurposeList = new List<PurposeCount>();

                purposes.ForEach(x =>
                {
                    visitorsByPurposeList.Add(new PurposeCount
                    {
                        description = x.Description,
                        value = visitors.Where(c => c.PurposeKey == x.PurposeKey).Count()
                    });
                });

                return visitorsByPurposeList.OrderByDescending(x => x.value).ToList();
            }
        }

        // GET: api/Purposes
        [HttpGet("[action]")]
        public async Task<ActionResult<IEnumerable<Purpose>>> GetPurposes()
        {
            return await _context.Purpose.Where(x => x.IsDeleted == IsDeleted.False).ToListAsync();
        }

        // GET: api/Purposes/5
        [HttpGet("[action]/{key}")]
        public async Task<ActionResult<Purpose>> GetPurpose(int key)
        {
            var Purpose = await _context.Purpose.FindAsync(key);

            if (Purpose == null)
            {
                return NotFound();
            }

            return Purpose;
        }

        // PUT: api/Purposes/5
        [HttpPut("[action]")]
        public async Task<IActionResult> PutPurpose(Purpose Purpose)
        {
            return await UpdateAsync<Purpose, PurposeValidator>(Purpose);
        }

        // POST: api/Purposes
        [HttpPost("[action]")]
        public async Task<ActionResult<Purpose>> PostPurpose(Purpose Purpose)
        {
            return await CreateAsync<Purpose, PurposeValidator>(Purpose);
        }

        // DELETE: api/Purposes/5
        [HttpDelete("[action]/{key}")]
        public async Task<ActionResult<Purpose>> DeletePurpose(int key)
        {
            return await DeleteAsync<Purpose>(key);
        }

    }

    public class PurposeCount
    {
        public string description { get; set; }
        public int value { get; set; }
    }
}
