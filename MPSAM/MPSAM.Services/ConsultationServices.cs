using MPSAM.Database;
using MPSAM.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPSAM.Services
{
    public class ConsultationServices
    {
        //delete consultation from database
        public void DeleteConsultation(int ID)
        {
            using (var context = new DBContext())
            {

                var consultation = context.Consultations.Find(ID);
                context.Consultations.Remove(consultation);
                context.SaveChanges();
            }
        }
        public List<Consultation> GetConsultationsByPacientID(int ID)
        {
            using (var context = new DBContext())
            {
                return context.Consultations.Where(p => p.IDPacient == ID).OrderByDescending(p => p.ID).ToList();
            }
        }
        //update consultation in database
        public void UpdateConsultation(Consultation consultation)
        {
            try
            {
                using (var context = new DBContext())
                {
                    context.Entry(consultation).State = System.Data.Entity.EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (DbEntityValidationException e)
            { }
        }
        //get one consultation searched by ID
        public Consultation GetConsultation(int ID)
        {
            using (var context = new DBContext())
            {
                return context.Consultations.Where(p => p.ID == ID).FirstOrDefault();
            }
        }
        //get all the consultations
        public List<Consultation> GetAllTheConsultations()
        {
            using (var context = new DBContext())
            {
                return context.Consultations.ToList();
            }
        }
        //number of total consultations
        public int GetConsultationsCounter(string search)
        {
            using (var context = new DBContext())
            {
                if (string.IsNullOrEmpty(search) == false)
                {
                    int searchInt = Convert.ToInt32(search);

                    return context.Consultations
                        .Where(p => p.ID == searchInt)
                        .Count();
                }
                else
                {
                    return context.Consultations.Count();
                }
            }
        }
        //save in database, Consultations tabel
        public void SaveConsultation(Consultation consultation)
        {
            try
            {
                using (var context = new DBContext())
                {
                    context.Entry(consultation.Pacient).State = System.Data.Entity.EntityState.Unchanged;
                    context.Consultations.Add(consultation);
                    context.SaveChanges();
                }
            }
            catch (DbEntityValidationException e)
            { }
        }
        //get all the consultations
        public List<Consultation> GetConsultations(string search, int pageNumber)
        {
            int pageSize = 10;

            using (var context = new DBContext())
            {
                if (string.IsNullOrEmpty(search) == false)
                {
                    int searchInt = Convert.ToInt32(search);

                    return context.Consultations
                        .Where(p => p.ID == searchInt)
                        .OrderBy(x => x.ID)
                        .Skip((pageNumber - 1) * pageSize)
                        .Take(pageSize)
                        .ToList();

                }
                else
                {
                    return context.Consultations
                        .OrderBy(x => x.ID)
                        .Skip((pageNumber - 1) * pageSize)
                        .Take(pageSize)
                        .ToList();
                }
            }
        }
        //here is applied Singleton Design Pattern
        public static ConsultationServices ClassObject
        {
            get
            {
                if (privateInMemoryObject == null) privateInMemoryObject = new ConsultationServices();
                return privateInMemoryObject;
            }
        }
        private static ConsultationServices privateInMemoryObject { get; set; }
        private ConsultationServices()
        {
        }
    }
}
