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
    public class PacientServices
    {
        //get all the pacients
        public List<Pacient> GetAllThePacients()
        {
            using (var context = new DBContext())
            {
                return context.Pacients.ToList();
            }
        }
        //number of total pacients
        public int GetPacientsCounter(string search)
        {
            using (var context = new DBContext())
            {
                if (string.IsNullOrEmpty(search) == false)
                {
                    return context.Pacients
                        .Where(p => p.CNP != null && p.CNP == search || (p.Nume != null && p.Nume.ToLower().Contains(search.ToLower())) || (p.Prenume != null && p.Prenume.ToLower().Contains(search.ToLower())))
                        .Count();
                }
                else
                {
                    return context.Pacients.Count();
                }
            }
        }
        public string GetPacientCNPByID(int ID)
        {
            using (var context = new DBContext())
            {
                return context.Pacients.Where(p => p.ID == ID).Select(x => x.CNP).Single();
            }
        }
        //get one pacient searched by ID
        public Pacient GetPacient(int ID)
        {
            using (var context = new DBContext())
            {
                return context.Pacients.Where(p => p.ID == ID).FirstOrDefault();
            }
        }
        public int GetPacientIDByCNP(string CNP)
        {
            using (var context = new DBContext())
            {
                return context.Pacients.Where(p => p.CNP != null && p.CNP == CNP).Select(x => x.ID).Single();
            }
        }
        public Pacient GetPacientByCNP(string CNP)
        {
            using (var context = new DBContext())
            {
                return context.Pacients.Where(p => p.CNP != null && p.CNP == CNP).FirstOrDefault();
            }
        }
        //save in database, Pacients tabel
        public void SavePacient(Pacient pacient)
        {
            try
            {
                using (var context = new DBContext())
                {
                    context.Pacients.Add(pacient);
                    context.SaveChanges();
                }
            }
            catch (DbEntityValidationException e)
            { }
        }
        //update pacient in database
        public void UpdatePacient(Pacient pacient)
        {
            try
            {
                using (var context = new DBContext())
                {
                    context.Entry(pacient).State = System.Data.Entity.EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (DbEntityValidationException e)
            { }
        }
        //delete a pacient from database
        public void DeletePacient(int ID)
        {
            using (var context = new DBContext())
            {

                var pacient = context.Pacients.Find(ID);
                context.Pacients.Remove(pacient);
                context.SaveChanges();
            }
        }
        //get all pacients
        public List<Pacient> GetPacients(string search, int pageNumber)
        {
            int pageSize = 10;

            using (var context = new DBContext())
            {
                if (string.IsNullOrEmpty(search) == false)
                {
                    return context.Pacients
                        .Where(p => p.CNP != null && p.CNP == search || (p.Nume != null && p.Nume.ToLower().Contains(search.ToLower())) || (p.Prenume != null && p.Prenume.ToLower().Contains(search.ToLower())))
                        .OrderBy(x => x.Nume)
                        .Skip((pageNumber - 1) * pageSize)
                        .Take(pageSize)
                        //.Include(x => x.Consultatii)
                        .ToList();

                }
                else
                {
                    return context.Pacients
                        .OrderBy(x => x.Nume)
                        .Skip((pageNumber - 1) * pageSize)
                        .Take(pageSize)
                        //.Include(x => x.Consultatii)
                        .ToList();
                }
            }
        }
        //here is applied Singleton Design Pattern
        public static PacientServices ClassObject
        {
            get
            {
                if (privateInMemoryObject == null) privateInMemoryObject = new PacientServices();
                return privateInMemoryObject;
            }
        }
        private static PacientServices privateInMemoryObject { get; set; }
        private PacientServices()
        {
        }
    }
}
