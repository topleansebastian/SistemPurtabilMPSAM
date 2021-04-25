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
