using CarDetailsDataAccess;
using CarDetailsDataAccess.Data;
using CarDetailsModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDetailsDataAccess.DataAccess
{
    public class CarDataAccess : ICarDataAccess
    {
        private IDataContext dbContext;

        private List<Car> cars = new List<Car>();

        public CarDataAccess(IDataContext dbContext)
        {
            this.dbContext = dbContext;

        }
        public List<Car> GetCars()
        {
            return dbContext.CarsDb.ToList();
        }
        public List<Car> InsertCar(int year, string manufacturer, string name, double displacement, int cylinders, int city, int highway, int combined)
        {
            Car newCar = new Car
            {
                Year = year,
                Manufacturer = manufacturer,
                Name = name,
                Displacement = displacement,
                Cylinders = cylinders,
                City = city,
                Highway = highway,
                Combined = combined
            };

            dbContext.CarsDb.Add(newCar);
            dbContext.SaveChanges();

            return dbContext.CarsDb.ToList();
        }
    }
}
