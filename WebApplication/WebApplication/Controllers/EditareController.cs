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
            model = U.Viz();
            return View(model);
        }
        public ActionResult Edit(string UserName)
        {
            Editare model = new Editare();
            User U = new User();
            model = U.Editare(UserName);
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

            return View(model);
        }
    }
}