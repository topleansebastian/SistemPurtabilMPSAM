using MPSAM.Database;
using MPSAM.Entities;
using MPSAM.Services;
using MPSAM.Web.ViewModels;
using System;
using System.Collections;
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
        [HttpGet]
        [Route("/Pacient/GetEcgData/{ID}")]
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
                    foreach (var o in val)
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
        [Route("/Pacient/GetPulsData/{ID}")]
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
        [Route("/Pacient/GetTemperaturaData/{ID}")]
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
        [Route("/Pacient/GetUmiditateData/{ID}")]
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
    }
}