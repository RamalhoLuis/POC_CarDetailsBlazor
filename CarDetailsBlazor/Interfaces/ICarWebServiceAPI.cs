using CarDetailsModels;
using Refit;

namespace CarDetailsBlazor.Interfaces
{
    public interface ICarWebServiceAPI
    {
        [Get("/api/cars")]
        Task<List<CarDetailsAPI.Models.CarsModel>> GetCars(int? page = 1, int? pageSize = 1);

        [Get("/api/car/{id}")]
        Task<Car> GetCarById(int id);

    }
}
