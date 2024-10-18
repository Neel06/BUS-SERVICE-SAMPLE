﻿using Microsoft.AspNetCore.Mvc;
using BUS_SERVICE_SAMPLE.Models;
using BUS_SERVICE_SAMPLE.Interfaces;

namespace BUS_SERVICE_SAMPLE.Controllers
{
    public class AdminController : Controller
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IPassApplicationService _passApplicationService;
        private readonly IHttpContextAccessor _httpContext;

        public AdminController(IAuthenticationService authenticationService, IPassApplicationService passApplicationService, IHttpContextAccessor httpContext)
        {
            _authenticationService = authenticationService;
            _passApplicationService = passApplicationService;
            _httpContext = httpContext;
        }

        // GET: /Admin/Login    
        public IActionResult Login()
        {
            return View();
        }

        // POST: /Admin/Login
        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            try
            {
                var admin = _authenticationService.LoginAdmin(model.Email, model.Password);
                HttpContext.Session.SetString("AdminId", admin.AdminID.ToString());
                HttpContext.Session.SetString("Email", admin.Email.ToString());
                HttpContext.Session.SetString("UserRole", admin.UserRole.ToString());
                return RedirectToAction("Dashboard");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            return View(model);
        }

        // GET: /Admin/Dashboard
        public IActionResult Dashboard()
        {
            var applications = _passApplicationService.GetAllApplications();
            return View(applications);
        }

        // POST: /Admin/UpdateStatus
        [HttpPost]
        public IActionResult UpdateStatus(int applicationId, string status)
        {
            try
            {
                _passApplicationService.UpdateApplicationStatus(applicationId, status);
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        // GET: /Admin/Logout
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }

}
