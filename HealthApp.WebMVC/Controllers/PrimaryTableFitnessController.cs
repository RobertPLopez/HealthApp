using HealthApp.Models.PrimaryTableFitness;
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
            var model = new PrimaryTableFitnessListItem[0];
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

            }
        }
    }
}