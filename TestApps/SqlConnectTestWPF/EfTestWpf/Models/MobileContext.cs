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
        public MobileContext() : base(ConstVarData.ConnectionStringToChips)// base(ConstVarData.ConnectionStringToPhones)// base("DefaultConnection")
        {

        }
        public DbSet<Phone> Phones { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Phone>().ToTable("Chips");
            modelBuilder.Entity<Phone>().Property(p => p.Id).HasColumnName("QR");
            modelBuilder.Entity<Phone>().Property(p => p.Title).HasColumnName("Longer");
            modelBuilder.Entity<Phone>().Property(p => p.Company).HasColumnName("Shoter");
            //modelBuilder.Entity<Phone>().Property(p => p.Id).HasColumnName("QR");

            //  modelBuilder.Entity<Phone>().HasKey(p=>p.)

            base.OnModelCreating(modelBuilder);
        }

        
    }
}
