using BUS_SERVICE_SAMPLE.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BUS_SERVICE_SAMPLE.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpContextAccessor _httpContext;

        public HomeController(ILogger<HomeController> logger,IHttpContextAccessor httpContext)
        {
            _logger = logger;
            _httpContext = httpContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(string message)
        {
            ViewBag.ErrorMessage = message;
            return View(new CustomErrorModel { ErrorMessage = message });
        }
    }
}
