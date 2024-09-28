using Microsoft.AspNetCore.Mvc;
using Philharmonic.Areas.NotCookiesProject.Models;
using Philharmonic.Areas.NotCookiesProject.Services;

namespace Philharmonic.Areas.NotCookiesProject.Controllers
{
    [Area("NotCookiesProject")]
    public class FileController : Controller
    {
        private readonly IFileChecking _fileChecking;

        public FileController(IFileChecking fileChecking)
        {
            _fileChecking = fileChecking;
        }

        public IActionResult Index()
        {
            if (_fileChecking.ConditionFile()) 
            {
                var per = _fileChecking.ReadFile().GetDateDifference().Days;
                return RedirectToAction("index","home",new { area = "NotCookiesProject", myParameter = $"{per}" });
            }
            return View();
        }

        [HttpPost]
        public IActionResult Check(DateModel dateModel) 
        {
            if (ModelState.IsValid) 
            {
                _fileChecking.WriteFile(dateModel);
                return RedirectToAction("index", "home", new { area = "NotCookiesProject" });
            }
            return View("index");
        }

    }
}
