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
    public class AdministratorController : Controller
    {
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(AdministratorLoginViewModels model)
        {
            using (var context = new DBContext())
            {
                bool isValid = context.Administrators.Any(x => x.Utilizator == model.Utilizator && x.Parola == model.Password);
                if (isValid)
                {
                    FormsAuthentication.SetAuthCookie(model.Utilizator, false);
                    return RedirectToAction("Dashboard", "Administrator");
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