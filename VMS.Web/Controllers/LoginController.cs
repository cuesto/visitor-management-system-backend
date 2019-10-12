using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using VMS.DataModel.DAL;
using VMS.DataModel.Entities;

namespace VMS.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : BaseController
    {
        private readonly MyDbContext _context;
        private readonly IConfiguration _config;

        public LoginController(MyDbContext context, IConfiguration config) : base(context)
        {
            _context = context;
            _config = config;
        }

        [HttpPost("[action]")]
        public ActionResult Login(Login model)
        {
            using (var uow = new UnitOfWork(_context))
            {
                var userName = model.userName.ToLower();

                var user = uow.GetGenericRepository<User>().Get(includeProperties: "Role")
                    .Where(x => x.IsDeleted == DataModel.Enums.IsDeleted.False)
                    .FirstOrDefault(x => x.Name == userName);

                if (user == null)
                    return NotFound();

                if (!VerifyPasswordHash(model.password, user.password_hash, user.password_salt))
                    return NotFound();

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, user.UserKey.ToString()),
                    new Claim(ClaimTypes.Email, userName),
                    new Claim(ClaimTypes.Role, user.Role.Name ),
                    new Claim("userkey", user.UserKey.ToString() ),
                    new Claim("role", user.Role.Name),
                    new Claim("name",user.Name)
                };

                return  Ok(
                   new { token = GenerateToken(claims) }
               );
            }
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHashStored, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var passwordHashNew = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return new ReadOnlySpan<byte>(passwordHashStored).SequenceEqual(new ReadOnlySpan<byte>(passwordHashNew));
            }
        }

        private string GenerateToken(List<Claim> claims)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
              _config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              expires: DateTime.Now.AddYears(1),
              signingCredentials: creds,
              claims: claims);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}