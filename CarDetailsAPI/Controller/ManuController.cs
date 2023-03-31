using CarDetailsBlazor.Pages;
using CarDetailsDataAccess;
using CarDetailsDataAccess.Data;
using CarDetailsModels;
using Microsoft.AspNetCore.Mvc;

namespace CarDetailsAPI.Controller
{

    [ApiController]
    [Route("api/manufacturers")]
    public class ManuController : ControllerBase
    {
        private IDataContext _dataContext;
        public ManuController(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Manufacturer>> GetManufacturer()
        {
            //ManuDataStore manuData = new ManuDataStore(@"..\CarDetailsDataAccess\manufacturers.csv");
            //return Ok(manuData.manufacturers);
            var query = _dataContext.ManufacturersDb;
            return Ok(query);
        }


        //[HttpPost]
        //public ActionResult<IEnumerable<Manufacturer>> AddManufacturer(Manufacturer manufacturer)
        //{
        //    ManuDataStore manuData = new ManuDataStore(@"..\CarDetailsDataAccess\manufacturers.csv");
        //    manuData.AddManufacturer(manufacturer);
        //    return Ok(manuData.manufacturers);
        //}
    }
}
