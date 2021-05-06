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
                if (isValid)
                {
                    FormsAuthentication.SetAuthCookie(model.Email, false);
                    return RedirectToAction("Dashboard", "Doctor");
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
            return PartialView();
        }
        [HttpPost]
        public ActionResult CreatePacient(NewPacientViewModel model)
        {

            //var newPacient = new Pacient();
            //newPacient.Nume = model.Nume;
            //newPacient.Prenume = model.Prenume;
            //newPacient.CNP = model.CNP;
            //newPacient.Sex = model.Sex;
            //newPacient.Ocupatie = model.Ocupatie;
            //newPacient.DataNasterii = model.DataNasterii;
            //newPacient.Varsta = model.Varsta;
            //newPacient.Adresa = model.Adresa;
            //newPacient.Oras = model.Oras;
            //newPacient.Judet = model.Judet;
            //newPacient.Tara = model.Tara;
            //newPacient.CodPostal = model.CodPostal;
            //newPacient.Email = model.Email;
            //newPacient.Telefon = model.Telefon;
            //if (model.Vicii != null)
            //{
            //    StringBuilder sb = new StringBuilder();
            //    sb.Append(string.Join(",", model.Vicii));
            //    newPacient.Vicii = sb.ToString();
            //}

            //newPacient.Alergii = model.Alergii;
            //newPacient.Medic = model.Medic;
            //newPacient.AntecedenteHeredoColaterale = model.AntecedenteHeredoColaterale;
            //newPacient.SangerareGingii = model.SangerareGingii;
            //newPacient.TratamentAnticoagulante = model.TratamentAnticoagulante;
            //newPacient.TratamentBifosfati = model.TratamentBifosfati;
            //if (model.BoliCronice != null)
            //{
            //    StringBuilder sb = new StringBuilder();
            //    sb.Append(string.Join(",", model.BoliCronice));
            //    newPacient.BoliCronice = sb.ToString();
            //}
            //newPacient.InterventiiChirurgicale = model.InterventiiChirurgicale;
            //newPacient.TransfuziiSange = model.TransfuziiSange;
            //newPacient.TratamenteStomatologiceAnterioare = model.TratamenteStomatologiceAnterioare;
            //newPacient.UltimulControl = model.UltimulControl;
            //newPacient.UltimaRadiografieDentara = model.UltimaRadiografieDentara;
            //newPacient.IncidenteComplicatiiUtilizareAnestezice = model.IncidenteComplicatiiUtilizareAnestezice;
            //newPacient.Bruxism = model.Bruxism;
            //newPacient.ResponsabilCreare = "Dr.Selesi Andrei";
            //newPacient.DataCreare = DateTime.Now;
            //PacientsService.ClassObject.SavePacient(newPacient);

            return RedirectToAction("PacientsTable");
        }
    }
}