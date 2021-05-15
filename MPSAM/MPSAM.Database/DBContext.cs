using MPSAM.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPSAM.Database
{
    public class DBContext : DbContext
    {
        public DBContext() : base("DefaultConnection")
        {
        }

        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Pacient> Pacients { get; set; }
        public DbSet<Consultation> Consultations { get; set; }
        public DbSet<Administrator> Administrators { get; set; }
        public DbSet<Recommendation> Recommendations { get; set; }
        public DbSet<Alarm> Alarms { get; set; }
        public DbSet<Monitoring> Monitorings{ get; set; }
        public DbSet<ActivityJournal> ActivityJournals { get; set; }
    }
}
