using CarDetailsModels;

namespace CarDetailsDataAccess
{
    public class CarDataStore
    {
        public List<Car> cars;
        public static string carsFilePath;
        private const string header = "Year,Manufacturer,Name,Displacement,Cylinders,City,Highway,Combined";



        public CarDataStore(string? path = null)
        {
            carsFilePath = path;
            cars = GetCarsFromFile();            
        }

        private static List<Car> GetCarsFromFile(string? path = null)
        {
            if (path == null) { path = carsFilePath; }

            var query = File.ReadAllLines(path)
                    .Skip(1)
                    .Where(l => l.Length > 1)
                    .ToCar();

            return query.ToList();
        }

        public void AddCar(Car car)
        {
            cars.Add(car);
            File.WriteAllLines(carsFilePath, new[] { header }
        .Concat(cars.Select(c => $"{c.Year},{c.Manufacturer},{c.Name},{c.Displacement},{c.Cylinders},{c.City},{c.Highway},{c.Combined}")));
        }
    }
}