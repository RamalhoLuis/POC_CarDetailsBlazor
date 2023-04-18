using CarDetailsModels;
using Refit;

namespace CarDetailsBlazor.Interfaces
{
    public interface IManufacturerWebServiceAPI
    {
        [Get("/manufacturers")]
        Task<List<Manufacturer>> GetManufacturers(int? page = 1, int? pageSize = 1);
    }
}
