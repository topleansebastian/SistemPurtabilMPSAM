using MPSAM.Database;
using MPSAM.Entities;
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
        [HttpGet]
        public ActionResult DisplayDoctors()
        {
            var doctors = DoctorServices.ClassObject.GetAllTheDoctors();
            return View(doctors);
        }
        [HttpGet]
        public ActionResult DoctorsTable(string search, int? pageNumber)
        {
            DoctorSearchViewModel model = new DoctorSearchViewModel();

            model.WordToBeSearched = search;

            pageNumber = pageNumber.HasValue ? pageNumber.Value > 0 ? pageNumber.Value : 1 : 1;

            var totalDoctors = DoctorServices.ClassObject.GetDoctorsCounter(search);

            model.Doctors = DoctorServices.ClassObject.GetDoctors(search, pageNumber.Value);

            if (model.Doctors != null)
            {
                model.Pagination = new Pagination(totalDoctors, pageNumber, 10);

                return PartialView("DoctorsTable", model);
            }
            else
            {
                return HttpNotFound();
            }
        }
        [HttpGet]
        public ActionResult CreateDoctor()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult CreateDoctor(NewDoctorViewModel model)
        {

            var newDoctor = new Doctor();
            newDoctor.Nume = model.Nume;
            newDoctor.Prenume = model.Prenume;
            newDoctor.Email = model.Email;
            newDoctor.Telefon = model.Telefon;
            newDoctor.CodParafa = model.CodParafa;
            newDoctor.Cabinet = model.Cabinet;
            newDoctor.Parola = model.Parola;
            
            DoctorServices.ClassObject.SaveDoctor(newDoctor);

            return RedirectToAction("DoctorsTable");
        }
        [HttpGet]
        public ActionResult EditDoctor(int ID)
        {
            EditDoctorViewModel model = new EditDoctorViewModel();

            var doctor = DoctorServices.ClassObject.GetDoctor(ID);
            model.ID = doctor.ID;
            model.Nume = doctor.Nume;
            model.Prenume = doctor.Prenume;
            model.Email = doctor.Email;
            model.Telefon = doctor.Telefon;
            model.CodParafa = doctor.CodParafa;
            model.Cabinet = doctor.Cabinet;
            model.Parola = doctor.Parola;
            return PartialView(model);
        }
        [HttpPost]
        public ActionResult EditDoctor(EditDoctorViewModel model)
        {
            var existingDoctor = DoctorServices.ClassObject.GetDoctor(model.ID);
            existingDoctor.Nume = model.Nume;
            existingDoctor.Prenume = model.Prenume;
            existingDoctor.Email = model.Email;
            existingDoctor.Telefon = model.Telefon;
            existingDoctor.CodParafa = model.CodParafa;
            existingDoctor.Cabinet = model.Cabinet;
            existingDoctor.Parola = model.Parola;

            DoctorServices.ClassObject.UpdateDoctor(existingDoctor);

            return RedirectToAction("DoctorsTable");
        }
        [HttpPost]
        public ActionResult DeleteDoctor(int ID)
        {
            DoctorServices.ClassObject.DeleteDoctor(ID);
            return RedirectToAction("DoctorsTable");
        }
        [HttpGet]
        public ActionResult InfoDoctor(int ID)
        {
            InfoDoctorViewModel model = new InfoDoctorViewModel();
            model.Doctor = DoctorServices.ClassObject.GetDoctor(ID);
            return View(model);
        }
    }
}