using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication.DTO;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    
    public class EditareController : Controller
    {
        //
        // GET: /Editare/
        
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult Vizualizare()
        {
            List<Vizualizare> model = new List<Vizualizare>();
            User U = new User();
            U.uniune();
            model = U.Viz();
            return View(model);
        }
        public ActionResult Edit(int UserId)
        {
            Editare model=new Editare();
            User U = new User();
            U.uniune();
            model = U.Editare(UserId);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }
        public ActionResult Details(int UserId)
        {
            Editare model = new Editare();
            User U = new User();
            U.uniune();
            model = U.Detalii(UserId);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Editare model)
        {
            User U=new User();
            U.uniune();
            if (ModelState.IsValid)
            {
                bool user = U.Editare(Convert.ToInt32(model.UserId), model.UserName, model.FirstName, model.LastName, model.Email, model.NrTelefon, model.Password);
                if (user != false)
                {
                    return RedirectToAction("Vizualizare", "Editare");
                }
            }
            return Vizualizare();
        }
        public ActionResult Delete(int UserId)
        {
            
            User U = new User();
            U.uniune();
            var user = U.Delete(UserId);
            if (user !=false)
            {
                return RedirectToAction("Vizualizare", "Editare");
            }
            return View();
        }
	}
}