using System.Diagnostics;
using Day04Lap_LayOut.Models;
using Microsoft.AspNetCore.Mvc;

namespace Day04Lap_LayOut.Controllers
{
    public class HomeController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(Student student)
        {
            return View(student);
        }
        [HttpGet]
        public IActionResult Privacy()
        {
            return View(new Student());
        }
        [HttpPost]
        public IActionResult Privacy(Student student)
        {
            if (student == null || student.Id==0)
            {
                // Nếu dữ liệu rỗng thì load lại form
                return View(new Student());
            }
            return RedirectToAction("Index",student);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
