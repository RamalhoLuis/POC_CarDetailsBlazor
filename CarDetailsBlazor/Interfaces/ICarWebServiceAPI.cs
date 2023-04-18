using CarDetailsModels;
using Refit;

namespace CarDetailsBlazor.Interfaces
{
    public interface ICarWebServiceAPI
    {
        [Get("/cars")]
        Task<List<Car>> GetCars(int? page=1 , int? pageSize = 1);

        [Get("/car/{id}")]
        Task<Car> GetCarById(int id);

    }
}
