
using Azure.Core;
using CarDetailsAPI.Commands;
using CarDetailsAPI.Queries;
using CarDetailsDataAccess.Data;
using CarDetailsModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarDetailsAPI.Controller
{
    [ApiController]
    [Route("api/cars")]
    public class CarController : ControllerBase
    {
        private IMediator _mediatr;

        private IDataContext _dataContext;
        public CarController(IDataContext dataContext, IMediator mediator) 
        {
            _mediatr = mediator;
            _dataContext = dataContext;   
        }


        [HttpGet]
        public ActionResult<List<Car>> GetCars()
        {
            //CarDataStore carData = new CarDataStore(@"..\CarDetailsDataAccess\fuel.csv");
            //return Ok(carData.cars);
            //List<Car> query = _dataContext.CarsDb.ToList();
            var result = _mediatr.Send(
                new GetCarsListQuery()
                );
            return Ok(result.Result);
        }

        [HttpPost]
        public async Task<ActionResult<Car>> CreateCar([FromBody] Car value)
        {
            //if (_dataContext.CarsDb.Any(m => m.Year == car.Year && m.Manufacturer == car.Manufacturer && m.Name == car.Name && m.Displacement == car.Displacement && m.Cylinders == car.Cylinders && m.City == car.City && m.Highway == car.Highway && m.Combined == car.Combined))
            //{
            //    return Ok();
            //}
            //_dataContext.CarsDb.Add(car);
            //_dataContext.SaveChanges();
            //return Ok();
            var result = await _mediatr.Send(new InsertCarCommand
            {
                Car = value
            });
            return Ok(result);
        }

        [HttpGet("{id}")]
        public ActionResult<Car> GetCarId(int id)
        {
            //var carToSearch = _dataContext.CarsDb.FirstOrDefault(c => c.Id == id);
            //if (carToSearch == null)
            //{
            //    return NotFound();
            //}
            //return Ok(carToSearch);

            var result = _mediatr.Send(
            new GetCarByIdQuery(id)
            );
            return Ok(result.Result);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCar(int id)
        {
            //var carToDelete = _dataContext.CarsDb.FirstOrDefault(c => c.Id == id);
            //if (carToDelete == null)
            //{
            //    return NotFound();
            //}
            //_dataContext.CarsDb.Remove(carToDelete);
            //_dataContext.SaveChanges();
            //return NoContent();
                        var result = _mediatr.Send(new GetCarByIdQuery(id)
            );
            return Ok(result.Result);
        }

    }
}
