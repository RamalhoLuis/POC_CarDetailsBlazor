
using CarDetailsModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDetailsDataAccess.Data
{
    public class AppDbContext : DbContext, IDataContext
    {
        public DbSet<Car> CarsDb { get; set; }
        public DbSet<Manufacturer> ManufacturersDb { get; set; }
        public DbSet<JointInfo> JointInfoDb { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Data Source=WIG-FERNANDO\SQLEXPRESS;Initial Catalog=CarAPPDatabase; Trusted_Connection=True; TrustServerCertificate=True;");
        }
    }
}
