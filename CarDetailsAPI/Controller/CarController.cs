
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

        //[HttpPost]
        //public ActionResult<IEnumerable<Car>> AddCar(Car car)
        //{
        //    CarDataStore carData = new CarDataStore(@"..\CarDetailsDataAccess\fuel.csv");
        //    carData.AddCar(car);
        //    return Ok(carData.cars);
        //}

    }
}
