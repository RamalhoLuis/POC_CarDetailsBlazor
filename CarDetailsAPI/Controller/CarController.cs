using CarDetailsAPI.Commands;
using CarDetailsAPI.Queries;
using CarDetailsDataAccess.Data;
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
        public async Task<ActionResult<List<CarDetailsAPI.Models.CarsModel>>> GetCarsAsync()
        {
            var result = await _mediatr.Send(
                new GetCarsListQuery()
                );
            return Ok(result);
        }

        [HttpPost]
        public ActionResult<CarDetailsAPI.Models.CarsModel> CreateCar([FromBody] CarDetailsAPI.Models.CarsModel value)
        {
            var result = _mediatr.Send(new InsertCarCommand
            {
                Car = value
            });
            return Ok();
        }

        [HttpGet("{id}")]
        public ActionResult<CarDetailsAPI.Models.CarsModel> GetCarId(int id)
        {
            var result = _mediatr.Send(
            new GetCarByIdQuery(id)
            );
            if (result.Result is null)
            {
                return Ok(result);
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public ActionResult<CarDetailsAPI.Models.CarsModel> DeleteCar(int id)
        {
            var result = _mediatr.Send(
            new DeleteCarByIdCommand { Id = id }
            );
            return Ok();
        }

        [HttpPut]
        public ActionResult UpdateCar([FromBody] CarDetailsAPI.Models.CarsModel value)
        {
            var result = _mediatr.Send(new UpdateCarByIdCommand
            {
                Car = value
            });
            return Ok();
        }

    }
}
