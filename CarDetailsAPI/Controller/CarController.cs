
using CarDetailsDataAccess;
using CarDetailsModels;
using Microsoft.AspNetCore.Mvc;

namespace CarDetailsAPI.Controller
{
    [ApiController]
    [Route("api/cars")]
    public class CarController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<Car>> GetCar()
        {
            CarDataStore carData = new CarDataStore(@"..\CarDetailsDataAccess\fuel.csv");
            return Ok(carData.cars);
        }

        [HttpPost]
        public ActionResult<IEnumerable<Car>> AddCar(Car car)
        {
            CarDataStore carData = new CarDataStore(@"..\CarDetailsDataAccess\fuel.csv");
            carData.AddCar(car);
            return Ok(carData.cars);
        }

    }
}
