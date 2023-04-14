using CarDetailsModels;

namespace CarDetailsDataAccess.DataAccess
{
    public interface ICarDataAccess
    {
        List<Car> GetCars();
        List<Car> InsertCar(int year, string manufacturer, string name, double displacement, int cylinders, int city, int highway, int combined);
    }
}