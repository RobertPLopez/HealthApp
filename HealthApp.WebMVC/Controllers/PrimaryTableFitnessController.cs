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
        // GET: PrimaryTableFitness
        public ActionResult Index()
        {
            var model = new PrimaryTableFitnessListItem[0];
            return View(model);
        }
    }
}