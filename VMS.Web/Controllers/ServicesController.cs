using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VMS.DataModel.DAL;
using VMS.Utils;

namespace VMS.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : BaseController
    {
        private readonly MyDbContext _context;

        public ServicesController(MyDbContext context) : base(context)
        {
            _context = context;
        }

        // GET: api/VerifyRNC/40220076848
        [Authorize(Roles = "administrator,recepionist")]
        [HttpGet("[action]/{rnc}")]
        public ActionResult<object> VerifyRNC(string rnc)
        {
            var company = DGII.ConsultarRNC(rnc);

            if (company == null)
            {
                return NotFound();
            }

            return company;
        }
    }
}