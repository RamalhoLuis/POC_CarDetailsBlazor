using CarDetailsModels;

namespace CarDetailsDataAccess
{
    public class CarDataStore
    {
        public List<Car> cars;
        public static string carsFilePath;
        

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
    }
}