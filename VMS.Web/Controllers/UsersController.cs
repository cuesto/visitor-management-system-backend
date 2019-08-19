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
using VMS.DataModel.Services;
using VMS.DataModel.Validators;

namespace VMS.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : BaseController
    {
        private readonly MyDbContext _context;

        public UsersController(MyDbContext context) : base(context)
        {
            _context = context;
        }

        // GET: api/Users
        [HttpGet("[action]")]
        public ActionResult<IEnumerable<User>> GetUsers()
        {
            using (var uow = new UnitOfWork(_context))
            {
                return uow.GetGenericRepository<User>().Get(includeProperties: "Role").Where(x => x.IsDeleted == IsDeleted.False).ToList();
            }
        }

        // GET: api/Users/5
        [HttpGet("[action]/{key}")]
        public async Task<ActionResult<User>> GetUser(int key)
        {
            var user = await _context.User.FindAsync(key);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // PUT: api/Users/5
        [HttpPut("[action]")]
        public async Task<IActionResult> PutUser(User user)
        {
            user = SetPassword(user);
            return await UpdateAsync<User, UserValidator>(user);
        }

        // POST: api/Users
        [HttpPost("[action]")]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            user = SetPassword(user);
            return await CreateAsync<User, UserValidator>(user);
        }

        private User SetPassword(User user)
        {
            BaseEntityServices.CreatePasswordHash(user.Password, out byte[] passwordHash, out byte[] passwordSalt);

            user.password_hash = passwordHash;
            user.password_salt = passwordSalt;
            return user;
        }

        // DELETE: api/Users/5
        [HttpDelete("[action]/{key}")]
        public async Task<ActionResult<User>> DeleteUser(int key)
        {
            return await DeleteAsync<User>(key);
        }

    }
}
