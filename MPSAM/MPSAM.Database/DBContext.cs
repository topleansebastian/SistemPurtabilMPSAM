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
        public DBContext() : base("SistemPurtabilDatabase")
        {
        }

        public DbSet<Medic> Medici { get; set; }
        public DbSet<Pacient> Pacienti { get; set; }
    }
}
