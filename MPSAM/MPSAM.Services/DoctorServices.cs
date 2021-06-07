using MPSAM.Database;
using MPSAM.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPSAM.Services
{

    public class DoctorServices
    {
        //get all the doctors
        public List<Doctor> GetAllTheDoctors()
        {
            using (var context = new DBContext())
            {
                return context.Doctors.ToList();
            }
        }
        //number of total doctors
        public int GetDoctorsCounter(string search)
        {
            using (var context = new DBContext())
            {
                if (string.IsNullOrEmpty(search) == false)
                {
                    return context.Doctors
                        .Where(p => p.CodParafa != null && p.CodParafa == search || (p.Nume != null && p.Nume.ToLower().Contains(search.ToLower())) || (p.Prenume != null && p.Prenume.ToLower().Contains(search.ToLower())))
                        .Count();
                }
                else
                {
                    return context.Doctors.Count();
                }
            }
        }
        //get all doctors
        public List<Doctor> GetDoctors(string search, int pageNumber)
        {
            int pageSize = 10;

            using (var context = new DBContext())
            {
                if (string.IsNullOrEmpty(search) == false)
                {
                    return context.Doctors
                        .Where(p => p.CodParafa != null && p.CodParafa == search || (p.Nume != null && p.Nume.ToLower().Contains(search.ToLower())) || (p.Prenume != null && p.Prenume.ToLower().Contains(search.ToLower())))
                        .OrderBy(x => x.Nume)
                        .Skip((pageNumber - 1) * pageSize)
                        .Take(pageSize)
                        .Include(x => x.Pacienti)
                        .ToList();

                }
                else
                {
                    return context.Doctors
                        .OrderBy(x => x.Nume)
                        .Skip((pageNumber - 1) * pageSize)
                        .Take(pageSize)
                        .Include(x => x.Pacienti)
                        .ToList();
                }
            }
        }
        //save in database, ActivityJournals tabel
        public void SaveActivity(ActivityJournal activity)
        {
            try
            {
                using (var context = new DBContext())
                {
                    //context.Entry(recommendation.Pacient).State = System.Data.Entity.EntityState.Unchanged;
                    context.ActivityJournals.Add(activity);
                    context.SaveChanges();
                }
            }
            catch (DbEntityValidationException e)
            { }
        }
        //save in database, Alarms tabel
        public void SaveAlarm(Alarm alarm)
        {
            try
            {
                using (var context = new DBContext())
                {
                    //context.Entry(recommendation.Pacient).State = System.Data.Entity.EntityState.Unchanged;
                    context.Alarms.Add(alarm);
                    context.SaveChanges();
                }
            }
            catch (DbEntityValidationException e)
            { }
        }
        //save in database, Recommendations tabel
        public void SaveRecommendation(Recommendation recommendation)
        {
            try
            {
                using (var context = new DBContext())
                {
                    //context.Entry(recommendation.Pacient).State = System.Data.Entity.EntityState.Unchanged;
                    context.Recommendations.Add(recommendation);
                    context.SaveChanges();
                }
            }
            catch (DbEntityValidationException e)
            { }
        }
        //save in database, new doctor
        public void SaveDoctor(Doctor doctor)
        {
            try
            {
                using (var context = new DBContext())
                {
                    context.Doctors.Add(doctor);
                    context.SaveChanges();
                }
            }
            catch (DbEntityValidationException e)
            { }
        }
        //update doctor in database
        public void UpdateDoctor(Doctor doctor)
        {
            try
            {
                using (var context = new DBContext())
                {
                    context.Entry(doctor).State = System.Data.Entity.EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (DbEntityValidationException e)
            { }
        }
        //delete a doctor from database
        public void DeleteDoctor(int ID)
        {
            using (var context = new DBContext())
            {

                var doctor = context.Doctors.Find(ID);
                context.Doctors.Remove(doctor);
                context.SaveChanges();
            }
        }
        public List<Recommendation> GetRecommendationsByPacientID(int ID)
        {
            using (var context = new DBContext())
            {
                return context.Recommendations.Where(p => p.IDPacient == ID).OrderByDescending(p => p.ID).ToList();
            }
        }

        public List<ActivityJournal> GetActivitiesByPacientID(int ID)
        {
            using (var context = new DBContext())
            {
                return context.ActivityJournals.Where(p => p.IDPacient == ID).OrderByDescending(p => p.ID).ToList();
            }
        }
        public List<Alarm> GetAlarmsByPacientID(int ID)
        {
            using (var context = new DBContext())
            {
                return context.Alarms.Where(p => p.IDPacient == ID).OrderByDescending(p => p.ID).ToList();
            }
        }
        public List<Monitoring> GetMonitoringsByPacientID(int ID)
        {
            using (var context = new DBContext())
            {
                return context.Monitorings.Where(p => p.IDPacient == ID).OrderByDescending(p => p.ID).ToList();
            }
        }
        public void DeleteRecommendation(int ID)
        {
            using (var context = new DBContext())
            {

                var recomm = context.Recommendations.Find(ID);
                context.Recommendations.Remove(recomm);
                context.SaveChanges();
            }
        }
        public void DeleteActivity(int ID)
        {
            using (var context = new DBContext())
            {

                var activity = context.ActivityJournals.Find(ID);
                context.ActivityJournals.Remove(activity);
                context.SaveChanges();
            }
        }
        public void DeleteAlarm(int ID)
        {
            using (var context = new DBContext())
            {

                var alarm = context.Alarms.Find(ID);
                context.Alarms.Remove(alarm);
                context.SaveChanges();
            }
        }
        //get one doctor searched by ID
        public Doctor GetDoctor(int ID)
        {
            using (var context = new DBContext())
            {
                return context.Doctors.Where(p => p.ID == ID).FirstOrDefault();
            }
        }
        //here is applied Singleton Design Pattern
        public static DoctorServices ClassObject
        {
            get
            {
                if (privateInMemoryObject == null) privateInMemoryObject = new DoctorServices();
                return privateInMemoryObject;
            }
        }
        private static DoctorServices privateInMemoryObject { get; set; }
        private DoctorServices()
        {
        }
    }
}
