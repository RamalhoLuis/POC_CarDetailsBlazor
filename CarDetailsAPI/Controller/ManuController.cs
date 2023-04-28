using CarDetailsAPI.Queries;
using CarDetailsDataAccess.Data;
using CarDetailsModels;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using CarDetailsAPI.Commands;
using Newtonsoft.Json.Linq;

namespace CarDetailsAPI.Controller
{

    [ApiController]
    [Route("api/manufacturers")]
    public class ManuController : ControllerBase
    {
        private IMediator _mediatr;

        private IDataContext _dataContext;
        public ManuController(IDataContext dataContext, IMediator mediator)
        {
            _mediatr = mediator;
            _dataContext = dataContext;
        }
        [HttpGet]
        public async Task<ActionResult<List<CarDetailsAPI.Models.ManufacturersModel>>> GetManufacturersAsync()
        {
            //ManuDataStore manuData = new ManuDataStore(@"..\CarDetailsDataAccess\manufacturers.csv");
            //return Ok(manuData.manufacturers);
            //List<Manufacturer> query = _dataContext.ManufacturersDb.ToList();
            //return Ok(query);
            var result = await _mediatr.Send(
                new GetManufacturersListQuery()
                );
            return Ok(result);
        }


        [HttpPost]
        public ActionResult<CarDetailsAPI.Models.ManufacturersModel> CreateManufacturer([FromBody] CarDetailsAPI.Models.ManufacturersModel value)
        {
            //if (_dataContext.ManufacturersDb.Any(m => m.Name == manufacturer.Name && m.Headquarters == manufacturer.Headquarters && m.Year == manufacturer.Year))
            //{
            //    return Ok();
            //}
            //_dataContext.ManufacturersDb.Add(manufacturer);
            //_dataContext.SaveChanges();
            //return Ok();
            //return Ok();
            var result = _mediatr.Send(new InsertManufacturerCommand
            {
                Manufacturer = value
            });
            return Ok();
        }

        [HttpGet("{id}")]
        public ActionResult<CarDetailsAPI.Models.ManufacturersModel> GetManufacturerId(int id)
        {
            //var carToSearch = _dataContext.CarsDb.FirstOrDefault(c => c.Id == id);
            //if (carToSearch == null)
            //{
            //    return NotFound();
            //}
            //return Ok(carToSearch);

            var result = _mediatr.Send(
            new GetManufacturerByIdQuery(id)
            );
            if (result.Result is null)
            {
                return Ok(result);
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public ActionResult<CarDetailsAPI.Models.ManufacturersModel> DeleteManufacturer(int id)
        {
            //var manufacturerToDelete = _dataContext.ManufacturersDb.FirstOrDefault(c => c.Id == id);
            //if (manufacturerToDelete == null)
            //{
            //    return NotFound();
            //}

            //_dataContext.ManufacturersDb.Remove(manufacturerToDelete);
            //_dataContext.SaveChanges();
            //return NoContent();

            var result = _mediatr.Send(new DeleteManuByIdCommand { Id = id }
);
            return Ok();
        }

        [HttpPut]
        public ActionResult<CarDetailsAPI.Models.ManufacturersModel> UpdateCar([FromBody] CarDetailsAPI.Models.ManufacturersModel value)
        {
            var result = _mediatr.Send(new UpdateManufacturerByIdCommand
            {
                Manufacturer = value
            }); ;
            return Ok();


        }
    }
}
