using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication10.Models;

namespace WebApplication10.Controllers
{
    public class ImpozitController : Controller
    {
        Database1 db = new Database1();

        public ActionResult Home()
        {
            return View();
        }


        [HttpGet]
        public ActionResult IntroducereImpozit()
        {
            return View();
        }
    }
}