using CarDetailsBlazor.Pages;
using CarDetailsDataAccess;
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
            return Ok(carData.cars) ;
        }
    }
}
