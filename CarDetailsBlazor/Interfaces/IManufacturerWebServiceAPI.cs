using CarDetailsModels;
using Refit;

namespace CarDetailsBlazor.Interfaces
{
    public interface IManufacturerWebServiceAPI
    {
        [Get("/api/manufacturers")]
        Task<List<CarDetailsAPI.Models.ManufacturersModel>> GetManufacturers(int? page = 1, int? pageSize = 1);

        //[Get("/getmanu")]
        //Task<List<CarDetailsAPI.Models.ManufacturerModel>> GetManu(int? page = 1, int? pageSize = 1);
    }
}
