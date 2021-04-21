using MPSAM.Database;
using MPSAM.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MPSAM.Web.Controllers
{
    public class PacientController : Controller
    {
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(PacientLoginViewModels model)
        {
            using (var context = new DBContext())
            {
                bool isValid = context.Pacients.Any(x => x.Email == model.Email && x.Parola == model.Password);
                if (isValid)
                {
                    FormsAuthentication.SetAuthCookie(model.Email, false);
                    return RedirectToAction("Dashboard", "Pacient");
                }
                ModelState.AddModelError("", "Emailul sau parola sunt invalide");

                return View();
            }
        }
        public ActionResult Dashboard()
        {
            return View();
        }
    }
}