using MPSAM.Database;
using MPSAM.Entities;
using MPSAM.Services;
using MPSAM.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Data.Entity;
using static MPSAM.Web.ViewModels.ConsultationViewModels;
using static MPSAM.Web.ViewModels.ActivityViewModels;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections;
using System.Web.Helpers;
using System.Net;
using Rotativa;

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
        public ActionResult Login(DoctorLoginViewModels model )
        {
            using (var context = new DBContext())
            {
                bool isValid = context.Doctors.Any(x => x.Email == model.Email && x.Parola == model.Password);
                //int IDDoctor = context.Doctors.Where(x => x.Email == model.Email && x.Parola == model.Password)
                //                              .Select(x => x.ID).First();
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
            var doctors = DoctorServices.ClassObject.GetAllTheDoctors();
            return PartialView(doctors);
        }
        [HttpPost]
        public ActionResult CreatePacient(NewPacientViewModel model)
        {
            using (var context = new DBContext())
            {
                bool PacientExist = context.Pacients.Any(x => x.CNP == model.CNP);
                if (PacientExist)
                {
                    ViewBag.AlreadyExist = "Pacientul există deja în baza de date. Adăugarea nu s-a realizat.";
                    return RedirectToAction("PacientsTable");
                }
            }

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
            model.Consultations = ConsultationServices.ClassObject.GetConsultationsByPacientID(ID);
            model.Recommendations = DoctorServices.ClassObject.GetRecommendationsByPacientID(ID);
            model.ActivityJournals = DoctorServices.ClassObject.GetActivitiesByPacientID(ID);
            model.Alarms = DoctorServices.ClassObject.GetAlarmsByPacientID(ID);
            model.Monitorings = DoctorServices.ClassObject.GetMonitoringsByPacientID(ID);

            return View(model);
        }
        [HttpGet]
        public ActionResult Pdf(int ID)
        {
            return new ActionAsPdf("GetDataForFisaPacient", new { ID = ID }) { PageSize = Rotativa.Options.Size.A4 };
        }

        public ActionResult GetDataForFisaPacient(int ID)
        {
            FisaPacientPDF model = new FisaPacientPDF();
            model.Pacient = PacientServices.ClassObject.GetPacient(ID);
            model.Consultations = ConsultationServices.ClassObject.GetConsultationsByPacientID(ID);
            
            return View(model);
        }
        [HttpGet]
        [Route("/Doctor/GetEcgData/{ID}")]
        public ActionResult GetEcgData(int ID)
        {
            try
            {
                var context = new DBContext();
                ArrayList xValue = new ArrayList(); //values
                ArrayList yValue = new ArrayList(); //date

                var x = context.Monitorings.Where(m => m.IDPacient == ID).ToList();
                var y = new Dictionary<string, List<Monitoring>>();
                var t = "yyyy-MM-dd";
                foreach (var m in x)
                {
                    if (y.ContainsKey(m.Data.ToString(t)))
                    {
                        y[m.Data.ToString(t)].Add(m);
                    }
                    else
                    {
                        y[m.Data.ToString(t)] = new List<Monitoring>() { m };
                    }
                }

                foreach (var key in y.Keys)
                {
                    var val = y[key];
                    foreach(var o in val)
                    {
                        var sEcg = o.Ecg.ToString();
                        string[] strings = sEcg.Split(';');
                        int[] ints = Array.ConvertAll(strings, int.Parse);
                        if (ints != null && ints.Length != 0)
                        {
                            for (int i = 0; i <= ints.Length - 1; i++)
                            {
                                var sEcgValue = ints[i];
                                xValue.Add(sEcgValue);
                            }
                        }
                    }
                    
                    yValue.Add(DateTime.Parse(key));

                }
                return Json(new { xData = xValue, yData = yValue }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return null;
            }

        }
        [HttpGet]
        [Route("/Doctor/GetPulsData/{ID}")]
        public ActionResult GetPulsData(int ID)
        {
            try
            {
                var context = new DBContext();
                ArrayList xValue = new ArrayList();
                ArrayList yValue = new ArrayList();

                var x = context.Monitorings.Where(m => m.IDPacient == ID).ToList();
                var y = new Dictionary<string, List<Monitoring>>();
                var t = "yyyy-MM-dd";
                foreach (var m in x)
                {
                    if (y.ContainsKey(m.Data.ToString(t)))
                    {
                        y[m.Data.ToString(t)].Add(m);
                    }
                    else
                    {
                        y[m.Data.ToString(t)] = new List<Monitoring>() { m };
                    }
                }

                foreach (var key in y.Keys)
                {
                    var val = y[key];
                    var z = (int)(val.Average(a => a.Puls));
                    xValue.Add(z);
                    yValue.Add(DateTime.Parse(key));

                }
                return Json(new { xData = xValue, yData = yValue }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return null;
            }
           
        }
        [HttpGet]
        [Route("/Doctor/GetTemperaturaData/{ID}")]
        public ActionResult GetTemperaturaData(int ID)
        {
            try
            {
                var context = new DBContext();
                ArrayList xValue = new ArrayList();
                ArrayList yValue = new ArrayList();

                var x = context.Monitorings.Where(m => m.IDPacient == ID).ToList();
                var y = new Dictionary<string, List<Monitoring>>();
                var t = "yyyy-MM-dd";
                foreach (var m in x)
                {
                    if (y.ContainsKey(m.Data.ToString(t)))
                    {
                        y[m.Data.ToString(t)].Add(m);
                    }
                    else
                    {
                        y[m.Data.ToString(t)] = new List<Monitoring>() { m };
                    }
                }

                foreach (var key in y.Keys)
                {
                    var val = y[key];
                    var z = (int)(val.Average(a => a.Temperatura));
                    xValue.Add(z);
                    yValue.Add(DateTime.Parse(key));

                }
                return Json(new { xData = xValue, yData = yValue }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return null;
            }


        }
        [HttpGet]
        [Route("/Doctor/GetUmiditateData/{ID}")]
        public ActionResult GetUmiditateData(int ID)
        {
            try
            {
                var context = new DBContext();
                ArrayList xValue = new ArrayList();
                ArrayList yValue = new ArrayList();

                var x = context.Monitorings.Where(m => m.IDPacient == ID).ToList();
                var y = new Dictionary<string, List<Monitoring>>();
                var t = "yyyy-MM-dd";
                foreach (var m in x)
                {
                    if (y.ContainsKey(m.Data.ToString(t)))
                    {
                        y[m.Data.ToString(t)].Add(m);
                    }
                    else
                    {
                        y[m.Data.ToString(t)] = new List<Monitoring>() { m };
                    }
                }

                foreach (var key in y.Keys)
                {
                    var val = y[key];
                    var z = (int)(val.Average(a => a.Umiditate));
                    xValue.Add(z);
                    yValue.Add(DateTime.Parse(key));

                }
                return Json(new { xData = xValue, yData = yValue }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return null;
            }


        }
        public ActionResult ChartBar(int IDPacient)
        {
            var context = new DBContext();
            ArrayList xValue = new ArrayList();
            ArrayList yValue = new ArrayList();
            ArrayList xzValue = new ArrayList();
            ArrayList yzValue = new ArrayList();
            var results = context.Monitorings.Where(m => m.IDPacient == IDPacient);
            //results.ToList().ForEach(rs => yValue.Add(rs.Data));

            //results.ToList().ForEach(rs => xValue.Add(rs.Puls));

            var ByDayGrouped = results.GroupBy(O => new { O.Data.Year, O.Data.Month, O.Data.Day }).ToList();

            var x = context.Monitorings.Where(m => m.IDPacient == IDPacient).ToList();
            var y = new Dictionary<string, List<Monitoring>>();
            var t = "yyyy-MM-dd";
            foreach(var m in x)
            {
                if (y.ContainsKey(m.Data.ToString(t)))
                {
                    y[m.Data.ToString(t)].Add(m);
                }
                else
                {
                    y[m.Data.ToString(t)] = new List<Monitoring>() { m };
                }
            }

            //var monit = context.Monitorings
            //        .GroupBy(s => new { s.Data.ToString("dd-MM-yyyy") })
            //        .Select(g => new
            //        {
            //            DataMonit = g.Key.Data,
            //            PulsMonit = g.Average(x => x.Puls),
            //        });

            //monit.ToList().ForEach(rs => xzValue.Add(rs.PulsMonit));
            //monit.ToList().ForEach(rs => yzValue.Add(rs.DataMonit));
            foreach (var key in y.Keys)
            {
                var val = y[key];
                var z = val.Average(a=>a.Puls);
                xValue.Add(z);
                yValue.Add(DateTime.Parse(key));
                
            }

            new Chart(width: 500, height: 500, theme: ChartTheme.Blue)
                .AddSeries("Default", chartType: "Column", xValue: yValue, yValues: xValue)
                .Write("bmp");

            return null;
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
        [HttpGet]
        public ActionResult CreateConsultation(int id = 0)
        {
            SelectedPacientsAndDoctors model = new SelectedPacientsAndDoctors();

            model.Pacients = PacientServices.ClassObject.GetAllThePacients();
            model.Doctors = DoctorServices.ClassObject.GetAllTheDoctors();

            return PartialView(model);
        }
        [HttpPost]
        public ActionResult CreateConsultation(NewConsultationViewModel model)
        {

            var newConsultation = new Consultation();
            newConsultation.IDPacient = PacientServices.ClassObject.GetPacientIDByCNP(model.CNP);
            newConsultation.IDDoctor = model.IDDoctor;
            newConsultation.Data = model.Data;
            newConsultation.Simptome = model.Simptome;
            newConsultation.Diagnostic = model.Diagnostic;
            newConsultation.Tratament = model.Tratament;
            newConsultation.Pacient = PacientServices.ClassObject.GetPacientByCNP(model.CNP);
            ConsultationServices.ClassObject.SaveConsultation(newConsultation);

            return RedirectToAction("ConsultationsTable");
        }
        [HttpGet]
        public ActionResult EditConsultation(int ID)
        {
            EditConsultationViewModel model = new EditConsultationViewModel();

            var consultation = ConsultationServices.ClassObject.GetConsultation(ID);
            model.Pacients = PacientServices.ClassObject.GetAllThePacients();
            model.Doctors = DoctorServices.ClassObject.GetAllTheDoctors();

            model.ID = consultation.ID;
            model.CNP = PacientServices.ClassObject.GetPacientCNPByID(ID);
            model.Data = consultation.Data;
            model.Simptome = consultation.Simptome;
            model.Diagnostic = consultation.Diagnostic;
            model.Tratament = consultation.Tratament;
            //model.PacientID = consultation.PacientID;
            return PartialView(model);
        }
        [HttpPost]
        public ActionResult EditConsultation(EditConsultationViewModel model)
        {
            var existingConsultation = ConsultationServices.ClassObject.GetConsultation(model.ID);
            existingConsultation.IDPacient = PacientServices.ClassObject.GetPacientIDByCNP(model.CNP);
            existingConsultation.IDDoctor = model.IDDoctor;
            existingConsultation.Data = model.Data;
            existingConsultation.Simptome = model.Simptome;
            existingConsultation.Diagnostic = model.Diagnostic;
            existingConsultation.Tratament = model.Tratament;
            existingConsultation.Pacient = PacientServices.ClassObject.GetPacientByCNP(model.CNP);
           
            ConsultationServices.ClassObject.UpdateConsultation(existingConsultation);

            return RedirectToAction("ConsultationsTable");
        }
        [HttpPost]
        public ActionResult DeleteConsultation(int ID)
        {
            ConsultationServices.ClassObject.DeleteConsultation(ID);
            return RedirectToAction("ConsultationsTable");
        }
        [HttpGet]
        public ActionResult InfoConsultation(int ID, int PacientID)
        {
            InfoConsultationViewModel model = new InfoConsultationViewModel();

            model.Pacient = PacientServices.ClassObject.GetPacient(PacientID);
            model.Consultation = ConsultationServices.ClassObject.GetConsultation(ID);
            model.Doctor = DoctorServices.ClassObject.GetDoctor(model.Consultation.IDDoctor);

            return PartialView(model);
        }
        [HttpGet]
        public ActionResult CreateRecommendation(int ID)
        {
            NewRecommendation model = new NewRecommendation();

            model.Pacient = PacientServices.ClassObject.GetPacient(ID);
            model.Doctors = DoctorServices.ClassObject.GetAllTheDoctors();

            return PartialView(model);
        }
        [HttpPost]
        public ActionResult CreateRecommendation(NewRecommendation model)
        {

            var newRecommendation = new Recommendation();
            newRecommendation.IDPacient = model.IDPacient;
            //newRecommendation.IDDoctor = model.IDDoctor;
            newRecommendation.Data = model.Data;
            newRecommendation.Text = model.Text;
            DoctorServices.ClassObject.SaveRecommendation(newRecommendation);

            return RedirectToAction("PacientsTable");
        }
        [HttpPost]
        public ActionResult DeleteRecommendation(int ID, int IDPacient)
        {
            DoctorServices.ClassObject.DeleteRecommendation(ID);
            //return RedirectToAction("InfoPacient", new { id = IDPacient });
            string redirectUrl = Url.Action("InfoPacient", new { id = IDPacient });
            return Json( new { redirectUrl });
        }
        [HttpGet]
        public ActionResult CreateActivity(int ID)
        {
            NewActivity model = new NewActivity();
            model.Pacient = PacientServices.ClassObject.GetPacient(ID);
            return PartialView(model);
        }
        [HttpPost]
        public ActionResult CreateActivity(NewActivity model)
        {

            var newActivity = new ActivityJournal();
            newActivity.IDPacient = model.IDPacient;
            newActivity.Data = model.Data;
            newActivity.Activitate = model.Activitate;
            DoctorServices.ClassObject.SaveActivity(newActivity);

            return RedirectToAction("PacientsTable");
        }
        [HttpPost]
        public ActionResult DeleteActivity(int ID, int IDPacient)
        {
            DoctorServices.ClassObject.DeleteActivity(ID);

            string redirectUrl = Url.Action("InfoPacient", new { id = IDPacient });
            return Json(new { redirectUrl });
        }
        [HttpGet]
        public ActionResult CreateAlarm(int ID)
        {
            NewAlarm model = new NewAlarm();
            model.Pacient = PacientServices.ClassObject.GetPacient(ID);
            return PartialView(model);
        }
        [HttpPost]
        public ActionResult CreateAlarm(NewAlarm model)
        {

            var newAlarm = new Alarm();
            newAlarm.IDPacient = model.IDPacient;
            newAlarm.ValoareVizata = model.ValoareVizata;
            newAlarm.LimitaInferioara= model.LimitaInferioara;
            newAlarm.LimitaSuperioara = model.LimitaSuperioara;
            newAlarm.Mesaj = model.Mesaj;
            DoctorServices.ClassObject.SaveAlarm(newAlarm);

            return RedirectToAction("PacientsTable");
        }
        [HttpPost]
        public ActionResult DeleteAlarm(int ID, int IDPacient)
        {
            DoctorServices.ClassObject.DeleteAlarm(ID);

            string redirectUrl = Url.Action("InfoPacient", new { id = IDPacient });
            return Json(new { redirectUrl });
        }
    }
}