using MPSAM.Database;
using MPSAM.Entities;
using System;
using System.Collections.Generic;
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
