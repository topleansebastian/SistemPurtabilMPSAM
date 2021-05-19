using MPSAM.Database;
using MPSAM.Services;
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
                    int IDPacient = context.Pacients.Where(p => p.Email == model.Email && p.Parola == model.Password).Select(p => p.ID).First();
                    return RedirectToAction("Dashboard", "Pacient", new { id = IDPacient });
                }
                ModelState.AddModelError("", "Emailul sau parola sunt invalide");

                return View();
            }
        }
        [HttpGet]
        public ActionResult Dashboard(int ID)
        {
            InfoPacientViewModel model = new InfoPacientViewModel();
            model.Pacient = PacientServices.ClassObject.GetPacient(ID);
            model.Doctor = DoctorServices.ClassObject.GetDoctor(model.Pacient.IDMedic);
            model.Consultations = ConsultationServices.ClassObject.GetConsultationsByPacientID(ID);
            model.Recommendations = DoctorServices.ClassObject.GetRecommendationsByPacientID(ID);
            model.ActivityJournals = DoctorServices.ClassObject.GetActivitiesByPacientID(ID);
            return View(model);
        }
    }
}