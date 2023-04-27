using CarDetailsBlazor.Data;
using CarDetailsModels;
using Refit;

namespace CarDetailsBlazor.Interfaces
{
    public interface IManufacturerWebServiceAPI
    {
        [Get("/api/manufacturers")]
        Task<List<CarDetailsAPI.Models.ManufacturersModel>> GetManufacturers(int? page = 1, int? pageSize = 1);

        [Get("/api/manufacturers/{id}")]
        Task<ManuResponse> GetManufacturerById(int id);
    }
}
