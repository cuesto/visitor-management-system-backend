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
using VMS.Utils;

namespace VMS.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeRequestsController : BaseController
    {
        private readonly MyDbContext _context;

        public EmployeeRequestsController(MyDbContext context) : base(context)
        {
            _context = context;
        }

        // GET: api/EmployeeRequests
        [Authorize(Roles = "administrator,recepionist")]
        [HttpGet("[action]")]
        public ActionResult<IEnumerable<EmployeeRequest>> GetEmployeeRequests()
        {
            using (var uow = new UnitOfWork(_context))
            {
                return uow.GetGenericRepository<EmployeeRequest>().Get(includeProperties: "Employee,Purpose,Employee.Department")
                    .Where(x => x.IsDeleted == IsDeleted.False && x.Status == Status.RequestIn &&
                    x.StartDate == (DateTime.Today.AddDays(0))).OrderByDescending(x => x.EmployeeRequestKey).ToList();
            }
        }

        // GET: api/EmployeeRequests/5
        [Authorize(Roles = "administrator,recepionist")]
        [HttpGet("[action]/{key}")]
        public async Task<ActionResult<EmployeeRequest>> GetEmployeeRequest(int key)
        {
            var employeeRequest = await _context.EmployeeRequest.FindAsync(key);

            if (employeeRequest == null)
            {
                return NotFound();
            }

            return employeeRequest;
        }

        // PUT: api/EmployeeRequests/5
        [Authorize(Roles = "administrator,recepionist")]
        [HttpPut("[action]")]
        public async Task<IActionResult> PutEmployeeRequest(EmployeeRequest employeeRequest)
        {
            return await UpdateAsync<EmployeeRequest, EmployeeRequestValidator>(employeeRequest);
        }

        // POST: api/EmployeeRequests
        [Authorize(Roles = "administrator")]
        [HttpPost("[action]")]
        public async Task<ActionResult<EmployeeRequest>> PostEmployeeRequest(EmployeeRequest er)
        {
            List<DateTime> dates = DatesService.GetDatesFromCheckBoxes((DateTime)er.StartDate, (DateTime)er.EndDate, er.DaysList);

            if (dates.Count == 0)
            {
                dates.Add((DateTime)er.StartDate);
            }

            foreach (var date in dates)
            {
                try
                {
                    var employeeReq = new EmployeeRequest()
                    {
                        EmployeeKey = er.EmployeeKey,
                        VisitorName = er.VisitorName,
                        VisitorEmail = er.VisitorEmail,
                        VisitorPhone = er.VisitorPhone,
                        TaxNumber = er.TaxNumber,
                        Company = er.Company,
                        PurposeKey = er.PurposeKey,
                        StartDate = date,
                        StartTime = er.StartTime,
                        EndDate = date,
                        EndTime = er.EndTime,
                        Comments = er.Comments,
                        Status = Status.RequestIn,
                        DaysList = er.DaysList,
                        CreatedBy = er.CreatedBy
                    };

                    await CreateAsync<EmployeeRequest, EmployeeRequestValidator>(employeeReq);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.InnerException);
                }
            }

            return Json(new { Result = "OK", Record = "Se registró correctamente." });
        }

        //[Authorize(Roles = "administrator")]
        [HttpPost("[action]")]
        public async Task<ActionResult<List<EmployeeRequest>>> PostEmployeeRequests(List<EmployeeRequest> erList)
        {
            if (erList.Count == 0)
                return BadRequest("No se cargó la plantilla correctamente.");

            foreach (var er in erList)
            {
                List<DateTime> dates = DatesService.GetDatesFromCheckBoxes((DateTime)er.StartDate, (DateTime)er.EndDate, er.DaysList);

                if (dates.Count == 0)
                {
                    dates.Add((DateTime)er.StartDate);
                }

                foreach (var date in dates)
                {
                    try
                    {
                        var employeeReq = new EmployeeRequest()
                        {
                            EmployeeKey = er.EmployeeKey,
                            VisitorName = er.VisitorName,
                            VisitorEmail = er.VisitorEmail,
                            VisitorPhone = er.VisitorPhone,
                            TaxNumber = er.TaxNumber,
                            Company = er.Company,
                            PurposeKey = er.PurposeKey,
                            StartDate = date,
                            StartTime = er.StartTime,
                            EndDate = date,
                            EndTime = er.EndTime,
                            Comments = er.Comments,
                            Status = Status.RequestIn,
                            DaysList = er.DaysList,
                            CreatedBy = er.CreatedBy
                        };

                        await CreateAsync<EmployeeRequest, EmployeeRequestValidator>(employeeReq);
                    }
                    catch (Exception ex)
                    {
                        return BadRequest(ex.InnerException);
                    }
                }
            }
            return Json(new { Result = "OK", Record = "Se registraron las solicitudes correctamente." });
        }

        // DELETE: api/EmployeeRequests/5
        [Authorize(Roles = "administrator")]
        [HttpDelete("[action]/{key}")]
        public async Task<ActionResult<EmployeeRequest>> DeleteEmployeeRequest(int key)
        {
            return await DeleteAsync<EmployeeRequest>(key);
        }

    }
}
