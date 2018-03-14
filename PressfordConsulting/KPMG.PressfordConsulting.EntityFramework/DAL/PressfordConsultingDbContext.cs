using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using KPMG.PressfordConsulting.EntityFramework.Models;

namespace KPMG.PressfordConsulting.EntityFramework.DAL
{
    public class PressfordConsultingDbContext : DbContext
    {
        public PressfordConsultingDbContext() : base("PressfordConsultingDbContext")
        {
        }

        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
