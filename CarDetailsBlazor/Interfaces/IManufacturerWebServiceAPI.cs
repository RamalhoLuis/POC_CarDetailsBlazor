using CarDetailsModels;
using Refit;

namespace CarDetailsBlazor.Interfaces
{
    public interface IManufacturerWebServiceAPI
    {
        [Get("/manufacturers")]
        Task<IEnumerable<Manufacturer>> GetManufacturers();
    }
}
