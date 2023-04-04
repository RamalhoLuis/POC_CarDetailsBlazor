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
            List<Manufacturer> query = _dataContext.ManufacturersDb.ToList();
            return Ok(query);
        }


        [HttpPost]
        public ActionResult<Manufacturer> CreateManufacturer([FromBody] Manufacturer manufacturer)
        {
            _dataContext.ManufacturersDb.Add(manufacturer);
            _dataContext.SaveChanges();
            return Ok();
            //return CreatedAtAction(nameof(GetManufacturer), new { id = manufacturer.Id }, manufacturer);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteManufacturer(int id)
        {
            var manufacturerToDelete = _dataContext.ManufacturersDb.FirstOrDefault(c => c.Id == id);
            if (manufacturerToDelete == null)
            {
                return NotFound();
            }

            _dataContext.ManufacturersDb.Remove(manufacturerToDelete);
            _dataContext.SaveChanges();
            return NoContent();
        }
    }
}
