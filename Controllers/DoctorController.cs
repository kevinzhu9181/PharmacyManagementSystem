using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PharmacyManagementSystem.Models;
using PharmacyManagementSystem.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyManagementSystem.Controllers
{
    public class DoctorController : Controller
    {
        private readonly IGenericRepository<DoctorModel> _repository;
        public DoctorController(IGenericRepository<DoctorModel> repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var userId = HttpContext.Session.GetString("UserId");
            if (userId != null)
            {
                var model = _repository.GetAll();
                return View(model);
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
        }
        [HttpGet]
        public IActionResult AddDoctor()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddDoctor(DoctorModel model)
        {
            if (ModelState.IsValid)
            {
                _repository.Insert(model);
                _repository.Save();
                return RedirectToAction("Index", "Doctor");
            }
            return View();
        }
        [HttpGet]
        public IActionResult GetDoctorDetails(int doctorId)
        {
            DoctorModel model = _repository.GetById(doctorId);
            return View(model);
        }

        [HttpGet]
        public IActionResult EditDoctor(int doctorId)
        {
            DoctorModel model = _repository.GetById(doctorId);
            return View(model);
        }
        [HttpPost]
        public IActionResult EditDoctor(DoctorModel model)
        {
            if (ModelState.IsValid)
            {
                _repository.Update(model);
                _repository.Save();
                return RedirectToAction("Index", "Doctor");
            }
            else
            {
                return View(model);
            }
        }
        [HttpGet]
        public IActionResult DeleteDoctor(int doctorId)
        {
            DoctorModel model = _repository.GetById(doctorId);
            return View(model);
        }
        [HttpPost]
        public IActionResult Delete(int doctorId)
        {
            _repository.Delete(doctorId);
            _repository.Save();
            return RedirectToAction("Index", "Doctor");
        }
    }
}
