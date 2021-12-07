using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PharmacyManagementSystem.Models;
using PharmacyManagementSystem.Repositories;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace PharmacyManagementSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IGenericRepository<LoginModel> _repository;

        public HomeController(ILogger<HomeController> logger, IGenericRepository<LoginModel> repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginModel user)
        {
            if (ModelState.IsValid)
            {
                var model = _repository.GetAll();
                var obj = model.Where(a => a.UserName.Equals(user.UserName) && a.Password.Equals(user.Password)).FirstOrDefault();
                if (obj != null)
                {
                    HttpContext.Session.SetString("UserId", obj.Id.ToString());
                    return RedirectToAction("Index");
                }
            }
            return View(user);
        }

        public IActionResult Index()
        {
            var userId = HttpContext.Session.GetString("UserId");
            if (userId != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
