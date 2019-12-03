using Microsoft.AspNetCore.Mvc;

namespace VMS.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}