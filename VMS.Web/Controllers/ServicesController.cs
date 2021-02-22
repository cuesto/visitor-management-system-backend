
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Octetus.ConsultasDgii.ConsultasWeb;
using Octetus.ConsultasDgii.Core.Messages;
using VMS.DataModel.DAL;
using VMS.DataModel.Entities;

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
        //[Authorize(Roles = "administrator,recepionist")]
        [HttpGet("[action]/{rnc}")]
        public ActionResult<ResultRnc> VerifyRNC(string rnc)
        {
            var dgii = new DgiiScraper();
            var resultRNC = new ResultRnc();

            var response = dgii.Execute(new DgiiQueryRequest
            {
                Rnc = rnc
            });

            if (response.IsOk)
            {
                resultRNC.CedulaRnc = response.Rnc;
                resultRNC.Nombre = response.Nombre;
            }

            if (string.IsNullOrEmpty(resultRNC.Nombre))
            {
                return NotFound();
            }

            return resultRNC;
        }
    }
}