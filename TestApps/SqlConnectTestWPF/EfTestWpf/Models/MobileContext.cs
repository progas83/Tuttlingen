using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfTestWpf.Models
{
    public class MobileContext : DbContext
    {
        public MobileContext() : base(ConstVarData.ConnectionStringTo)// base("DefaultConnection")
        {

        }
        public DbSet<Phone> Phones { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
