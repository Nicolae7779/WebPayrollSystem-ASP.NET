using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using WebApplication10.Models;

namespace WebApplication10.Controllers
{
    public class HomeController : Controller
    {
        Database1 db = new Database1();

        public ActionResult Home()
        {
            return View();
        }


        [HttpGet]
        public ActionResult IntroducereDate()
        {
            return View();
        }


        [HttpPost]

        public ActionResult IntroducereDate(Angajati ut)
        {

            if (ModelState.IsValid)
            {
                string imagePath = Server.MapPath("~/Image/");
            if (!Directory.Exists(imagePath))
            {
                Directory.CreateDirectory(imagePath);
            }

                if (ut.ImageFile != null && ut.ImageFile.ContentLength > 0)
                {
                    using (var binaryReader = new BinaryReader(ut.ImageFile.InputStream))
                    {
                        ut.Poza = binaryReader.ReadBytes(ut.ImageFile.ContentLength);
                    }
                }

               
                db.Angajati.Add(ut);
            db.SaveChanges();

            return RedirectToAction("ActualizareDate");
        }

            return View(ut);
        }
       
        [HttpGet]
        public ActionResult Impozit()
        {
          
            ImpozitTable model = db.ImpozitTable.FirstOrDefault(); 
            if (model == null)
            {
                model = new ImpozitTable(); 
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult Impozit(ImpozitTable model)
        {
            if (ModelState.IsValid)
            {
                
                using (var context = new AppDbContext())
                {
     
                    var existingModel = context.Impozite.FirstOrDefault();
                    if (existingModel != null)
                    {
                        existingModel.CAS = model.CAS;
                        existingModel.CASS = model.CASS;
                        existingModel.IMPOZIT = model.IMPOZIT;
                    }
                    else
                    {
                        
                        context.Impozite.Add(model);
                    }

                    context.SaveChanges(); 
                }

 
                return RedirectToAction("Impozit");
            }

            
            return View("Impozit", model);
        }





        [HttpGet]
        public ActionResult ActualizareDate(string search)
        {

          
            IEnumerable<Angajati> model;

            if (!string.IsNullOrEmpty(search))
            {
                decimal searchDecimal;
                int searchId;

                if (int.TryParse(search, out searchId))
                {
                
                    model = db.Angajati.Where(a => a.Id == searchId);
                }
                else if (decimal.TryParse(search, out searchDecimal))
                {
                   
                    model = db.Angajati.Where(a => a.Salariu_de_baza == searchDecimal ||
                                                   a.Spor == searchDecimal ||
                                                   a.Premii_brute == searchDecimal ||
                                                   a.Rețineri == searchDecimal);
                                           
                }
                else
                {
                    
                    model = db.Angajati.Where(a => a.Nume.Contains(search) ||
                                                   a.Prenume.Contains(search) ||
                                                   a.Funcție.Contains(search));
                }
            }
            else
            {
           
                model = db.Angajati.ToList();
            }

            ViewBag.Search = search; 

            return View(model);
        }

        [HttpGet]
        public ActionResult DetaliiDate(string search)
        {
        
            IEnumerable<Angajati> model;

            if (!string.IsNullOrEmpty(search))
            {
                decimal searchDecimal;
                int searchId;

                if (int.TryParse(search, out searchId))
                {
                   
                    model = db.Angajati.Where(a => a.Id == searchId);
                }
                else if (decimal.TryParse(search, out searchDecimal))
                {
                   
                    model = db.Angajati.Where(a => a.Salariu_de_baza == searchDecimal ||
                                                   a.Spor == searchDecimal ||
                                                   a.Premii_brute == searchDecimal ||
                                                   a.Rețineri == searchDecimal);
                                               
                }
                else
                {
                   
                    model = db.Angajati.Where(a => a.Nume.Contains(search) ||
                                                   a.Prenume.Contains(search) ||
                                                   a.Funcție.Contains(search));
                }
            }
            else
            {
               
                model = db.Angajati.ToList();
            }

            ViewBag.Search = search; 

            return View(model);
        }

        [HttpGet]
        public ActionResult ȘtergereDate(string search)
        {
       
            IEnumerable<Angajati> model;

            if (!string.IsNullOrEmpty(search))
            {
                decimal searchDecimal;
                int searchId;

                if (int.TryParse(search, out searchId))
                {
                    model = db.Angajati.Where(a => a.Id == searchId);
                }
                else if (decimal.TryParse(search, out searchDecimal))
                {
                    
                    model = db.Angajati.Where(a => a.Salariu_de_baza == searchDecimal ||
                                                   a.Spor == searchDecimal ||
                                                   a.Premii_brute == searchDecimal ||
                                                   a.Rețineri == searchDecimal);
                                               
                }
                else
                {
           
                    model = db.Angajati.Where(a => a.Nume.Contains(search) ||
                                                   a.Prenume.Contains(search) ||
                                                   a.Funcție.Contains(search));
                }
            }
            else
            {
                
                model = db.Angajati.ToList();
            }

            ViewBag.Search = search; 

            return View(model);
        }

        [HttpGet]
        public ActionResult Editează(int id)
        {
            var obj = db.Angajati.Find(id);
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editează([Bind(Include = "Id, Nume, Prenume, Funcție, Salariu_de_baza, Spor, Premii_brute, Rețineri")] Angajati ut)
        {
            if (ModelState.IsValid)
            {
              
                var existingEmployee = db.Angajati.Find(ut.Id);

                if (existingEmployee != null)
                {
                   
                    ut.Poza = existingEmployee.Poza;

               
                    existingEmployee.Nume = ut.Nume;
                    existingEmployee.Prenume = ut.Prenume;
                    existingEmployee.Funcție = ut.Funcție;
                    existingEmployee.Salariu_de_baza = ut.Salariu_de_baza;
                    existingEmployee.Spor = ut.Spor;
                    existingEmployee.Premii_brute = ut.Premii_brute;
                    existingEmployee.Rețineri = ut.Rețineri;

                   
                    db.SaveChanges();

                    return RedirectToAction("ActualizareDate");
                }
            }

            return View(ut);
        }







        [HttpGet]
        public ActionResult ConfirmareȘtergere(int id)
        {
            var obj = db.Angajati.Find(id);

            if (obj != null)
            {
                
                if (obj.Spor.HasValue && obj.Premii_brute.HasValue && obj.Rețineri.HasValue)
                {
                    decimal Salariu_Brut_Complet = (decimal)(obj.Salariu_de_baza + obj.Premii_brute + (obj.Salariu_de_baza * obj.Spor.Value) / 100);
                    decimal Salariu_cu_CASS_si_CAS = Salariu_Brut_Complet - Salariu_Brut_Complet * 0.35m;
                    decimal Salariu_cu_impozit = Salariu_cu_CASS_si_CAS - Salariu_cu_CASS_si_CAS * 0.1m;
                    obj.Salariu_net = Math.Round(Salariu_cu_impozit - obj.Rețineri.Value, 2);
                }
                else
                {
                    
                    obj.Salariu_net = 0; 
                }

                return View(obj);
            }
            else
            {
                return HttpNotFound();
            }
        }
        [HttpPost]
        public ActionResult ConfirmareȘtergere(Angajati ut, int id)
        {
            db.Entry(ut).State = System.Data.Entity.EntityState.Deleted;
            db.SaveChanges();

            var obj = db.Angajati.Find(id);

            if (obj != null)
            {
                if (obj.Spor.HasValue && obj.Premii_brute.HasValue && obj.Rețineri.HasValue)
                {
                    decimal Salariu_Brut_Complet = (decimal)(obj.Salariu_de_baza + obj.Premii_brute + (obj.Salariu_de_baza * obj.Spor.Value) / 100);
                    decimal Salariu_cu_CASS_si_CAS = Salariu_Brut_Complet - Salariu_Brut_Complet * 0.35m;
                    decimal Salariu_cu_impozit = Salariu_cu_CASS_si_CAS - Salariu_cu_CASS_si_CAS * 0.1m;
                    obj.Salariu_net = Math.Round(Salariu_cu_impozit - obj.Rețineri.Value, 2);
                }
                else
                {
                    
                    obj.Salariu_net = 0;
                }

                return View(obj);
            }
            else
            {

                return RedirectToAction("ȘtergereDate");
            }


        }


        public ActionResult Detalii(int id)
        {
            var obj = db.Angajati.Find(id);

            if (obj != null)
            {
                if (obj.Spor.HasValue && obj.Premii_brute.HasValue && obj.Rețineri.HasValue)
                {
                    decimal Salariu_Brut_Complet = (decimal)(obj.Salariu_de_baza + obj.Premii_brute + (obj.Salariu_de_baza * obj.Spor.Value) / 100);
                    decimal Salariu_cu_CASS_si_CAS = Salariu_Brut_Complet - Salariu_Brut_Complet * 0.35m;
                    decimal Salariu_cu_impozit = Salariu_cu_CASS_si_CAS - Salariu_cu_CASS_si_CAS * 0.1m;
                    obj.Salariu_net = Math.Round(Salariu_cu_impozit - obj.Rețineri.Value, 2);
                }
                else
                {
                   
                    obj.Salariu_net = 0;
                }

                return View(obj);
            }
            else
            {
                return HttpNotFound();
            }
        }

        public ActionResult Rapoarte()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Procente()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }


    }
}
