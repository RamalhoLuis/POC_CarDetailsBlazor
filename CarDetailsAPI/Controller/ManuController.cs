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
            var result = await _mediatr.Send(
                new GetManufacturersListQuery()
                );
            return Ok(result);
        }


        [HttpPost]
        public ActionResult<CarDetailsAPI.Models.ManufacturersModel> CreateManufacturer([FromBody] CarDetailsAPI.Models.ManufacturersModel value)
        {
            var result = _mediatr.Send(new InsertManufacturerCommand
            {
                Manufacturer = value
            });
            return Ok();
        }

        [HttpGet("{id}")]
        public ActionResult<CarDetailsAPI.Models.ManufacturersModel> GetManufacturerId(int id)
        {
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
            var result = _mediatr.Send(
                new DeleteManuByIdCommand { Id = id }
);
            return Ok();
        }

        [HttpPut]
        public ActionResult UpdateManufacturer([FromBody] CarDetailsAPI.Models.ManufacturersModel value)
        {
            var result = _mediatr.Send(new UpdateManufacturerByIdCommand
            {
                Manufacturer = value
            }); ;
            return Ok();
        }
    }
}
