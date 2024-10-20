using BUS_SERVICE_SAMPLE.Helpers;
using BUS_SERVICE_SAMPLE.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BUS_SERVICE_SAMPLE.Controllers
{

    public class PassApplicationController : Controller
    {
        private readonly IPassApplicationService _passApplicationService;
        private readonly IHttpContextAccessor _httpContext;

        public PassApplicationController(IPassApplicationService passApplicationService, IHttpContextAccessor httpContext)
        {
            _passApplicationService = passApplicationService;
            _httpContext = httpContext;
        }

        // GET: /PassApplication/Details/{id}
        [CustomAuthorize]
        public IActionResult Details(string id)
        {
            var application = _passApplicationService.GetStudentApplications(id);
            if (application == null)
            {
                return NotFound();
            }
            return View(application);
        }
    }

}
