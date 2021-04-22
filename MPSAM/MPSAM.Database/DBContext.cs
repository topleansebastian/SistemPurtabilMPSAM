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
        public DBContext() : base("SistemPurtabilDB")
        {
        }

        public DbSet<Medic> Medics { get; set; }
        public DbSet<Pacient> Pacients { get; set; }
        public DbSet<Administrator> Administrators { get; set; }
    }
}
