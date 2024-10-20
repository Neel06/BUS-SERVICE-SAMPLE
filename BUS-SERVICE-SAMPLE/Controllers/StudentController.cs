using Microsoft.AspNetCore.Mvc;
using BUS_SERVICE_SAMPLE.Models;
using BUS_SERVICE_SAMPLE.Interfaces;
using BUS_SERVICE_SAMPLE.Helpers;

namespace BUS_SERVICE_SAMPLE.Controllers
{
    public class StudentController : Controller
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IPassApplicationService _passApplicationService;
        private readonly IHttpContextAccessor _httpContext;

        public StudentController(IAuthenticationService authenticationService, IPassApplicationService passApplicationService
            , IHttpContextAccessor httpContext)
        {
            _authenticationService = authenticationService;
            _passApplicationService = passApplicationService;
            _httpContext = httpContext;
        }


        // GET: /Student/Register
        public IActionResult Register()
        {
            return View();
        }

        // POST: /Student/Register
        [HttpPost]
        public IActionResult Register(StudentRegistrationViewModel model)
        {
            //if (ModelState.IsValid)
            //{
            _authenticationService.RegisterStudent(model);
            return RedirectToAction("Login");

            //}
            //return View(model);
        }

        // GET: /Student/Login
        public IActionResult Login()
        {
            return View();
        }

        // POST: /Student/Login
        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            //if (ModelState.IsValid)
            //{
            try
            {
                var student = _authenticationService.LoginStudent(model.Email, model.Password);
                HttpContext.Session.SetString("Email", student.Email.ToString());
                HttpContext.Session.SetString("StudentName", student.Name.ToString());
                HttpContext.Session.SetString("StudentID", student.StudentID);
                return RedirectToAction("Dashboard");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            //}
            return View(model);
        }

        // GET: /Student/Dashboard
        [CustomAuthorize]
        public IActionResult Dashboard()
        {
            var studentId = HttpContext.Session.GetString("StudentID");
            var applications = _passApplicationService.GetStudentApplications(studentId);
            return View(applications);
        }

        // GET: /Student/ApplyPass
        [CustomAuthorize]
        public IActionResult ApplyPass()
        {
            return View();
        }

        // POST: /Student/ApplyPass
        [HttpPost]
        [CustomAuthorize]
        public IActionResult ApplyPass(PassApplicationViewModel model)
        {
            var studentId = HttpContext.Session.GetString("StudentID");
            model.StudentID = studentId;

            _passApplicationService.ApplyForPass(model);
            return RedirectToAction("Dashboard");

            //return View(model);
        }

        // GET: /Student/Logout
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }

        [CustomAuthorize]
        public IActionResult ShowApplicationDetails()
        {
            var studentId = HttpContext.Session.GetString("StudentID");
            if (studentId == null)
                ArgumentNullException.ThrowIfNull(studentId);
            PassApplication application =  _passApplicationService.GetStudentApplications(studentId).FirstOrDefault();

            return View("~/Views/Shared/ApplicationDetails.cshtml", application);
        }
    }

}
