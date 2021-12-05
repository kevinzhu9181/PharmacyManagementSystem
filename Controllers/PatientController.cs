using Microsoft.AspNetCore.Mvc;
using PharmacyManagementSystem.Models;
using PharmacyManagementSystem.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyManagementSystem.Controllers
{
    public class PatientController : Controller
    {
        private readonly IGenericRepository<PatientModel> _repository;
        public PatientController(IGenericRepository<PatientModel> repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var model = _repository.GetAll();
            return View(model);
        }
        [HttpGet]
        public IActionResult AddPatient()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddPatient(PatientModel model)
        {
            if (ModelState.IsValid)
            {
                _repository.Insert(model);
                _repository.Save();
                return RedirectToAction("Index", "Patient");
            }
            return View();
        }
        [HttpGet]
        public IActionResult GetPatientDetails(int patientId)
        {
            PatientModel model = _repository.GetById(patientId);
            return View(model);
        }

        [HttpGet]
        public IActionResult EditPatient(int patientId)
        {
            PatientModel model = _repository.GetById(patientId);
            return View(model);
        }
        [HttpPost]
        public IActionResult EditPatient(PatientModel model)
        {
            if (ModelState.IsValid)
            {
                _repository.Update(model);
                _repository.Save();
                return RedirectToAction("Index", "Patient");
            }
            else
            {
                return View(model);
            }
        }
        [HttpGet]
        public IActionResult DeletePatient(int patientId)
        {
            PatientModel model = _repository.GetById(patientId);
            return View(model);
        }
        [HttpPost]
        public IActionResult Delete(int patientId)
        {
            _repository.Delete(patientId);
            _repository.Save();
            return RedirectToAction("Index", "Patient");
        }
    }
}
