using Microsoft.AspNetCore.Authorization;
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
    public class BlackListsController : BaseController
    {
        private readonly MyDbContext _context;

        public BlackListsController(MyDbContext context) : base(context)
        {
            _context = context;
        }

        // GET: api/BlackLists
        //[Authorize(Roles = "administrator,recepionist")]
        [HttpGet("[action]")]
        public async Task<ActionResult<IEnumerable<BlackList>>> GetBlackLists()
        {
            return await _context.BlackList.Where(x => x.IsDeleted == IsDeleted.False).ToListAsync();
        }

        // GET: api/BlackLists/5
        //[Authorize(Roles = "administrator,recepionist")]
        [HttpGet("[action]/{key}")]
        public async Task<ActionResult<BlackList>> GetBlackList(int key)
        {
            var blackList = await _context.BlackList.FindAsync(key);

            if (blackList == null)
            {
                return NotFound();
            }

            return blackList;
        }

        // PUT: api/BlackLists/5
        //[Authorize(Roles = "administrator")]
        [HttpPut("[action]")]
        public async Task<ActionResult<BlackList>> PutBlackList(BlackList blackList)
        {
            return await UpdateAsync<BlackList, BlackListValidator>(blackList);
        }

        // POST: api/BlackLists
       //[Authorize(Roles = "administrator")]
        [HttpPost("[action]")]
        public async Task<ActionResult<BlackList>> PostBlackList(BlackList blackList)
        {
            return await CreateAsync<BlackList, BlackListValidator>(blackList);
        }

        // DELETE: api/BlackLists/5
        //[Authorize(Roles = "administrator")]
        [HttpDelete("[action]/{key}")]
        public async Task<ActionResult<BlackList>> DeleteBlackList(int key)
        {
            return await DeleteAsync<BlackList>(key);
        }

        //[Authorize(Roles = "administrator")]
        [HttpDelete("[action]")]
        public async Task<ActionResult<BlackList>> DeleteBlackList(BlackList blackList)
        {
            return await DeleteAsync<BlackList>(blackList);
        }

    }
}
