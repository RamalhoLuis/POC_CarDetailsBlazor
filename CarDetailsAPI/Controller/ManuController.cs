using CarDetailsBlazor.Pages;
using CarDetailsDataAccess;
using CarDetailsModels;
using Microsoft.AspNetCore.Mvc;

namespace CarDetailsAPI.Controller
{

    [ApiController]
    [Route("api/manufacturers")]
    public class ManuController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<Manufacturer>> GetManufacturer()
        {
            ManuDataStore manuData = new ManuDataStore(@"..\CarDetailsDataAccess\manufacturers.csv");
            return Ok(manuData.manufacturers);
        }
    }
}
