using HealthApp.Models.PrimaryTableFitness;
using HealthApp.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HealthApp.WebMVC.Controllers
{
    public class PrimaryTableFitnessController : Controller
    {
        [Authorize]
        // GET: PrimaryTableFitness Index
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new PrimaryTableFitnessService(userId);
            var model = service.GetPrimaryTableFitness();

            return View(model);
        }

        //Add Method here VVV
        //Get: PrimaryTableFitness Create
        public ActionResult Create ()
        {
            return View();
        }

        //Add code here VVV
        //Get: PrimaryTableFitness Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PrimaryTableFitnessCreate model)
        {
            if (!ModelState.IsValid) return View(model);
            

            var service = CreatePrimaryTableFitnessTableServices();

            if (service.CreatePrimaryFitnessTable(model))
            {
                TempData["SaveResault"] = "Your fitness plan was saved!";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Your excersise plan could not be created.");

            return View(model);
        }

        private PrimaryTableFitnessService CreatePrimaryTableFitnessTableServices()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new PrimaryTableFitnessService(userId);
            return service;
        }
    }
}