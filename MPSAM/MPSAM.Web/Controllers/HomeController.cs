using MPSAM.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MPSAM.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Validate(string email, string password)
        {
            DBContext context = new DBContext();
            var medic = context.Medics.FirstOrDefault(m=> m.Email == email && m.Parola == password);

            if (medic == null)
            {
                return Json(new { status = false, message = "Username sau parola invalida!" });
            }
            else
            {
                return Json(new { status = true, message = "Autentificare realizata cu succes!" });
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}