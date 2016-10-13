using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebApplication.DTO;
using WebApplication.Models;



namespace WebApplication.Controllers
{
    public class AccountNouController : Controller
    {

        //
        // GET: /AccountControllerNou/
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }
        //[Authorize]
        public ActionResult AdminPage()
        {
            return View();
        }
        //[Authorize]
        public ActionResult Login()
        {
            //ViewBag.Url = returnUrl;
            return View();
        }
       
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model)
        {
            User U=new User();
            if(ModelState.IsValid)
            {
                var user = U.Logare(model.UserName, model.Password);
                if(user!=false)
                {
                    FormsAuthentication.SetAuthCookie(model.UserName, false);
                    return RedirectToAction("Index", "AccountNou");
                }

                    if (U.LogAdmin(model.UserName, model.Password)!=false)
                    {
                        return RedirectToAction("AdminPage", "AccountNou");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Invalid username or password.");
                    }
                
                
            }
            return View(model);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Create( RegisterModel model)
        {
            User U=new User();
            
            if (ModelState.IsValid)
            {
                bool user =U.Introducere(model.UserName, model.FirstName, model.LastName, model.Email, model.NrTelefon, model.Password);
                if(user!=false)
                {
                    return RedirectToAction("Index", "AccountNou");
                }
            }
            return View(model);
        }
        
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "AccountNou");
        }
        

    }
	
}