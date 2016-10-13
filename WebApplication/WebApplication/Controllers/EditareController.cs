using System;
using System.Collections.Generic;
using System.Linq;
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
            return View(model);
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Vizualizare(Vizualizare model)
        {
            User U=new User();
            List<string> list = new List<string>();
            if (ModelState.IsValid)
            {
                var user = U.Viz(list);
                if (user != null)
                {
                   
                }
                else
                {
                    ModelState.AddModelError("", "I can not access the database.");
                }
            }
            return View();
        }

	}
}