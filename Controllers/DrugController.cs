using Microsoft.AspNetCore.Mvc;
using PharmacyManagementSystem.Models;
using PharmacyManagementSystem.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyManagementSystem.Controllers
{
    public class DrugController : Controller
    {
        private readonly IGenericRepository<DrugModel> _repository;
        public DrugController(IGenericRepository<DrugModel> repository)
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
        public IActionResult AddDrug()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddDrug(DrugModel model)
        {
            if (ModelState.IsValid)
            {
                _repository.Insert(model);
                _repository.Save();
                return RedirectToAction("Index", "Drug");
            }
            return View();
        }
        [HttpGet]
        public IActionResult GetDrugDetails(int drugId)
        {
            DrugModel model = _repository.GetById(drugId);
            return View(model);
        }

        [HttpGet]
        public IActionResult EditDrug(int drugId)
        {
            DrugModel model = _repository.GetById(drugId);
            return View(model);
        }
        [HttpPost]
        public IActionResult EditDrug(DrugModel model)
        {
            if (ModelState.IsValid)
            {
                _repository.Update(model);
                _repository.Save();
                return RedirectToAction("Index", "Drug");
            }
            else
            {
                return View(model);
            }
        }
        [HttpGet]
        public IActionResult DeleteDrug(int drugId)
        {
            DrugModel model = _repository.GetById(drugId);
            return View(model);
        }
        [HttpPost]
        public IActionResult Delete(int drugId)
        {
            _repository.Delete(drugId);
            _repository.Save();
            return RedirectToAction("Index", "Drug");
        }
    }
}
