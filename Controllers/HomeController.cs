using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Philharmonic.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var userName = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;
            var daysLive = User.Claims.FirstOrDefault(c => c.Type == "DaysLived")?.Value;
            ViewBag.UserName = userName;
            ViewBag.DaysLive = daysLive;

            return View();
        }
    }
}
