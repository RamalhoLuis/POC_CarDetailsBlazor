using CarDetailsBlazor.Pages;
using CarDetailsDataAccess;
using CarDetailsModels;
using Microsoft.AspNetCore.Mvc;

namespace CarDetailsAPI.Controller
{

    [ApiController]
    [Route("api/jointinfo")]
    public class JointInfoController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<JointInfo>> GetJointInfo()
        {
            CarDataStore carData = new CarDataStore(@"..\CarDetailsDataAccess\fuel.csv");
            ManuDataStore manuData = new ManuDataStore(@"..\CarDetailsDataAccess\manufacturers.csv");
            List<JointInfo> jointCarInfo = (List<JointInfo>)(from car in carData.cars
                                                             join manufacturer in manuData.manufacturers
                                                             on car.Manufacturer equals manufacturer.Name
                                                             select new JointInfo
                                                             {
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
