using CarDetailsDataAccess;
using CarDetailsDataAccess.Data;
using CarDetailsModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarDetailsAPI.Controller
{

    [ApiController]
    [Route("api")]
    public class JointInfoController : ControllerBase
    {
        private IDataContext _dataContext;
        public JointInfoController(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet("/jointinfo")]
        public ActionResult<IEnumerable<JointInfo>> GetJointInfo(int? page = 1, int? pageSize = 12)
        {   
            var query = _dataContext.CarsDb.Include(x => x.Manufacturer).Skip(pageSize.Value*(page.Value -1)).Take(pageSize.Value).ToList();
            int totalObjects = query.Count;
            int totalPages = (int)Math.Ceiling(totalObjects / (double)pageSize);
            List<JointInfo> jointCarInfo = (List<JointInfo>)(query.Select(car => new JointInfo
            {
                Id = car.Id,
                Name = car.Name,
                Headquarters = car.Manufacturer.Headquarters,
                Manufacturer = car.Manufacturer.Name,
                Year = car.Year,
                Displacement = car.Displacement,
                Cylinders = car.Cylinders,
                City = car.City,
                Highway = car.Highway,
                Combined = car.Combined

            })).OrderBy(m => m.Manufacturer).ThenBy(c => c.Name).ThenByDescending(c => c.Combined).ToList();      


            return Ok(jointCarInfo);
        }
    }
}
