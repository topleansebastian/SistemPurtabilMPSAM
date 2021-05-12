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
using static MPSAM.Web.ViewModels.ConsultationViewModels;

namespace MPSAM.Web.Controllers
{
    public class DoctorController : Controller
    {
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(DoctorLoginViewModels model)
        {
            using (var context = new DBContext())
            {
                bool isValid = context.Doctors.Any(x => x.Email == model.Email && x.Parola == model.Password);
                //var IDDoctor = context.Doctors.Where(x => x.Email == model.Email && x.Parola == model.Password)
                //                              .Select(x => x.ID).Single();
                if (isValid)
                {
                    FormsAuthentication.SetAuthCookie(model.Email, false);
                    return RedirectToAction("Dashboard", "Doctor");
                }
                ModelState.AddModelError("", "Emailul sau parola sunt invalide");
                //ViewBag.IDDoctor = IDDoctor;
                return View();
            }
        }
        public ActionResult Dashboard()
        {
            return View();
        }
        [HttpGet]
        public ActionResult DisplayPacients()
        {
            var pacients = PacientServices.ClassObject.GetAllThePacients();
            return View(pacients);
        }
        [HttpGet]
        public ActionResult PacientsTable(string search, int? pageNumber)
        {
            PacientSearchViewModel model = new PacientSearchViewModel();

            model.WordToBeSearched = search;

            pageNumber = pageNumber.HasValue ? pageNumber.Value > 0 ? pageNumber.Value : 1 : 1;

            var totalPacients = PacientServices.ClassObject.GetPacientsCounter(search);

            model.Pacients = PacientServices.ClassObject.GetPacients(search, pageNumber.Value);

            if (model.Pacients != null)
            {
                model.Pagination = new Pagination(totalPacients, pageNumber, 10);

                return PartialView("PacientsTable", model);
            }
            else
            {
                return HttpNotFound();
            }
        }
        [HttpGet]
        public ActionResult CreatePacient()
        {
            var doctors = DoctorServices.ClassObject.GetAllTheDoctors();
            return PartialView(doctors);
        }
        [HttpPost]
        public ActionResult CreatePacient(NewPacientViewModel model)
        {

            var newPacient = new Pacient();
            newPacient.IDMedic = model.IDMedic; ;
            newPacient.Nume = model.Nume;
            newPacient.Prenume = model.Prenume;
            newPacient.CNP = model.CNP;
            newPacient.Sex = model.Sex;
            newPacient.DataNasterii = model.DataNasterii;
            newPacient.Varsta = model.Varsta;
            newPacient.Adresa = model.Adresa;
            newPacient.Localitate = model.Localitate;
            newPacient.Judet = model.Judet;
            newPacient.Email = model.Email;
            newPacient.Telefon = model.Telefon;
            newPacient.Ocupatie = model.Ocupatie;
            newPacient.LocDeMunca = model.LocDeMunca;
            newPacient.GrupSanguin = model.GrupSanguin;
            newPacient.RH = model.RH;
            newPacient.Alergii = model.Alergii;
            newPacient.Inaltime = model.Inaltime;
            newPacient.Greutate = model.Greutate;
            newPacient.TegumenteMucoase = model.TegumenteMucoase;
            newPacient.TesutSubcutanat = model.TesutSubcutanat;
            newPacient.Ganglioni = model.Ganglioni;
            newPacient.AntecedenteFiziologice = model.AntecedenteFiziologice;
            newPacient.AntecedentePatologice = model.AntecedentePatologice;
            newPacient.ConditiiMediu = model.ConditiiMediu;
            newPacient.Internari = model.Internari;
            newPacient.MotiveInternari = model.MotiveInternari;
            newPacient.Zgomot = model.Zgomot;
            newPacient.Suflu = model.Suflu;
            newPacient.Frecventa = model.Frecventa;
            newPacient.Aritmii = model.Aritmii;
            newPacient.Parola = model.Parola;

            PacientServices.ClassObject.SavePacient(newPacient);

            return RedirectToAction("PacientsTable");
        }
        [HttpGet]
        public ActionResult EditPacient(int ID)
        {
            EditPacientViewModel model = new EditPacientViewModel();

            var pacient = PacientServices.ClassObject.GetPacient(ID);

            model.ID = pacient.ID;
            model.IDMedic = pacient.IDMedic; ;
            model.Nume = pacient.Nume;
            model.Prenume = pacient.Prenume;
            model.CNP = pacient.CNP;
            model.Sex = pacient.Sex;
            model.DataNasterii = pacient.DataNasterii;
            model.Varsta = pacient.Varsta;
            model.Adresa = pacient.Adresa;
            model.Localitate = pacient.Localitate;
            model.Judet = pacient.Judet;
            model.Email = pacient.Email;
            model.Telefon = pacient.Telefon;
            model.Ocupatie = pacient.Ocupatie;
            model.LocDeMunca = pacient.LocDeMunca;
            model.GrupSanguin = pacient.GrupSanguin;
            model.RH = pacient.RH;
            model.Alergii = pacient.Alergii;
            model.Inaltime = pacient.Inaltime;
            model.Greutate = pacient.Greutate;
            model.TegumenteMucoase = pacient.TegumenteMucoase;
            model.TesutSubcutanat = pacient.TesutSubcutanat;
            model.Ganglioni = pacient.Ganglioni;
            model.AntecedenteFiziologice = pacient.AntecedenteFiziologice;
            model.AntecedentePatologice = pacient.AntecedentePatologice;
            model.ConditiiMediu = pacient.ConditiiMediu;
            model.Internari = pacient.Internari;
            model.MotiveInternari = pacient.MotiveInternari;
            model.Zgomot = pacient.Zgomot;
            model.Suflu = pacient.Suflu;
            model.Frecventa = pacient.Frecventa;
            model.Aritmii = pacient.Aritmii;
            model.Parola = pacient.Parola;
            model.Doctors = DoctorServices.ClassObject.GetAllTheDoctors();
            return PartialView(model);
        }
        [HttpPost]
        public ActionResult EditPacient(EditPacientViewModel model)
        {
            var existingPacient = PacientServices.ClassObject.GetPacient(model.ID);

            existingPacient.IDMedic = model.IDMedic; ;
            existingPacient.Nume = model.Nume;
            existingPacient.Prenume = model.Prenume;
            existingPacient.CNP = model.CNP;
            existingPacient.Sex = model.Sex;
            existingPacient.DataNasterii = model.DataNasterii;
            existingPacient.Varsta = model.Varsta;
            existingPacient.Adresa = model.Adresa;
            existingPacient.Localitate = model.Localitate;
            existingPacient.Judet = model.Judet;
            existingPacient.Email = model.Email;
            existingPacient.Telefon = model.Telefon;
            existingPacient.Ocupatie = model.Ocupatie;
            existingPacient.LocDeMunca = model.LocDeMunca;
            existingPacient.GrupSanguin = model.GrupSanguin;
            existingPacient.RH = model.RH;
            existingPacient.Alergii = model.Alergii;
            existingPacient.Inaltime = model.Inaltime;
            existingPacient.Greutate = model.Greutate;
            existingPacient.TegumenteMucoase = model.TegumenteMucoase;
            existingPacient.TesutSubcutanat = model.TesutSubcutanat;
            existingPacient.Ganglioni = model.Ganglioni;
            existingPacient.AntecedenteFiziologice = model.AntecedenteFiziologice;
            existingPacient.AntecedentePatologice = model.AntecedentePatologice;
            existingPacient.ConditiiMediu = model.ConditiiMediu;
            existingPacient.Internari = model.Internari;
            existingPacient.MotiveInternari = model.MotiveInternari;
            existingPacient.Zgomot = model.Zgomot;
            existingPacient.Suflu = model.Suflu;
            existingPacient.Frecventa = model.Frecventa;
            existingPacient.Aritmii = model.Aritmii;
            existingPacient.Parola = model.Parola;

            PacientServices.ClassObject.UpdatePacient(existingPacient);

            return RedirectToAction("PacientsTable");
        }
        [HttpPost]
        public ActionResult DeletePacient(int ID)
        {
            PacientServices.ClassObject.DeletePacient(ID);
            return RedirectToAction("PacientsTable");
        }
        [HttpGet]
        public ActionResult InfoPacient(int ID)
        {
            InfoPacientViewModel model = new InfoPacientViewModel();
            model.Pacient = PacientServices.ClassObject.GetPacient(ID);
            model.Doctor = DoctorServices.ClassObject.GetDoctor(model.Pacient.IDMedic);
            //model.Consultations = ConsultationsService.ClassObject.GetConsultationsByPacientID(ID);
            return View(model);
        }
        [HttpGet]
        public ActionResult DisplayConsultations()
        {
            var consultations = ConsultationServices.ClassObject.GetAllTheConsultations();
            return View(consultations);
        }
        public ActionResult ConsultationsTable(string search, int? pageNumber)
        {
            ConsultationSearchViewModel model = new ConsultationSearchViewModel();

            model.WordToBeSearched = search;

            pageNumber = pageNumber.HasValue ? pageNumber.Value > 0 ? pageNumber.Value : 1 : 1;

            var totalConsultations = ConsultationServices.ClassObject.GetConsultationsCounter(search);

            model.Consultations = ConsultationServices.ClassObject.GetConsultations(search, pageNumber.Value);

            if (model.Consultations != null)
            {
                model.Pagination = new Pagination(totalConsultations, pageNumber, 10);

                return PartialView("ConsultationsTable", model);
            }
            else
            {
                return HttpNotFound();
            }
        }
    }
}