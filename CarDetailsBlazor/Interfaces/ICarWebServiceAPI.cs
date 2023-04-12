using CarDetailsModels;
using Refit;

namespace CarDetailsBlazor.Interfaces
{
    public interface ICarWebServiceAPI
    {
        [Get("/cars")]
        Task<IEnumerable<Car>> GetCars(int? page, int? pageSize);
    }
}
