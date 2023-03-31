using CarDetailsBlazor.Pages;
using CarDetailsDataAccess;
using CarDetailsDataAccess.Data;
using CarDetailsModels;
using Microsoft.AspNetCore.Mvc;

namespace CarDetailsAPI.Controller
{

    [ApiController]
    [Route("api/jointinfo")]
    public class JointInfoController : ControllerBase
    {
        private IDataContext _dataContext;
        public JointInfoController(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet]
        public ActionResult<IEnumerable<JointInfo>> GetJointInfo()
        {

            List<JointInfo> jointCarInfo = (List<JointInfo>)(from car in _dataContext.CarsDb
                                                             join manufacturer in _dataContext.ManufacturersDb
                                                             on car.Manufacturer equals manufacturer.Name
                                                             select new JointInfo
                                                             {
                                                                 Id = car.Id,
                                                                 Name = car.Name,
                                                                 Headquarters = manufacturer.Headquarters,
                                                                 Year = car.Year,
                                                                 Manufacturer = car.Manufacturer,
                                                                 Displacement = car.Displacement,
                                                                 Cylinders = car.Cylinders,
                                                                 City = car.City,
                                                                 Highway = car.Highway,
                                                                 Combined = car.Combined

                                                             }).OrderBy(m => m.Manufacturer).ThenBy(c => c.Name).ThenByDescending(c => c.Combined).ToList();

            return Ok(jointCarInfo);

        }


    }
}
