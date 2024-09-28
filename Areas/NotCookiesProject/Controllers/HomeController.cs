using Microsoft.AspNetCore.Mvc;

namespace Philharmonic.Areas.NotCookiesProject.Controllers
{
    [Area("NotCookiesProject")]
    public class HomeController : Controller
    {
        public IActionResult Index(string? myParameter)
        {
            ViewBag.MyParameter = myParameter;
            return View();
        }
    }
}
