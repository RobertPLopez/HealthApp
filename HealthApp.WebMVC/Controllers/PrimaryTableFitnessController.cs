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
            if (ModelState.IsValid)
            {
                return View(model);
            }

            var service = CreatePrimaryTableFitnessTableServices();

            service.CreatePrimaryFitnessTable(model);

            return RedirectToAction("Index");
        }

        private PrimaryTableFitnessService CreatePrimaryTableFitnessTableServices()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new PrimaryTableFitnessService(userId);
            return service;
        }
    }
}