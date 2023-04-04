
using CarDetailsDataAccess;
using CarDetailsDataAccess.Data;
using CarDetailsModels;
using Microsoft.AspNetCore.Mvc;

namespace CarDetailsAPI.Controller
{
    [ApiController]
    [Route("api/cars")]
    public class CarController : ControllerBase
    {
        private IDataContext _dataContext;
        public CarController(IDataContext dataContext) 
        {
            _dataContext = dataContext;   
        }

        [HttpGet]
        public ActionResult<IEnumerable<Car>> GetCar()
        {
            //CarDataStore carData = new CarDataStore(@"..\CarDetailsDataAccess\fuel.csv");
            //return Ok(carData.cars);
            List<Car> query = _dataContext.CarsDb.ToList();
            return Ok(query);
        }

        [HttpPost]
        public ActionResult<Car> CreateCar([FromBody] Car car)
        {
            if (_dataContext.CarsDb.Any(m => m.Year == car.Year && m.Manufacturer == car.Manufacturer && m.Name == car.Name && m.Displacement == car.Displacement && m.Cylinders == car.Cylinders && m.City == car.City && m.Highway == car.Highway && m.Combined == car.Combined))
            {
                return Ok();
            }
            _dataContext.CarsDb.Add(car);
            _dataContext.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCar(int id)
        {
            var carToDelete = _dataContext.CarsDb.FirstOrDefault(c => c.Id == id);
            if (carToDelete == null)
            {
                return NotFound();
            }

            _dataContext.CarsDb.Remove(carToDelete);
            _dataContext.SaveChanges();
            return NoContent();
        }

    }
}
