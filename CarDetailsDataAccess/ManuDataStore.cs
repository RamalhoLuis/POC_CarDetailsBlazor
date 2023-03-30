using CarDetailsModels;
using System.Reflection.PortableExecutable;

namespace CarDetailsDataAccess
{
    public class ManuDataStore
    {
        public List<Manufacturer> manufacturers;
        public static string manuFilePath;
        private const string header = "Name,Headquarters,Year";

        public ManuDataStore(string? path = null)
        {
            manuFilePath = path;
            manufacturers = GetManufacturersFromFile();
        }

        private static List<Manufacturer> GetManufacturersFromFile(string? path = null)
        {
            if (path == null) { path = manuFilePath; }

            var query =
                    File.ReadAllLines(path)
                    .Skip(1)
                    .Where(l => l.Length > 1)
                    .ToManufacturer();

            return query.ToList();
        }
        public void AddManufacturer(Manufacturer manufacturer)
        {
            manufacturers.Add(manufacturer);
            File.WriteAllLines(manuFilePath, new[] { header }
        .Concat(manufacturers.Select(c => $"{c.Name},{c.Headquarters},{c.Year}")));
        }
    }
}
