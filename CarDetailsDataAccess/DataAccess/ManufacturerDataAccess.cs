using CarDetailsDataAccess.Data;
using CarDetailsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDetailsDataAccess.DataAccess
{
    public class ManufacturerDataAccess : IManufacturerDataAccess
    {
        private IDataContext dbContext;

        private List<Manufacturer> manufacturers = new List<Manufacturer>();

        public ManufacturerDataAccess(IDataContext dbContext)
        {
            this.dbContext = dbContext;

        }
        public List<Manufacturer> GetManufacturers()
        {
            return dbContext.ManufacturersDb.ToList();
        }

        public List<Manufacturer> InsertManufacturer(string name, string headquarters, int year)
        {
            Manufacturer newManufacturer = new Manufacturer
            {
                Name = name,
                Headquarters = headquarters,
                Year = year,

            };

            dbContext.ManufacturersDb.Add(newManufacturer);
            dbContext.SaveChanges();

            return dbContext.ManufacturersDb.ToList();
        }
    }
}

