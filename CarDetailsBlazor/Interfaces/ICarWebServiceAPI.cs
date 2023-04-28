using CarDetailsBlazor.Data;
using CarDetailsModels;
using Refit;

namespace CarDetailsBlazor.Interfaces
{
    public interface ICarWebServiceAPI
    {
        [Get("/api/cars")]
        Task<List<CarDetailsAPI.Models.CarsModel>> GetCars(int? page = 1, int? pageSize = 1);

        [Get("/api/cars/{id}")]
        Task<CarResponse> GetCarById(int id);

        [Delete ("/api/cars/{id}")]
        Task DeleteCar(int id);

        [Post ("/api/cars")]
        Task CreateCar(CarDetailsAPI.Models.CarsModel car);

        [Put("/api/cars")]
        Task UpdateCar(CarDetailsAPI.Models.CarsModel car);



    }
}
